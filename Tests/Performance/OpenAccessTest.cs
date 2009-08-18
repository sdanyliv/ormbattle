// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.31

using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Query;
using OrmBattle.TelerikModel.PerformanceTest;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class OpenAccessTest : TestBase
  {
    private IObjectScope scope;

    protected override void SetUp()
    {
      using (var scope = PerformanceTestContext.ObjectScope()) {
        scope.Transaction.Begin();
        scope.Remove(scope.Extent<Simplest>().ToList());
        scope.Transaction.Commit();
      }
      Console.Out.WriteLine("OpenAccess");
    }

    protected override void TearDown()
    {
      using (var scope = PerformanceTestContext.ObjectScope()) {
        scope.Transaction.Begin();
        scope.Remove(scope.Extent<Simplest>().ToList());
        scope.Transaction.Commit();
      }
    }

    protected override void OpenSession()
    {
      scope = PerformanceTestContext.ObjectScope();
    }

    protected override void CloseSession()
    {
      scope.Dispose();
    }

    protected override void BatchInsertTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var s = new Simplest(i, i);
        scope.Add(s);
      }
      scope.Transaction.Commit();
      instanceCount = count;
    }

    protected override void BatchUpdateTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var o in query)
        o.Value++;
      scope.Transaction.Commit();
    }

    protected override void BatchDeleteTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var s in query)
        scope.Remove(s);
      scope.Transaction.Commit();
    }

    protected override void InsertTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var s = new Simplest(i, i);
        scope.Add(s);
      }
      scope.Transaction.Commit();
      instanceCount = count;
    }

    protected override void UpdateTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var o in query)
        o.Value++;
      scope.Transaction.Commit();
    }

    protected override void DeleteTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var o in query)
        scope.Remove(o);
      scope.Transaction.Commit();
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = (long)i % instanceCount;
        var classId = scope.PersistentMetaData.GetPersistentTypeDescriptor(typeof (Simplest)).ClassId;
        var objectId = Database.OID.ParseObjectId(null, classId + "-" + id);
        var s = (Simplest)scope.GetObjectById(objectId);
        sum -= s.Id;
      }
      scope.Transaction.Commit();
      if (count <= instanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void QueryTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = i % instanceCount;
        var query = scope.Extent<Simplest>().Where(o => o.Id == id);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
      scope.Transaction.Commit();
    }

    protected override void CompiledQueryTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = i % instanceCount;
        var query = GetSimplest(scope, id);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
      scope.Transaction.Commit();
    }

    protected override void MaterializeTest(int count)
    {
      scope.Transaction.Begin();
      int i = 0;
      while (i < count)
        foreach (var o in GetAllSimplest(scope))
          if (++i >= count)
            break;

      scope.Transaction.Commit();
    }

    static IQueryable GetSimplest(IObjectScope scope, long id)
    {
      var query = from e in scope.Extent<Simplest>()
                  where e.Id == id
                  select e;
      return query;
    }

    static IQueryable GetAllSimplest(IObjectScope scope)
    {
      return scope.Extent<Simplest>();
    }
  }
}