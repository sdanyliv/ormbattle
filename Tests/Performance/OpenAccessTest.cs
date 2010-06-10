// Copyright (C) 2009-2010 ORMBattle.NET.
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
  public class OpenAccessTest : PerformanceTestBase
  {
    private IObjectScope scope;

    public override string ToolName {
      get { return "OpenAccess"; }
    }

    public override string ShortToolName {
      get { return "OA"; }
    }

    protected override void Setup()
    {
      using (var scope = PerformanceTestContext.ObjectScope()) {
        scope.Transaction.Begin();
        scope.Remove(scope.Extent<Simplest>().ToList());
        scope.Transaction.Commit();
      }
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

    protected override void InsertMultipleTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var s = new Simplest(i, i);
        scope.Add(s);
      }
      scope.Transaction.Commit();
      InstanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var o in query)
        o.Value++;
      scope.Transaction.Commit();
    }

    protected override void DeleteMultipleTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var s in query)
        scope.Remove(s);
      scope.Transaction.Commit();
    }

    protected override void InsertSingleTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var s = new Simplest(i, i);
        scope.Add(s);
        scope.Transaction.Flush();
      }
      scope.Transaction.Commit();
      InstanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var o in query) {
        o.Value++;
        scope.Transaction.Flush();
      }
      scope.Transaction.Commit();
    }

    protected override void DeleteSingleTest()
    {
      scope.Transaction.Begin();
      var query = scope.Extent<Simplest>();
      foreach (var s in query) {
        scope.Remove(s);
        scope.Transaction.Flush();
      }
      scope.Transaction.Commit();
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = (long)i % InstanceCount;
        var classId = scope.PersistentMetaData.GetPersistentTypeDescriptor(typeof (Simplest)).ClassId;
        var objectId = Database.OID.ParseObjectId(null, classId + "-" + id);
        var s = (Simplest)scope.GetObjectById(objectId);
        sum -= s.Id;
      }
      scope.Transaction.Commit();
      if (count <= InstanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        var query = scope.Extent<Simplest>().Where(o => o.Id == id);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
      scope.Transaction.Commit();
    }

    protected override void CompiledLinqQueryTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        var query = GetSimplest(scope, id);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
      scope.Transaction.Commit();
    }

    protected override void NativeQueryTest(int count)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        var query = scope.GetOqlQuery<Simplest>("select * from SimplestExtent AS s where s.Id == $1");
        foreach (var simplest in query.ExecuteEnumerable(id)) {
          // Doing nothing, just enumerate
        }
      }
      scope.Transaction.Commit();
    }

    protected override void LinqMaterializeTest(int count)
    {
      scope.Transaction.Begin();
      int i = 0;
      while (i < count)
        foreach (var o in GetAllSimplest(scope))
          if (++i >= count)
            break;

      scope.Transaction.Commit();
    }

    protected override void NativeMaterializeTest(int count)
    {
      scope.Transaction.Begin();
      int i = 0;
      while (i < count)
        foreach (var o in scope.GetOqlQuery<Simplest>().ExecuteEnumerable())
          if (++i >= count)
            break;

      scope.Transaction.Commit();
    }

    protected override void LinqQueryPageTest(int count, int pageSize)
    {
      scope.Transaction.Begin();
      for (int i = 0; i < count; i++) {
        var id = (i*pageSize) % InstanceCount;
        var query = GetSimplestPage(scope, id, pageSize);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
      scope.Transaction.Commit();
    }

    static IQueryable GetSimplest(IObjectScope scope, long id)
    {
      var query = 
        from e in scope.Extent<Simplest>()
        where e.Id == id
        select e;
      return query;
    }

    static IQueryable GetSimplestPage(IObjectScope scope, long idFrom, int pageSize)
    {
      var query = 
        from e in scope.Extent<Simplest>()
        where e.Id >= idFrom
        select e;
      return query.Take(pageSize);
    }

    static IQueryable GetAllSimplest(IObjectScope scope)
    {
      return scope.Extent<Simplest>().Where(s => s.Id > 0);
    }
  }
}