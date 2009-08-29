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
  public abstract class PerformanceTestBase : ToolTestBase
  {
    public const string BaseUnit = "op/s";
    public const string CreateMultiple = "Create (Multiple)";
    public const string CreateSingle = "Create (Single)";
    public const string UpdateMultiple = "Update (Multiple)";
    public const string UpdateSingle = "Update (Single)";
    public const string RemoveMultiple = "Remove (Multiple)";
    public const string RemoveSingle = "Remove (Single)";
    public const string Fetch = "Fetch";
    public const string LinqQuery = "LINQ Query";
    public const string CompiledLinqQuery = "Compiled LINQ Query";
    public const string NativeQuery = "Native Query";
    public const string LinqMaterialize = "LINQ Materialize";
    public const string NativeMaterialize = "Native Materialize";

    public int BaseCount = 1000;
    public int WarmupCount = 10000;
    protected int instanceCount = 0;
    protected bool warmup;

    protected abstract void OpenSession();
    protected abstract void CloseSession();

    [Test]
    public void RegularTest()
    {
      warmup = true;
      CombinedTest(Math.Min(BaseCount,WarmupCount));
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
      LinqMaterializeTest(BaseCount);
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
        LinqMaterializeTest(count);
        NativeQueryTest(count / 5);
        NativeMaterializeTest(count);
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
        LogResult(CreateMultiple, GetResult(count, measure.TimeSpent.TotalSeconds), BaseUnit);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        UpdateMultipleTest();
        measure.Complete();
        CloseSession();
        LogResult(UpdateMultiple, GetResult(count, measure.TimeSpent.TotalSeconds), BaseUnit);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        FetchTest(count/2);
        measure.Complete();
        CloseSession();
        LogResult(Fetch, GetResult(count/2, measure.TimeSpent.TotalSeconds), BaseUnit);

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          LinqQueryTest(count/5);
          measure.Complete();
          CloseSession();
          if (!scope.IsCaptured(LogEventTypes.Error))
            LogResult(LinqQuery, GetResult(count/5, measure.TimeSpent.TotalSeconds), BaseUnit);
        }

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          CompiledLinqQueryTest(count);
          measure.Complete();
          CloseSession();
          if (!scope.IsCaptured(LogEventTypes.Error))
            LogResult(CompiledLinqQuery, GetResult(count, measure.TimeSpent.TotalSeconds), BaseUnit);
        }

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          int materializationPassCount = (count < 1000) ? 100 : 10;
          double seconds = 0;
          for (int i = 0; i < materializationPassCount; i++) {
            TestHelper.CollectGarbage();
            OpenSession();
            measure = new Measurement(MeasurementOptions.None);
            LinqMaterializeTest(count);
            measure.Complete();
            CloseSession();
            // seconds = Math.Min(measure.TimeSpent.TotalSeconds, seconds);
            seconds += measure.TimeSpent.TotalSeconds;
          }
          if (!scope.IsCaptured(LogEventTypes.Error))
            LogResult(LinqMaterialize, GetResult(count*materializationPassCount, seconds), BaseUnit);
        }

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        NativeQueryTest(count/5);
        measure.Complete();
        CloseSession();
        LogResult(NativeQuery, GetResult(count/5, measure.TimeSpent.TotalSeconds), BaseUnit);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        NativeMaterializeTest(count);
        measure.Complete();
        CloseSession();
        LogResult(NativeMaterialize, GetResult(count, measure.TimeSpent.TotalSeconds), BaseUnit);

        TestHelper.CollectGarbage();
        OpenSession();
        measure = new Measurement(MeasurementOptions.None);
        DeleteMultipleTest();
        measure.Complete();
        CloseSession();
        LogResult(RemoveMultiple, GetResult(count, measure.TimeSpent.TotalSeconds), BaseUnit);

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          InsertSingleTest(count/5);
          measure.Complete();
          CloseSession();
          if (!scope.IsCaptured(LogEventTypes.Error))
            LogResult(CreateSingle, GetResult(count/5, measure.TimeSpent.TotalSeconds), BaseUnit);
        }

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          UpdateSingleTest();
          measure.Complete();
          CloseSession();
          if (!scope.IsCaptured(LogEventTypes.Error))
            LogResult(UpdateSingle, GetResult(count/5, measure.TimeSpent.TotalSeconds), BaseUnit);
        }

        using (var scope = new LogCaptureScope(LogProvider.NullLog)) {
          TestHelper.CollectGarbage();
          OpenSession();
          measure = new Measurement(MeasurementOptions.None);
          DeleteSingleTest();
          measure.Complete();
          CloseSession();
          if (!scope.IsCaptured(LogEventTypes.Error))
            LogResult(RemoveSingle, GetResult(count/5, measure.TimeSpent.TotalSeconds), BaseUnit);
        }

        LogResult(string.Empty, string.Empty, string.Empty);
      }
    }

    private int GetResult(long operationCount, double totalSeconds)
    {
      return (int) (operationCount / totalSeconds);
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
    protected abstract void NativeQueryTest(int count);
    protected abstract void LinqMaterializeTest(int count);
    protected abstract void NativeMaterializeTest(int count);
  }
}