// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.28

using System;
using NUnit.Framework;
using Xtensive.Core.Diagnostics;
using Xtensive.Core.Testing;
using Xtensive.Core.Reflection;

namespace OrmBattle.Tests.Performance
{
  [TestFixture]
  public abstract class PerformanceTestBase : ToolTestBase
  {
    public const string BaseUnit = "op/s";
    public const string PpsUnit  = "pages/s";
    public const string QpsUnit  = "queries/s";
    public const string OpsUnit  = "objects/s";

    public const string CreateMultiple = "Create Instance [Multiple]";
    public const string CreateSingle   = "Create Instance [Single]";
    public const string UpdateMultiple = "Update Instance [Multiple]";
    public const string UpdateSingle   = "Update Instance [Single]";
    public const string RemoveMultiple = "Remove Instance [Multiple]";
    public const string RemoveSingle   = "Remove Instance [Single]";
    public const string CudAverageMultiple = "CUD Average [Multiple]";
    public const string CudAverageSingle   = "CUD Average [Single]";
    public const string Fetch              = "Fetch";
    public const string LinqQuery          = "LINQ Query";
    public const string CompiledLinqQuery  = "Compiled LINQ Query";
    public const string NativeQuery        = "Native Query";
    public const string LinqMaterialize    = "LINQ Materialize";
    public const string NativeMaterialize  = "Native Materialize";
    public const string LinqQuerySmallPage   = "Get Small Page   (10 items)";
    public const string LinqQueryAveragePage = "Get Average Page (20 items)";
    public const string LinqQueryLargePage   = "Get Large Page   (50 items)";
    public const string LinqQueryHugePage    = "Get Huge Page    (100 items)";

    public const int DefaultCount = 1000;
    public const int WarmupMaxCount = 10000;

    public const int SmallPageSize = 10;
    public const int AveragePageSize = 20;
    public const int LargePageSize = 50;
    public const int HugePageSize = 100;

    public int BaseCount = DefaultCount;
    public int InstanceCount = 0;
    protected bool warmup;

    protected abstract void OpenSession();
    protected abstract void CloseSession();

    [Test]
    public void Execute()
    {
      warmup = true;
      Execute(Math.Min(BaseCount, WarmupMaxCount));

      warmup = false;
      Execute(BaseCount);
    }

    private void Execute(int count)
    {
      var im = Measure(InsertMultipleTest, count, 1);
      var um = Measure(UpdateMultipleTest, count, 1);

      Measure(FetchTest, count / 2, 1);
      
      Measure(LinqQueryTest, count / 5, 1);
      Measure(CompiledLinqQueryTest, count / 5, 1);
      Measure(NativeQueryTest, count / 5, 1);
      
      int materializationPassCount = (count < 1000) ? 100 : 10;
      Measure(LinqMaterializeTest, count, materializationPassCount);
      Measure(NativeMaterializeTest, count, materializationPassCount);

      int minPageCount = 2;
      int pageCount = count / SmallPageSize;
      if (pageCount >= minPageCount)
        Measure(LinqQuerySmallPageTest, pageCount, 1);
      pageCount = count / AveragePageSize;
      if (pageCount >= minPageCount)
        Measure(LinqQueryAveragePageTest, pageCount, 1);
      pageCount = count / LargePageSize;
      if (pageCount >= minPageCount)
        Measure(LinqQueryLargePageTest, pageCount, 1);
      pageCount = count / HugePageSize;
      if (pageCount >= minPageCount)
        Measure(LinqQueryHugePageTest, pageCount, 1);

      var dm = Measure(DeleteMultipleTest, count, 1);
      if (im.HasValue && um.HasValue && dm.HasValue)
        LogResult(CudAverageMultiple, (int) (3d / (1d / im + 1d / um + 1d / dm)), BaseUnit);

      var @is = Measure(InsertSingleTest, count / 5, 1);
      var us = Measure(UpdateSingleTest, count / 5, 1);
      var ds = Measure(DeleteSingleTest, count / 5, 1);
      if (@is.HasValue && us.HasValue && ds.HasValue)
        LogResult(CudAverageSingle, (int) (3d / (1d / @is + 1d / us + 1d / ds)), BaseUnit);
    }

