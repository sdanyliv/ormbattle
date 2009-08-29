// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.11

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using OrmBattle.Tests;
using OrmBattle.Tests.Linq;
using Xtensive.Core;
using Xtensive.Core.Collections;
using Xtensive.Core.Helpers;
using Xtensive.Core.Reflection;


namespace OrmBattle.TestRunner
{
  [Serializable]
  public class LinqTestRunner
  {
    private const string LtArgMarker = "-lt:";
    private LinqScorecard scorecard;

    public void Run()
    {
      HashSet<string> toolNames = Program.ToolNames;
      string ltArg = Program.Args.Where(a => a.StartsWith(LtArgMarker)).SingleOrDefault();
      if (ltArg!=null) {
        ltArg = ltArg.Remove(0, LtArgMarker.Length);
        toolNames = ltArg.RevertibleSplit('/', ',').ToHashSet();
      }

      scorecard = new LinqScorecard();
      var tests = new List<ToolTestBase> {
        new EFTest(), 
        new DOTest(),
        new LightSpeedTest(),
        new NHibernateTest(),
        new OpenAccessTest(),
        new MaximumTest()
      };
      if (toolNames!=null)
        tests = tests.Where(t => toolNames.Contains(t.ShortToolName.ToLower())).ToList();
      if (tests.Count==0)
        return;

      Console.WriteLine("LINQ tests:");

      bool firstTest = true;
      foreach (var test in tests) {
        test.Scorecard = scorecard;
        var total = 0;
        var failed = 0;
        var asserted = 0;
        var type = test.GetType();
        try {
          var setup = type.GetMethod("BaseSetup");
          setup.Invoke(test, ArrayUtils<object>.EmptyArray);
          foreach (var method in type.GetMethods().Where(mi => mi.IsDefined(typeof (TestAttribute), false))) {
            try {
              total++;
              if ((test is MaximumTest)) {
                LogResult(test, method, true, false);
                failed++;
                asserted++;
              }
              else {
                method.Invoke(test, ArrayUtils<object>.EmptyArray);
                LogResult(test, method, false, false);
              }
            }
            catch(Exception e) {
              failed++;
              var targetInvocationException = e as TargetInvocationException;
              if (targetInvocationException!=null &&
                targetInvocationException.InnerException.GetType()==typeof (AssertionException)) {
                asserted++;
                LogResult(test, method, true, true);
              }
              else
                LogResult(test, method, true, false);
            }
          }
        }
        catch (Exception e) {
          Console.WriteLine("Failed: {0}", e);
          continue;
        }
        finally {
          if (firstTest) {
            firstTest = false;
            scorecard.Tests.Sort();
          }
          LogOverallResult(test, total, failed, asserted);
          var tearDown = type.GetMethod("BaseTearDown");
          try {
            tearDown.Invoke(test, ArrayUtils<object>.EmptyArray);
          }
          catch (Exception e) {
            Console.WriteLine("BaseTearDown failed: {0}", e);
          }
        }
      }
      Console.WriteLine();
      Console.WriteLine("Scorecard:");
      Console.WriteLine(scorecard);
      Console.WriteLine();
    }

    private void LogResult(ToolTestBase test, MethodInfo method, bool failed, bool assertionFailed)
    {
      var testName = method.GetAttribute<CategoryAttribute>(AttributeSearchOptions.InheritNone).Name;
      object result = scorecard.Get(test.ShortToolName, testName);
      var pair = new Pair<int, int>();
      if (result is Pair<int, int>)
        pair = (Pair<int, int>) result;
      pair = new Pair<int, int>(
        pair.First + (failed ? 1 : 0), 
        pair.Second + (assertionFailed ? 1 : 0));
      scorecard.Set(test.ShortToolName, testName, pair);
    }

    private void LogOverallResult(ToolTestBase test, int total, int failed, int asserted)
    {
      int passed = total - failed;
      int properlyFailed = failed - asserted;
      if (test is MaximumTest) {
        passed = total;
        properlyFailed = failed;
      }
      scorecard.Add(test.ShortToolName, string.Empty, string.Empty);
      scorecard.Add(test.ShortToolName, "Total:", string.Empty);
      scorecard.Add(test.ShortToolName, "  Performed", total);
      scorecard.Add(test.ShortToolName, "  Passed", passed);
      scorecard.Add(test.ShortToolName, "  Failed", failed);
      scorecard.Add(test.ShortToolName, "    Properly", properlyFailed);
      scorecard.Add(test.ShortToolName, "    Asserted", asserted);
      scorecard.Add(test.ShortToolName, "  Score, %", string.Format("{0:F1}", passed * 100.0 / total));
    }
  }
}