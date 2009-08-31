// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using NUnit.Framework;
using Xtensive.Core.Helpers;

namespace OrmBattle.Tests
{
  [TestFixture]
  public abstract class ToolTestBase
  {
    public const string Unit = "Unit";
    public Scorecard Scorecard { get; set; }

    public abstract string ToolName { get; }
    public abstract string ShortToolName { get; }

    protected abstract void Setup();
    protected abstract void TearDown();

    [SetUp]
    public virtual void BaseSetup()
    {
      Console.WriteLine("  Testing: {0} ({1})", ToolName, ShortToolName);
      Setup();
    }

    [TearDown]
    public virtual void BaseTearDown()
    {
      TearDown();
      if (Scorecard==null)
        Console.WriteLine();
    }

    protected void LogResult(string test, object result, string unit)
    {
      if (Scorecard!=null) {
        Scorecard.Add(ShortToolName, test, result);
        Scorecard.Set(Unit, test, unit);
      }
      else {
        if (!test.IsNullOrEmpty())
          Console.WriteLine("{0}: {1} {2}", test, result, unit);
      }
    }
  }
}