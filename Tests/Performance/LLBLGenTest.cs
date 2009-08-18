// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.31

using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using OrmBattle.LLBLGenModel.PerformanceTest.CollectionClasses;
using OrmBattle.LLBLGenModel.PerformanceTest.EntityClasses;
using OrmBattle.LLBLGenModel.PerformanceTest.HelperClasses;
using OrmBattle.LLBLGenModel.PerformanceTest.Linq;
using NUnit.Framework;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class LLBLGenTest : TestBase
  {
    protected override void SetUp()
    {
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Clear")) {
        var simplestCollection = new SimplestCollection();
        simplestCollection.DeleteMulti();
        transaction.Commit();
      }
      Console.Out.WriteLine("LLBLGen Pro");
    }

    protected override void TearDown()
    {
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Clear")) {
        var simplestCollection = new SimplestCollection();
        simplestCollection.DeleteMulti();
        transaction.Commit();
      }
    }

    protected override void OpenSession()
    {
    }

    protected override void CloseSession()
    {
    }

    protected override void BatchInsertTest(int count)
    {
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Insert")) {
        for (int i = 0; i < count; i++) {
          var s = new SimplestEntity() {Id = i, Value = i};
          s.Save();
        }
        transaction.Commit();
      }
      instanceCount = count;
    }

    protected override void BatchUpdateTest()
    {
      long sum = (long)instanceCount * (instanceCount - 1) / 2;
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Update")) {
        var metaData = new LinqMetaData(transaction);
        foreach (var s in metaData.Simplest) {
          s.Value = s.Value + 1;
          s.Save();
          sum -= s.Id;
        }
        transaction.Commit();
      }
      Assert.AreEqual(0, sum);
    }

    protected override void BatchDeleteTest()
    {
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Delete")) {
        var metaData = new LinqMetaData(transaction);
        foreach (var s in metaData.Simplest)
          s.Delete();
        transaction.Commit();
      }
    }

    protected override void InsertTest(int count)
    {
      throw new NotImplementedException();
    }

    protected override void UpdateTest()
    {
      throw new NotImplementedException();
    }

    protected override void DeleteTest()
    {
      throw new NotImplementedException();
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Fetch")) {
        for (int i = 0; i < count; i++) {
          var id = (long)i % instanceCount;
          var o = new SimplestEntity(id);
          sum -= o.Id;
        }
        transaction.Commit();
      }
      if (count <= instanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void QueryTest(int count)
    {
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Query")) {
        var metaData = new LinqMetaData(transaction);
        for (int i = 0; i < count; i++) {
          var id = i % instanceCount;
          var query = metaData.Simplest.Where(o => o.Id == id);
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        transaction.Commit();
      }
    }

    protected override void CompiledQueryTest(int count)
    {
      Log.Error("Compiled queries are not supported.");
    }

    protected override void MaterializeTest(int count)
    {
      using (var transaction = new Transaction(IsolationLevel.ReadCommitted, "Materialize")) {
        var metaData = new LinqMetaData(transaction);
        int i = 0;
        while (i < count)
          foreach (var o in metaData.Simplest)
            if (++i >= count)
              break;
        transaction.Commit();
      }
    }
  }
}