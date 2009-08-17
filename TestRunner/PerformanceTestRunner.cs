// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.11

using System;
using System.Collections.Generic;
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
        Console.Out.WriteLine("Performance tests ({0}):", baseCount);
        Console.Out.WriteLine();
        var tests = new List<TestBase> {
                      new EFTest(),
                      new DOTest(),
                      new LightSpeedTest(),
                      new LLBLGenTest(),
                      new NHibernateTest(),
                      new OpenAccessTest(),
                      new SubsonicTest(),
                      new SqlClientTest(),
                    };

        foreach (var test in tests) {
          try {
            test.BaseCount = baseCount;
            test.TestSetUp();
            test.RegularTest();
          }
          finally {
            test.TestTearDown();
          }
        }
      }
    }

    public PerformanceTestRunner(params int[] baseCounts)
    {
      BaseCounts = baseCounts;
    }
  }
}