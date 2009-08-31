// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Collections.Generic;
using System.Linq;
using Xtensive.Core.Helpers;

namespace OrmBattle.TestRunner
{
  internal class Program
  {
    private const string TArgMarker = "-t:";
    public static string[] Args;
    public static List<string> ToolNames = null;

    private static void Main(string[] args)
    {
      Args = args.Select(a => a.ToLower()).ToArray();

      string tArg = Args.Where(a => a.StartsWith(TArgMarker)).SingleOrDefault();
      if (tArg!=null) {
        tArg = tArg.Remove(0, TArgMarker.Length);
        ToolNames = tArg.RevertibleSplit('/', ',').Distinct().ToList();
      }

      var linqTestRunner = new LinqTestRunner();
      var performanceTestRunner = new PerformanceTestRunner();

      linqTestRunner.Run();
      performanceTestRunner.Run();

      if (Args.Where(a => a=="-w").SingleOrDefault()!=null)
        Console.ReadKey();
    }
  }
}