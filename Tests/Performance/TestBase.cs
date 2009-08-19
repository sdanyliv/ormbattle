// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.28

using System;
using NUnit.Framework;
using Xtensive.Core.Diagnostics;
using Xtensive.Core.Testing;

namespace OrmBattle.Tests.Performance
{
  [TestFixture]
  public abstract class TestBase
  {
    public int BaseCount = 20000;
    public int WarmupCount = 1000;
    protected int instanceCount = 0;
    protected bool warmup;

    [SetUp]
    public void TestSetUp()
    {
      SetUp();
    }

    [TearDown]
    public void TestTearDown()
    {
      TearDown();
      Console.Out.WriteLine("");
    }

    protected abstract void SetUp();
    protected abstract void TearDown();
    protected abstract void OpenSession();
    protected abstract void CloseSession();

    [Test]
    public void RegularTest()
    {
      warmup = true;
      CombinedTest(WarmupCount);
      warmup = false;

      CombinedTest(BaseCount);
    }

    [Test]
    [Explicit]
    [Category("Profile")]
    public void ProfileTest()
    {
      InsertMultipleTest(BaseCount);
      FetchTest(BaseCount);
      MaterializeTest(BaseCount);
      CompiledLinqQueryTest(BaseCount);
    }

    private void CombinedTest(int count)
    {
      if (warmup) {
        OpenSession();
        InsertMultipleTest(count);
        UpdateMultipleTest();
        FetchTest(count / 2);
        LinqQueryTest(count / 5);
        CompiledLinqQueryTest(count);
        MaterializeTest(count);
        DeleteMultipleTest();
        InsertSingleTest(count / 5);
        UpdateSingleTest();
        DeleteSingleTest();
        CloseSession();
      }
      else {
        Measurement measure;

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        InsertMultipleTest(count);
        measure.Complete();
        CloseSession();
        var batchCreateString = "Create Multiple: " + GetResult(count, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        UpdateMultipleTest();
        measure.Complete();
        CloseSession();
        var batchUpdateString = "Update Multiple: " + GetResult(count, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        FetchTest(count / 2);
        measure.Complete();
        CloseSession();
        var fetchString = "Fetch: " + GetResult(count / 2, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        LinqQueryTest(count / 5);
        measure.Complete();
        CloseSession();
        var queryString = "Query: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        string compiledQueryString = "Compiled query: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          CompiledLinqQueryTest(count);
          measure.Complete();
          CloseSession();
          if (!scope.IsCaptured(LogEventTypes.Error)) {
            compiledQueryString = "Compiled query: " + GetResult(count, measure.TimeSpent.TotalSeconds);
          }
        }

        int materializationPassCount = (count < 1000) ? 100 : 10;
        // double seconds = 1E100;
        double seconds = 0;
        for (int i = 0; i < materializationPassCount; i++) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          MaterializeTest(count);
          measure.Complete();
          CloseSession();
          // seconds = Math.Min(measure.TimeSpent.TotalSeconds, seconds);
          seconds += measure.TimeSpent.TotalSeconds;
        }

        // var materializeString = "Materialize: " + GetResult(count, seconds);
        var materializeString = "Materialize: " + GetResult(count * materializationPassCount, seconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        DeleteMultipleTest();
        measure.Complete();
        CloseSession();
        var batchRemoveString = "Remove Multiple: " + GetResult(count, measure.TimeSpent.TotalSeconds);
        CloseSession();

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        InsertSingleTest(count / 5);
        measure.Complete();
        CloseSession();
        var createString = "Create Single: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        UpdateSingleTest();
        measure.Complete();
        CloseSession();
        var updateString = "Update Single: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        DeleteSingleTest();
        measure.Complete();
        CloseSession();
        var removeString = "Remove Single: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);
        CloseSession();

        Console.Out.WriteLine(batchCreateString);
        Console.Out.WriteLine(batchUpdateString);
        Console.Out.WriteLine(batchRemoveString);

        Console.Out.WriteLine(createString);
        Console.Out.WriteLine(updateString);
        Console.Out.WriteLine(removeString);

        Console.Out.WriteLine(fetchString);
        Console.Out.WriteLine(queryString);
        Console.Out.WriteLine(compiledQueryString);
        Console.Out.WriteLine(materializeString);
      }
    }

    private string GetResult(long operationCount, double totalSeconds)
    {
      var kmbBase = operationCount/totalSeconds;
      const string kmbFormat = "{0} op/s";
      return string.Format(kmbFormat, (long)kmbBase);
    } 

    protected abstract void InsertMultipleTest(int count);
    protected abstract void UpdateMultipleTest();
    protected abstract void DeleteMultipleTest();
    protected abstract void InsertSingleTest(int count);
    protected abstract void UpdateSingleTest();
    protected abstract void DeleteSingleTest();
    protected abstract void FetchTest(int count);
    protected abstract void LinqQueryTest(int count);
    protected abstract void CompiledLinqQueryTest(int count);
    protected abstract void MaterializeTest(int count);
  }
}