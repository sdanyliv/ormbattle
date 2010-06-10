// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using System.Text;
using OrmBattle.Tests;
using Xtensive.Core;

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
  }
}