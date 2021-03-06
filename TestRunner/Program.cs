﻿// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Collections.Generic;
using System.Linq;
using Xtensive.Core;
using System.IO;

namespace OrmBattle.TestRunner
{
  internal class Program
  {
    private const string TArgMarker = "-t:";
    private const string WArgMarker = "-w";
    private const string JsonArgMarker = "-json:";
    private const string JsonOutputFile = "../../../Result/json/Output.json";

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

      IDisposable jsonWriterScope = null;
      string jsonArg = args.Where(a => a.ToLower().StartsWith(JsonArgMarker)).SingleOrDefault();
      if (jsonArg!=null) {
        jsonArg = jsonArg.Remove(0, Math.Min(JsonArgMarker.Length, jsonArg.Length));
        if (jsonArg.IsNullOrEmpty())
          jsonWriterScope = JsonWriter.Initialize(JsonOutputFile);
        else
          jsonWriterScope = JsonWriter.Initialize(jsonArg);
      }

      using (jsonWriterScope) {
        var linqTestRunner = new LinqTestRunner();
        var performanceTestRunner = new PerformanceTestRunner();
        linqTestRunner.Run();
        performanceTestRunner.Run();
      }

      if (Args.Where(a => a==WArgMarker).SingleOrDefault()!=null)
        Console.ReadKey();
    }
  }
}