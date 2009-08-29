// Copyright (C) 2009 ORMBattle.net
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
using Xtensive.Core.Collections;

namespace OrmBattle.TestRunner
{
  [Serializable]
  public class PerformanceTestRunner
  {
    private const string PiArgMarker = "-pi:";
    private const string PtArgMarker = "-pt:";
    public static int[] DefaultBaseCounts = new[] {50, 100, 500, 1000, 5000, 10000, 30000};
    public int[] BaseCounts;
    
    public void Run()
    {
      HashSet<string> toolNames = Program.ToolNames;
      string ptArg = Program.Args.Where(a => a.StartsWith(PtArgMarker)).SingleOrDefault();
      if (ptArg!=null) {
        ptArg = ptArg.Remove(0, PtArgMarker.Length);
        toolNames = ptArg.RevertibleSplit('/', ',').ToHashSet();
      }

      foreach (int baseCount in BaseCounts)
      {
        var scorecard = new Scorecard();
        scorecard.Tests.Add(PerformanceTestBase.CreateSingle);
        scorecard.Tests.Add(PerformanceTestBase.UpdateSingle);
        scorecard.Tests.Add(PerformanceTestBase.RemoveSingle);
        scorecard.Tests.Add(string.Empty);
        scorecard.Tests.Add(PerformanceTestBase.CreateMultiple);
        scorecard.Tests.Add(PerformanceTestBase.UpdateMultiple);
        scorecard.Tests.Add(PerformanceTestBase.RemoveMultiple);
        scorecard.Tests.Add(string.Empty);
        scorecard.Tests.Add(PerformanceTestBase.Fetch);
        scorecard.Tests.Add(string.Empty);
        scorecard.Tests.Add(PerformanceTestBase.LinqQuery);
        scorecard.Tests.Add(PerformanceTestBase.CompiledLinqQuery);
        scorecard.Tests.Add(PerformanceTestBase.NativeQuery);
        scorecard.Tests.Add(string.Empty);
        scorecard.Tests.Add(PerformanceTestBase.LinqMaterialize);
        scorecard.Tests.Add(PerformanceTestBase.NativeMaterialize);

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
          tests = tests.Where(t => toolNames.Contains(t.ShortToolName.ToLower())).ToList();
        if (tests.Count==0)
          return;

        Console.WriteLine("Performance tests ({0}):", baseCount);

        foreach (var test in tests) {
          try {
            test.Scorecard = scorecard;
            test.BaseCount = baseCount;
            test.BaseSetup();
            test.RegularTest();
          }
          catch (Exception e) {
            Console.WriteLine("Failed: {0}", e);
            continue;
          }
          finally {
            try {
              test.BaseTearDown();
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
    }

    public PerformanceTestRunner()
    {
      string piArg = Program.Args.Where(a => a.StartsWith(PiArgMarker)).SingleOrDefault();
      if (piArg==null)
        BaseCounts = DefaultBaseCounts;
      else {
        piArg = piArg.Remove(0, PiArgMarker.Length);
        BaseCounts = piArg.RevertibleSplit('/', ',').Select(s => int.Parse(s)).ToArray();
      }
    }
  }
}