    #region Measure methods

    private int? Measure(Action<int> test, string testName, int count, int passCount)
    {
      double seconds = 1E+100;
      for (int i = 0; i < passCount; i++) {
        if (!warmup)
          TestHelper.CollectGarbage();
        OpenSession();
        var measurement = new Measurement(MeasurementOptions.None);
        try {
          test.Invoke(count);
          measurement.Complete();
          seconds = Math.Min(seconds, measurement.TimeSpent.TotalSeconds);
        }
        catch (Exception e) {
          Log.Error(e);
          return null;
        }
        finally {
          CloseSession();
        }
      }
      if (!warmup) {
        int result = GetResult(count, seconds);
        string unit = BaseUnit;
        if (testName.Contains("Page"))
          unit = PpsUnit;
        else if (testName.Contains("Materialize"))
          unit = OpsUnit;
        else if (testName.Contains("Query"))
          unit = QpsUnit;
        LogResult(testName, result, unit);
        return result;
      }
      else
        return null;
    }

    private int? Measure(Action<int> test, int count, int passCount)
    {
      string testName = test.Method.GetAttribute<CategoryAttribute>(AttributeSearchOptions.InheritAll).Name;
      return Measure(test, testName, count, passCount);
    }

    private int? Measure(Action test, string testName, int count, int passCount)
    {
      return Measure(i => test.Invoke(), testName, count, passCount);
    }

    private int? Measure(Action test, int count, int passCount)
    {
      string testName = test.Method.GetAttribute<CategoryAttribute>(AttributeSearchOptions.InheritAll).Name;
      return Measure(i => test.Invoke(), testName, count, passCount);
    }

    #endregion

    #region Helper methods

    private int GetResult(long operationCount, double totalSeconds)
    {
      return (int) (operationCount / totalSeconds);
    }

    #endregion

    #region Test methods to implement

    [Category(CreateMultiple)]
    protected abstract void InsertMultipleTest(int count);
    [Category(UpdateMultiple)]
    protected abstract void UpdateMultipleTest();
    [Category(RemoveMultiple)]
    protected abstract void DeleteMultipleTest();
    [Category(CreateSingle)]
    protected abstract void InsertSingleTest(int count);
    [Category(UpdateSingle)]
    protected abstract void UpdateSingleTest();
    [Category(RemoveSingle)]
    protected abstract void DeleteSingleTest();
    [Category(Fetch)]
    protected abstract void FetchTest(int count);
    [Category(LinqQuery)]
    protected abstract void LinqQueryTest(int count);
    [Category(CompiledLinqQuery)]
    protected abstract void CompiledLinqQueryTest(int count);
    [Category(NativeQuery)]
    protected abstract void NativeQueryTest(int count);
    [Category(LinqMaterialize)]
    protected abstract void LinqMaterializeTest(int count);
    [Category(NativeMaterialize)]
    protected abstract void NativeMaterializeTest(int count);

    [Category(LinqQuerySmallPage)]
    protected void LinqQuerySmallPageTest(int count)
    {
      LinqQueryPageTest(count, SmallPageSize);
    }

    [Category(LinqQueryAveragePage)]
    protected void LinqQueryAveragePageTest(int count)
    {
      LinqQueryPageTest(count, AveragePageSize);
    }

    [Category(LinqQueryLargePage)]
    protected void LinqQueryLargePageTest(int count)
    {
      LinqQueryPageTest(count, LargePageSize);
    }

    [Category(LinqQueryHugePage)]
    protected void LinqQueryHugePageTest(int count)
    {
      LinqQueryPageTest(count, HugePageSize);
    }

    protected abstract void LinqQueryPageTest(int count, int pageSize);

    #endregion
  }
}