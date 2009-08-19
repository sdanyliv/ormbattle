// Copyright (C) 2009 Xtensive LLC.
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
      CombinedTest(2000);
      warmup = false;

      CombinedTest(BaseCount);
    }

    [Test]
    [Explicit]
    [Category("Profile")]
    public void ProfileTest()
    {
      warmup = true;
      CombinedTest(10);
      warmup = false;
      BatchInsertTest(BaseCount);
      FetchTest(BaseCount);
      MaterializeTest(BaseCount);
      CompiledQueryTest(BaseCount);
    }

    private void CombinedTest(int count)
    {
      if (warmup) {
        OpenSession();
        BatchInsertTest(count);
        BatchUpdateTest();
        FetchTest(count / 2);
        QueryTest(count / 5);
        CompiledQueryTest(count);
        MaterializeTest(count);
        BatchDeleteTest();
        CloseSession();
      }
      else {
        Measurement measure;

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        BatchInsertTest(count);
        measure.Complete();
        CloseSession();
        var batchCreateString = "Batch Create: " + GetResult(count, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        BatchUpdateTest();
        measure.Complete();
        CloseSession();
        var batchUpdateString = "Batch Update: " + GetResult(count, measure.TimeSpent.TotalSeconds);

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
        QueryTest(count / 5);
        measure.Complete();
        CloseSession();
        var queryString = "Query: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        string compiledQueryString = "Compiled query: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          CompiledQueryTest(count);
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
        BatchDeleteTest();
        measure.Complete();
        CloseSession();
        var batchRemoveString = "Batch Remove: " + GetResult(count, measure.TimeSpent.TotalSeconds);
        CloseSession();

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        InsertTest(count / 5);
        measure.Complete();
        CloseSession();
        var createString = "Create: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        UpdateTest();
        measure.Complete();
        CloseSession();
        var updateString = "Update: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        DeleteTest();
        measure.Complete();
        CloseSession();
        var removeString = "Remove: " + GetResult(count / 5, measure.TimeSpent.TotalSeconds);
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

    protected abstract void BatchInsertTest(int count);
    protected abstract void BatchUpdateTest();
    protected abstract void BatchDeleteTest();
    protected abstract void InsertTest(int count);
    protected abstract void UpdateTest();
    protected abstract void DeleteTest();
    protected abstract void FetchTest(int count);
    protected abstract void QueryTest(int count);
    protected abstract void CompiledQueryTest(int count);
    protected abstract void MaterializeTest(int count);
  }
}