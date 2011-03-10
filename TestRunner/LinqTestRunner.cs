// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.11

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OrmBattle.Tests;
using OrmBattle.Tests.Linq;
using Xtensive.Core;
using Xtensive.Collections;
using Xtensive.Helpers;
using Xtensive.Reflection;


namespace OrmBattle.TestRunner
{
  [Serializable]
  public class LinqTestRunner
  {
    private const string BaseUnit = "f/a";
    private const string CountUnit = "#";
    private const string PercentageUnit = "%";

    private const string LtArgMarker  = "-lt:";
    private const string LucArgMarker = "-luc";

    private const string Indent = "  ";
    private const string Indent2 = Indent + Indent;

    private LinqScorecard scorecard;
    private bool updateComments;

    public void Run()
    {
      var toolNames = Program.ToolNames;
      string ltArg = Program.Args.Where(a => a.StartsWith(LtArgMarker)).SingleOrDefault();
      if (ltArg!=null) {
        ltArg = ltArg.Remove(0, LtArgMarker.Length);
        toolNames = ltArg.RevertibleSplit('/', ',').Distinct().ToList();;
      }

      string lucArg = Program.Args.Where(a => a==LucArgMarker).SingleOrDefault();
      if (lucArg!=null)
        updateComments = true;


      scorecard = new LinqScorecard();
      var tests = new List<LinqTestBase> {
        new BLToolkitTest(),
        new EFTest(), 
        new DOTest(),
        //new LightSpeedTest(),
        new LinqConnectTest(),
        new Linq2SqlTest(),
        new NHibernateTest(),
        new OpenAccessTest(),
      };
      if (toolNames!=null)
        tests = (
          from test in tests
          let shortToolName = test.ShortToolName.ToLower()
          let toolIndex = toolNames.IndexOf(shortToolName) 
          where toolIndex>=0
          orderby toolIndex
          select test).ToList();
      if (tests.Count==0)
        return;
      tests.Add(new MaximumTest());
      foreach (var test in tests)
        scorecard.Tools.Add(test.ShortToolName);
      scorecard.Tools.Add(ToolTestBase.Unit);

      string sequenceName = "LINQ tests";
      Console.WriteLine("{0}:", sequenceName);

      bool firstTest = true;
      foreach (var test in tests) {
        test.Scorecard = scorecard;
        var total = 0;
        var failed = 0;
        var asserted = 0;
        var type = test.GetType();
        try {
          if (!(test is MaximumTest)) {
            var setupMethod = type.GetMethod("BaseSetup");
            setupMethod.Invoke(test, ArrayUtils<object>.EmptyArray);
          }
          foreach (var method in type.GetMethods().Where(mi => mi.IsDefined(typeof (TestAttribute), false))) {
            try {
              total++;
              if ((test is MaximumTest)) {
                LogResult(test, method, new Exception(), false);
                failed++;
                asserted++;
              }
              else {
                method.Invoke(test, ArrayUtils<object>.EmptyArray);
                LogResult(test, method, null, false);
              }
            }
            catch (Exception error) {
              failed++;
              error = EnumerableUtils.Unfold(error, e => e.InnerException).Last();
              bool isAssertion = error is AssertionException;
              asserted += isAssertion ? 1 : 0;
              LogResult(test, method, error, isAssertion);
            }
          }
        }
        catch (Exception e) {
          Console.WriteLine("  Failed: {0}", e);
          continue;
        }
        finally {
          if (firstTest) {
            firstTest = false;
            scorecard.Tests.Sort();
            scorecard.Tests.Insert(0, "LINQ Implementation:");
          }
          LogOverallResult(test, total, failed, asserted);
          var tearDownMethod = type.GetMethod("BaseTearDown");
          try {
            tearDownMethod.Invoke(test, ArrayUtils<object>.EmptyArray);
          }
          catch (Exception e) {
            Console.WriteLine("  BaseTearDown failed: {0}", e);
          }
        }
      }

      
      Console.WriteLine();
      Console.WriteLine("{0} scorecard:", sequenceName);
      
      Console.Write(scorecard);
      JsonWriter.Write(scorecard.ToJson(sequenceName, tests.ToArray<ToolTestBase>()));

      Console.WriteLine();
      Console.WriteLine("Units:");
      Console.WriteLine("  f/a: total count of failed tests [ / count of tests failed with assertion ],");
      Console.WriteLine("       less is better (0 is ideal);");
      Console.WriteLine("  #:   count;");
      Console.WriteLine("  %:   percentage (% of passed tests), more is better.");
      Console.WriteLine();
      Console.WriteLine();
    }

