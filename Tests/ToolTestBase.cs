// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.28

using System;
using NUnit.Framework;

namespace OrmBattle.Tests
{
  [TestFixture]
  public abstract class ToolTestBase
  {
    public Scorecard Scorecard { get; set; }

    public abstract string ToolName { get; }
    public abstract string ShortToolName { get; }

    protected abstract void Setup();
    protected abstract void TearDown();

    [SetUp]
    public void BaseSetup()
    {
      Console.WriteLine("Testing: {0}", ToolName);
      Setup();
    }

    [TearDown]
    public void BaseTearDown()
    {
      TearDown();
      if (Scorecard==null)
        Console.WriteLine();
    }

    protected void LogResult(string test, object result, string unit)
    {
      if (Scorecard!=null)
        Scorecard.Add(ShortToolName, test, result);
      else
        Console.WriteLine("{0}: {1} {2}", test, result, unit);
    }
  }
}