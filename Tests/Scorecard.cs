// Copyright (C) 2009 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xtensive.Core;
using Xtensive.Core.Helpers;

namespace OrmBattle.Tests
{
  [Serializable]
  public class Scorecard
  {
    public List<string> Tools { get; private set; }
    public List<string> Tests { get; private set; }
    public Dictionary<string, int> Indents { get; private set; }
    public Dictionary<Pair<string, string>, object> Results { get; private set; }

    public void Add(string tool, string test, object result)
    {
      test = ExtractIndent(test, true);
      if (!Tools.Contains(tool))
        Tools.Add(tool);
      if (!Tests.Contains(test))
        Tests.Add(test);
      var key = new Pair<string, string>(test, tool);
      object prevResult;
      if (Results.TryGetValue(key, out prevResult))
      {
        if (prevResult is int && result is int)
          Results[key] = Math.Max((int)prevResult, (int)result);
      }
      else
        Results.Add(key, result);
    }

    public void RegisterTest(string test)
    {
      Tests.Add(ExtractIndent(test, true));
    }

    public void Set(string tool, string test, object result)
    {
      test = ExtractIndent(test, true);
      if (!Tools.Contains(tool))
        Tools.Add(tool);
      if (!Tests.Contains(test))
        Tests.Add(test);
      var key = new Pair<string, string>(test, tool);
      Results[key] = result;
    }

    public object Get(string tool, string test)
    {
      test = ExtractIndent(test, false);
      var key = new Pair<string, string>(test, tool);
      return Results.ContainsKey(key) ? Results[key] : null;
    }

    protected string Indent(string test)
    {
      test = test ?? string.Empty;
      if (!Indents.ContainsKey(test))
        return test;
      else
        return test.Indent(2 * Indents[test]);
    }

    private string ExtractIndent(string test, bool setIndent)
    {
      test = test ?? string.Empty;
      string trimmedTest = test.TrimStart(' ');
      int indent = (test.Length - trimmedTest.Length) / 2;
      int oldIndent = 0;
      if (Indents.ContainsKey(trimmedTest))
        oldIndent = Indents[trimmedTest];
      if (setIndent && oldIndent<indent)
        Indents[trimmedTest] = indent;
      return trimmedTest;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      AppendTest(sb, string.Empty);
      foreach (var tool in Tools)
        AppendTool(sb, tool);
      sb.AppendLine();
      foreach (var test in Tests) {
        AppendTest(sb, GetPrintableTestName(Indent(test)));
        if (!(test.IsNullOrEmpty() || test.EndsWith(":")))
          foreach (var tool in Tools)
            AppendResult(sb, Get(tool, test));
        sb.AppendLine();
      }
      return sb.ToString();
    }

    protected virtual string GetPrintableTestName(string test)
    {
      var testName = (test ?? string.Empty);
      testName = Regex.Replace(testName, @"^([^[]*)( \[[^\]]+\])?([^[\]]*)$", "${1}${3}");
      return testName;
    }

    protected virtual void AppendTool(StringBuilder sb, string tool)
    {
      sb.AppendFormat("{0,10}", tool);
    }

    protected virtual void AppendTest(StringBuilder sb, string test)
    {
      sb.AppendFormat("{0,-32}", test);
    }

    protected virtual void AppendResult(StringBuilder sb, object result)
    {
      sb.AppendFormat("{0,10}", result ?? "n/a");
    }


    public Scorecard()
    {
      Tools = new List<string>();
      Tests = new List<string>();
      Indents = new Dictionary<string, int>();
      Results = new Dictionary<Pair<string, string>, object>();
    }
  }
}