    private void LogResult(LinqTestBase test, MethodInfo method, Exception error, bool isAssertion)
    {
      var testName = Indent + method.GetAttribute<CategoryAttribute>(AttributeSearchOptions.InheritNone).Name;
      var tool = test.ShortToolName;
      object result = scorecard.Get(tool, testName);
      var pair = new Pair<int, int>();
      if (result is Pair<int, int>)
        pair = (Pair<int, int>) result;
      pair = new Pair<int, int>(
        pair.First + (error!=null ? 1 : 0), 
        pair.Second + (isAssertion ? 1 : 0));
      scorecard.Set(tool, testName, pair);
      scorecard.Set(ToolTestBase.Unit, testName, BaseUnit);

      if (updateComments && !(test is MaximumTest)) {
        string comment = "Passed.";
        if (error!=null)
          comment = string.Format("Failed{0}.\r\nException: {1}\r\nMessage:\r\n{2}",
            isAssertion ? " with assertion" : string.Empty,
            error.GetType().GetShortName(),
            (error.Message ?? "none").Indent(2));
        var pattern = @"(?<Prefix>[\r\n]{2} (?<Indent>\s+)  \[Test\] \s*
		      [\r\n]{2} \k<Indent> \[Category\(.+\)\] *)
		      (?<Comment>
		      ([\r\n]{2} \s+ // \s+ .*)*
		      )
		      (?<Method>
		      [\r\n]{2} \s+ public \s+ void \s+ " + Regex.Escape(method.Name) + @" \s* \(\s*\) \s*
		      )";
        var regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
        var indent = regex.Matches(test.Source).Cast<Match>().Single().Groups["Indent"].Value;
        comment = comment.Split('\n')
          .Select(s => s.TrimEnd(' ', '\r'))
          .Reverse()
          .SkipWhile(s => s.Trim().Length==0)
          .Reverse()
          .Select(s => indent + @"// " + s)
          .ToDelimitedString("\r\n");
        test.Source = regex.Replace(test.Source, "${Prefix}\r\n" + comment + "${Method}");
      }
    }

    private void LogOverallResult(LinqTestBase test, int total, int failed, int asserted)
    {
      int passed = total - failed;
      int properlyFailed = failed - asserted;
      if (test is MaximumTest) {
        passed = total;
        properlyFailed = failed;
      }
      string score = string.Format("{0:F1}", passed * 100.0 / total);

      LogTotal(test.ShortToolName, "Total:", string.Empty, string.Empty);
      LogTotal(test.ShortToolName, Indent + "Performed", total, CountUnit);
      LogTotal(test.ShortToolName, Indent + "Passed",    passed, CountUnit);
      LogTotal(test.ShortToolName, Indent + "Failed",    failed, CountUnit);
      LogTotal(test.ShortToolName, Indent2 + "Properly", properlyFailed, CountUnit);
      LogTotal(test.ShortToolName, Indent2 + "Asserted", asserted, CountUnit);
      LogTotal(test.ShortToolName, Indent + "Score",  score, PercentageUnit);
    }

    private void LogTotal(string tool, string test, object result, string unit)
    {
      scorecard.Add(tool, test, result);
      scorecard.Set(ToolTestBase.Unit, test, unit);
    }
  }
}