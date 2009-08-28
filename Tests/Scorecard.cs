// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Collections.Generic;
using System.Text;
using Xtensive.Core;

namespace OrmBattle.Tests
{
  [Serializable]
  public class Scorecard
  {
    public List<string> Tools { get; private set; }
    public List<string> Tests { get; private set; }
    public Dictionary<Pair<string, string>, object> Results { get; private set; }

    public void Add(string tool, string test, object result)
    {
      if (!Tools.Contains(tool))
        Tools.Add(tool);
      if (!Tests.Contains(test))
        Tests.Add(test);
      var key = new Pair<string, string>(test, tool);
      Results.Add(key, result);
    }

    public void Set(string tool, string test, object result)
    {
      if (!Tools.Contains(tool))
        Tools.Add(tool);
      if (!Tests.Contains(test))
        Tests.Add(test);
      var key = new Pair<string, string>(test, tool);
      Results[key] = result;
    }

    public object Get(string tool, string test)
    {
      var key = new Pair<string, string>(test, tool);
      return Results.ContainsKey(key) ? Results[key] : null;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      AppendTest(sb, string.Empty);
      foreach (var tool in Tools)
        AppendTool(sb, tool);
      sb.AppendLine();
      foreach (var test in Tests) {
        AppendTest(sb, test);
        foreach (var tool in Tools)
          AppendResult(sb, Get(tool, test));
        sb.AppendLine();
      }
      return sb.ToString();
    }

    protected virtual void AppendTool(StringBuilder sb, string tool)
    {
      sb.AppendFormat("{0,8}", tool);
    }

    protected virtual void AppendTest(StringBuilder sb, string test)
    {
      sb.AppendFormat("{0,-24}", test);
    }

    protected virtual void AppendResult(StringBuilder sb, object result)
    {
      sb.AppendFormat("{0,8}", result ?? "n/a");
    }


    public Scorecard()
    {
      Tools = new List<string>();
      Tests = new List<string>();
      Results = new Dictionary<Pair<string, string>, object>();
    }
  }
}