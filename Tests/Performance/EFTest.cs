// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:  2009.07.31

using System;
using System.Data;
using System.Data.Objects;
using OrmBattle.EFModel;
using NUnit.Framework;
using System.Linq;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class EFTest : PerformanceTestBase
  {
    private PerformanceTestEntities dataContext;

    public override string ToolName {
      get { return "ADO.NET Entity Framework"; }
    }

    public override string ShortToolName {
      get { return "EF"; }
    }

    protected override void Setup()
    {
      using (var dataContext = new PerformanceTestEntities()) {
      dataContext.Connection.Open();
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        foreach (var s in dataContext.Simplests)
        dataContext.DeleteObject(s);
        dataContext.SaveChanges(true);
        transaction.Commit();
      }
      }
    }

    protected override void TearDown()
    {
      using (var dataContext = new PerformanceTestEntities()) {
      dataContext.Connection.Open();
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        foreach (var s in dataContext.Simplests)
        dataContext.DeleteObject(s);
        dataContext.SaveChanges(true);
        transaction.Commit();
      }
      }
    }

    protected override void OpenSession()
    {
      dataContext = new PerformanceTestEntities();
      dataContext.Connection.Open();
    }

    protected override void CloseSession()
    {
      dataContext.Dispose();
    }

    protected override void InsertMultipleTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      for (int i = 0; i < count; i++) {
        var s = Simplest.CreateSimplest(i, i);
        dataContext.AddToSimplests(s);
      }
      dataContext.SaveChanges();
      transaction.Commit();
      }
      InstanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      long sum = (long)InstanceCount * (InstanceCount - 1) / 2;
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      foreach (var s in dataContext.Simplests) {
        s.Value++;
        sum -= s.Id;
      }
      dataContext.SaveChanges();
      transaction.Commit();
      }
      Assert.AreEqual(0, sum);
    }

    protected override void DeleteMultipleTest()
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      foreach (var s in dataContext.Simplests)
        dataContext.DeleteObject(s);
      dataContext.SaveChanges();
      transaction.Commit();
      }
    }

    protected override void InsertSingleTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      for (int i = 0; i < count; i++) {
        var s = Simplest.CreateSimplest(i, i);
        dataContext.AddToSimplests(s);
        dataContext.SaveChanges();
      }
      transaction.Commit();
      }
      InstanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      long sum = (long)InstanceCount * (InstanceCount - 1) / 2;
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      foreach (var s in dataContext.Simplests) {
        s.Value++;
        sum -= s.Id;
        dataContext.SaveChanges();
      }
      transaction.Commit();
      }
      Assert.AreEqual(0, sum);
    }

    protected override void DeleteSingleTest()
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      foreach (var s in dataContext.Simplests) {
        dataContext.DeleteObject(s);
        dataContext.SaveChanges();
      }
      transaction.Commit();
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var s = Simplest.GetById(dataContext, ((long) i) % InstanceCount);
          sum -= s.Id;
        }
        transaction.Commit();
      }
    
      if (count <= InstanceCount)
      Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        var result = dataContext.Simplests.Where(o => o.Id == id);
        foreach (var o in result) {
        // Doing nothing, just enumerate
        }
      }
      transaction.Commit();
      }
    }

    static readonly Func<PerformanceTestEntities, long, IQueryable<Simplest>> _compiledQuery =
          CompiledQuery.Compile((PerformanceTestEntities context, long id) => context.Simplests.Where(o => o.Id == id));

    protected override void CompiledLinqQueryTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        foreach (var o in _compiledQuery(dataContext, id)) {
        // Doing nothing, just enumerate
        }
      }
      transaction.Commit();
      }
    }

    protected override void NativeQueryTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        var result = dataContext.Simplests.Where("it.Id == @id", new ObjectParameter("id", id));
        foreach (var o in result) {
        // Doing nothing, just enumerate
        }
      }
      transaction.Commit();
      }
    }

    protected override void LinqMaterializeTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      int i = 0;
      while (i < count)
        foreach (var o in dataContext.Simplests.Where(s => s.Id > 0)) {
        if (++i >= count)
          break;
        }
      transaction.Commit();
      }
    }

    protected override void NativeMaterializeTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      int i = 0;
      while (i < count)
        foreach (var o in dataContext.Simplests) {
        if (++i >= count)
          break;
        }
      transaction.Commit();
      }
    }

    static readonly Func<PerformanceTestEntities, long, int, IQueryable<Simplest>> _pageQuery =
      CompiledQuery.Compile((PerformanceTestEntities context, long id, int pageSize) => context.Simplests.Where(o => o.Id >= id).Take(pageSize));

    protected override void LinqQueryPageTest(int count, int pageSize)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
      for (int i = 0; i < count; i++) {
        var id = (i*pageSize) % InstanceCount;
        foreach (var o in _pageQuery(dataContext, id, pageSize)) {
        // Doing nothing, just enumerate
        }
      }
      transaction.Commit();
      }
    }
  }
}