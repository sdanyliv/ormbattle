// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xtensive.Core;
using Newtonsoft.Json.Linq;

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
                // This allows to run the same test for multiple times
                // and pick up the best result.
                if (prevResult is int && result is int)
                    Results[key] = Math.Max((int) prevResult, (int) result);
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
            if (setIndent && oldIndent < indent)
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
            foreach (var test in Tests)
            {
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

        public string ToJson(string cardName, ToolTestBase[] toolTests)
        {
            var result = new JObject();
            result.Add("Name", cardName);
            result.Add("Tests", new JArray());

            foreach (var test in Tests)
                TestToJson(test.ToString(), result);

            result.Add("Tools", new JArray());

            foreach (var toolTest in toolTests)
                ToolTestToJson(toolTest, result);

            return result.ToString();
        }

        protected virtual void TestToJson(string testName, JObject output)
        {
            if ((testName.IsNullOrEmpty() || testName.EndsWith(":")))
                return;

            string unit = ToolTestBase.Unit;
            var test = new JObject();
            test.Add("Name", testName);
            test.Add("Unit", new JValue(Get(unit, testName)));
            ((JArray) output["Tests"]).Add(test);
        }

        protected virtual void ToolTestToJson(ToolTestBase toolTest, JObject output)
        {
            var tool = new JObject();
            tool.Add("ShortName", toolTest.ShortToolName);
            tool.Add("Name", toolTest.ToolName);
            ((JArray) output["Tools"]).Add(tool);
            tool.Add("Results", new JArray());

            foreach (var test in output["Tests"])
                ToolTestResultToJson(Get(toolTest.ShortToolName, ((string) test["Name"])), tool);
        }

        protected virtual void ToolTestResultToJson(object result, JObject output)
        {
            ((JArray) output["Results"]).Add(result);
        }


        // Constructors

        public Scorecard()
        {
            Tools = new List<string>();
            Tests = new List<string>();
            Indents = new Dictionary<string, int>();
            Results = new Dictionary<Pair<string, string>, object>();
        }
    }
}