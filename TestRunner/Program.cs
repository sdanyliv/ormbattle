// Copyright (C) 2009-2010 ORMBattle.NET.
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
    private const string JSONArgMarker = "-json";
    private const string TArgMarker = "-t:";
    private const string WArgMarker = "-w";
    private const string JSONOutFile = "../../../Results/json/Output.json";
    public static string[] Args;
    public static List<string> ToolNames = null;
    private static JsonWriter jsonOutput = null;

    public static void JSONOutput(string jsonSTR)
    {
        if (jsonOutput != null)
        {
            jsonOutput.Write(jsonSTR);
        }
    }


    private static void Main(string[] args)
    {
      Args = args.Select(a => a.ToLower()).ToArray();

      string tArg = Args.Where(a => a.StartsWith(TArgMarker)).SingleOrDefault();
      if (tArg!=null) {
        tArg = tArg.Remove(0, TArgMarker.Length);
        ToolNames = tArg.RevertibleSplit('/', ',').Distinct().ToList();
      }
      string outArg = Program.Args.Where(a => a.StartsWith(JSONArgMarker)).SingleOrDefault();
      if (outArg != null)
      {
          jsonOutput = new JsonWriter(File.Create(JSONOutFile));
      }

      var linqTestRunner = new LinqTestRunner();
      var performanceTestRunner = new PerformanceTestRunner();

      linqTestRunner.Run();
      performanceTestRunner.Run();

      jsonOutput.Close();

      if (Args.Where(a => a==WArgMarker).SingleOrDefault()!=null)
        Console.ReadKey();
    }


  }
}