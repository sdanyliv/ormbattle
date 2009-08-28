// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.11

using System;
using System.Collections.Generic;
using OrmBattle.Tests;
using OrmBattle.Tests.Performance;

namespace OrmBattle.TestRunner
{
  [Serializable]
  public class PerformanceTestRunner
  {
    public int[] BaseCounts;

    public void Run()
    {
      foreach (int baseCount in BaseCounts)
      {
        Console.WriteLine("Performance tests ({0}):", baseCount);
        Console.WriteLine();

        var scorecard = new Scorecard();
        scorecard.Tests.Add(PerformanceTestBase.CreateSingle);
        scorecard.Tests.Add(PerformanceTestBase.UpdateSingle);
        scorecard.Tests.Add(PerformanceTestBase.RemoveSingle);
        scorecard.Tests.Add(PerformanceTestBase.CreateMultiple);
        scorecard.Tests.Add(PerformanceTestBase.UpdateMultiple);
        scorecard.Tests.Add(PerformanceTestBase.RemoveMultiple);
        scorecard.Tests.Add(PerformanceTestBase.Fetch);
        scorecard.Tests.Add(PerformanceTestBase.LinqQuery);
        scorecard.Tests.Add(PerformanceTestBase.CompiledLinqQuery);
        scorecard.Tests.Add(PerformanceTestBase.NativeQuery);
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
        Console.WriteLine(scorecard);
        Console.WriteLine();
      }
    }

    public PerformanceTestRunner(params int[] baseCounts)
    {
      BaseCounts = baseCounts;
    }
  }
}