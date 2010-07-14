// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Text;
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

    protected override void JSONAppTest(JObject jsonOut, string testName)
    {
        var score = new List<string> { "Performed", "Passed", "Failed", "Score", "Properly", "Asserted" };
        foreach (var item in score)
            if (testName == item) return;
        base.JSONAppTest(jsonOut, testName);
    }

    protected override void JSONAppTool(JObject jsonOut, ToolTestBase tooldata)
    {
        if (!(tooldata is Tests.Linq.MaximumTest))
            JSONFillScore(jsonOut, tooldata);
        else
            foreach (JObject test in (JArray)jsonOut["Tests"])
            {
                object tmp = Get(tooldata.ShortToolName, ((string)test["Name"]));
                tmp = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(tmp));
                test.Add("Maximum", (JObject)tmp);
            }
    }

    private void JSONFillScore(JObject jsonOut, ToolTestBase tooldata)
    { 
        base.JSONAppTool(jsonOut, tooldata);
        JObject tool = (JObject)jsonOut["Tools"].Last;
        string toolName = tooldata.ShortToolName;
        tool.Add("Performed",new JValue( Get(toolName,"Performed")));
        tool.Add("Passed",new JValue( Get(toolName,"Passed")));
        tool.Add("Failed",new JValue( Get(toolName,"Failed")));
        tool.Add("Score",new JValue( Get(toolName,"Score")));
    }



    protected override void JSONAppResult(JObject jsonTool, object result)
    {
        if (result is Pair<int, int>)
            result = JObject.Parse( Newtonsoft.Json.JsonConvert.SerializeObject(result));
        base.JSONAppResult(jsonTool, result);
    }





  }
}