// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.31

using System;
using System.Data;
using System.Diagnostics;
using OrmBattle.EFModel;
using NUnit.Framework;
using System.Linq;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class EFTest : TestBase
  {
    private PerformanceTestEntities dataContext;

    protected override void SetUp()
    {
      Console.Out.WriteLine("Entity Framework");
      using (var dataContext = new PerformanceTestEntities()) {
        dataContext.Connection.Open();
        using (var transaction = dataContext.Connection.BeginTransaction()) {
          foreach (var s in dataContext.Simplest)
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
          foreach (var s in dataContext.Simplest)
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

    protected override void BatchInsertTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var s = Simplest.CreateSimplest(i, i);
          dataContext.AddToSimplest(s);
        }
        dataContext.SaveChanges();
        transaction.Commit();
      }
      instanceCount = count;
    }

    protected override void BatchUpdateTest()
    {
      long sum = (long)instanceCount * (instanceCount - 1) / 2;
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        foreach (var s in dataContext.Simplest) {
          s.Value++;
          sum -= s.Id;
        }
        dataContext.SaveChanges();
        transaction.Commit();
      }
      Assert.AreEqual(0, sum);
    }

    protected override void BatchDeleteTest()
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        foreach (var s in dataContext.Simplest)
          dataContext.DeleteObject(s);
        dataContext.SaveChanges();
        transaction.Commit();
      }
    }

    protected override void InsertTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var s = Simplest.CreateSimplest(i, i);
          dataContext.AddToSimplest(s);
          dataContext.SaveChanges();
        }
        transaction.Commit();
      }
      instanceCount = count;
    }

    protected override void UpdateTest()
    {
      long sum = (long)instanceCount * (instanceCount - 1) / 2;
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        foreach (var s in dataContext.Simplest) {
          s.Value++;
          sum -= s.Id;
          dataContext.SaveChanges();
        }
        transaction.Commit();
      }
      Assert.AreEqual(0, sum);
    }

    protected override void DeleteTest()
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        foreach (var s in dataContext.Simplest) {
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
          var s = (Simplest)dataContext.GetObjectByKey(new EntityKey("PerformanceTestEntities.Simplest", "Id", (long)i % instanceCount));
          sum -= s.Id;
        }
        transaction.Commit();
      }
      
      if (count <= instanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void QueryTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var id = i % instanceCount;
          var result = dataContext.Simplest.Where(o => o.Id == id);
          foreach (var o in result) {
            // Doing nothing, just enumerate
          }
        }
        transaction.Commit();
      }
    }

    protected override void CompiledQueryTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        var resultQuery = System.Data.Objects.CompiledQuery.Compile((PerformanceTestEntities context, long id) => context.Simplest.Where(o => o.Id == id));
        for (int i = 0; i < count; i++) {
          var id = i % instanceCount;
          foreach (var o in resultQuery(dataContext, id)) {
            // Doing nothing, just enumerate
          }
        }
        dataContext.SaveChanges();
        transaction.Commit();
      }
      
    }

    protected override void MaterializeTest(int count)
    {
      using (var transaction = dataContext.Connection.BeginTransaction()) {
        int i = 0;
        while (i < count)
          foreach (var o in dataContext.Simplest) {
            if (++i >= count)
              break;
          }
        dataContext.SaveChanges();
        transaction.Commit();
      }
    }
  }
}