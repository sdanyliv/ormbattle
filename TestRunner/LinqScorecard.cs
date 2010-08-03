// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Text;
using Newtonsoft.Json;
using OrmBattle.Tests;
using Xtensive.Core;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;


namespace OrmBattle.TestRunner
{
  [Serializable]
  public class LinqScorecard : Scorecard
  {
    protected override void AppendResult(StringBuilder sb, object result)
    {
      if (!(result is Pair<int, int>)) {
        base.AppendResult(sb, result);
        return;
      }
      var pair = (Pair<int, int>) result;
      if (pair.Second==0)
        base.AppendResult(sb, pair.First);
      else
        base.AppendResult(sb, string.Format("{0}/{1}", pair.First, pair.Second));
    }

    protected override void TestToJson(string testName, JObject output)
    {
      var score = new List<string> {"Performed", "Passed", "Failed", "Score", "Properly", "Asserted"};

      foreach (var item in score)
        if (testName==item)
          return;

      base.TestToJson(testName, output);
    }

    protected override void ToolTestToJson(ToolTestBase toolTest, JObject output)
    {
      if (!(toolTest is Tests.Linq.MaximumTest))
        ToolTestScoreToJson(toolTest, output);
      else {
        foreach (JObject test in (JArray) output["Tests"]) {
          object maximum = Get(toolTest.ShortToolName, ((string) test["Name"]));
          maximum = JObject.Parse(JsonConvert.SerializeObject(maximum));
          test.Add("Maximum", (JObject) maximum);
        }
      }
    }

    private void ToolTestScoreToJson(ToolTestBase toolTest, JObject output)
    {
      base.ToolTestToJson(toolTest, output);
      var tool = (JObject) output["Tools"].Last;
      string toolName = toolTest.ShortToolName;

      tool.Add("Performed", new JValue(Get(toolName, "Performed")));
      tool.Add("Passed", new JValue(Get(toolName, "Passed")));
      tool.Add("Failed", new JValue(Get(toolName, "Failed")));
      tool.Add("Score", new JValue(Get(toolName, "Score")));
    }

    protected override void ToolTestResultToJson(object result, JObject output)
    {
      if (result is Pair<int, int>)
        result = JObject.Parse(JsonConvert.SerializeObject(result));
      base.ToolTestResultToJson(result, output);
    }
  }
}