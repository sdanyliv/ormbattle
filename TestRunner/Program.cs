// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;

namespace OrmBattle.TestRunner
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var performanceTestRunner = new PerformanceTestRunner(50, 100, 500, 1000, 5000, 10000, 30000);
      var linqTestRunner = new LinqTestRunner();

      performanceTestRunner.Run();
      linqTestRunner.Run();

      // Console.ReadKey();
    }
  }
}