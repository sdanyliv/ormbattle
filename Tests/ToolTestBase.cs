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
      Console.WriteLine();
    }
  }
}