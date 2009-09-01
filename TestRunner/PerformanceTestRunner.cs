// Copyright (C) 2009 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.11

using System;
using System.Collections.Generic;
using System.Linq;
using OrmBattle.Tests;
using OrmBattle.Tests.Performance;
using Xtensive.Core.Helpers;

namespace OrmBattle.TestRunner
{
  [Serializable]
  public class PerformanceTestRunner
  {
    private const string PiArgMarker = "-pi:";
    private const string PtArgMarker = "-pt:";
    private const string Indent = "  ";
    private const string Indent2 = Indent + Indent;
    public static int[] DefaultItemCounts = new[] {50, 100, 500, 1000, 5000, 10000, 30000};
    public int[] ItemCounts;

    /// <summary>
    /// Runs this instance.
    /// </summary>
    public void Run()
    {
      var toolNames = Program.ToolNames;
      string ptArg = Program.Args.Where(a => a.StartsWith(PtArgMarker)).SingleOrDefault();
      if (ptArg!=null) {
        ptArg = ptArg.Remove(0, PtArgMarker.Length);
        toolNames = ptArg.RevertibleSplit('/', ',').Distinct().ToList();
      }

      foreach (int itemCount in ItemCounts) {
        var scorecard = new Scorecard();
        scorecard.RegisterTest("CRUD Performance:");
        scorecard.RegisterTest(Indent + PerformanceTestBase.Fetch);
        scorecard.RegisterTest(Indent + "Single Operation:");
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.CreateSingle);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.UpdateSingle);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.RemoveSingle);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.CudAverageSingle);
        scorecard.RegisterTest(Indent + "Multiple Operations:");
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.CreateMultiple);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.UpdateMultiple);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.RemoveMultiple);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.CudAverageMultiple);
        scorecard.RegisterTest("Data Access Performance:");
        scorecard.RegisterTest(Indent + "Query:");
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.LinqQuery);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.CompiledLinqQuery);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.NativeQuery);
        scorecard.RegisterTest(Indent + "Paging (LINQ only):");
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.LinqQuerySmallPage);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.LinqQueryAveragePage);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.LinqQueryLargePage);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.LinqQueryHugePage);
        scorecard.RegisterTest(Indent + "Materialization:");
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.LinqMaterialize);
        scorecard.RegisterTest(Indent2 + PerformanceTestBase.NativeMaterialize);

        var tests = new List<PerformanceTestBase> {
          new EFTest(),
          new DOTest(),
          new LightSpeedTest(),
          new NHibernateTest(),
          new OpenAccessTest(),
          new SubsonicTest(),
          new SqlClientTest(),
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
        foreach (var test in tests)
          scorecard.Tools.Add(test.ShortToolName);
        scorecard.Tools.Add(ToolTestBase.Unit);

        string sequenceName = string.Format("Performance tests ({0} items)", itemCount);
        Console.WriteLine("{0}:", sequenceName);

        foreach (var test in tests) {
          try {
            test.Scorecard = scorecard;
            test.BaseCount = itemCount;
            test.BaseSetup();
            test.Execute();
          }
          catch (Exception e) {
            Console.WriteLine("  Failed: {0}", e);
            continue;
          }
          finally {
            try {
              test.BaseTearDown();
            }
            catch (Exception e) {
              Console.WriteLine("  BaseTearDown failed: {0}", e);
            }
          }
        }

        Console.WriteLine();
        Console.WriteLine("{0} scorecard:", sequenceName);
        Console.Write(scorecard);
        Console.WriteLine();
        Console.WriteLine("Units:");
        Console.WriteLine("  op/s:      operations per second, more is better;");
        Console.WriteLine("  queries/s: queries per second, more is better;");
        Console.WriteLine("  pages/s:   pages per second, more is better;");
        Console.WriteLine("  objects/s: # of materialized objects per second, more is better.");
        Console.WriteLine();
        Console.WriteLine();
      }
    }

    public PerformanceTestRunner()
    {
      string piArg = Program.Args.Where(a => a.StartsWith(PiArgMarker)).SingleOrDefault();
      if (piArg==null)
        ItemCounts = DefaultItemCounts;
      else {
        piArg = piArg.Remove(0, PiArgMarker.Length);
        ItemCounts = piArg.RevertibleSplit('/', ',').Select(s => int.Parse(s)).ToArray();
      }
    }
  }
}