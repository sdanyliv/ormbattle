// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.31

using System;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using NUnit.Framework;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Query;
using OrmBattle.TelerikModel.PerformanceTest;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class OpenAccessTest : PerformanceTestBase
  {
    private PerformanceTest context;

    public override string ToolName {
      get { return "OpenAccess"; }
    }

    public override string ShortToolName {
      get { return "OA"; }
    }

    protected override void Setup()
    {
      var db = new PerformanceTest();
      using (var ts = new TransactionScope()) {
        db.Delete(db.Simplests);
        db.SaveChanges();
        ts.Complete();
      }
    }

    protected override void TearDown()
    {
      var db = new PerformanceTest();
      using (var ts = new TransactionScope()) {
        db.Delete(db.Simplests);
        db.SaveChanges();
        ts.Complete();
      }
    }

    [Test]
    public void SomeTest()
    {
      Execute();
    }

    protected override void OpenSession()
    {
      context = new PerformanceTest();
    }

    protected override void CloseSession()
    {
      context.Dispose();
    }

    protected override void InsertMultipleTest(int count)
    {
      using (var ts = new TransactionScope()) {
        for (int i = 0; i < count; i++) {
          var s = new Simplest {Id = i, Value = i};
          context.Add(s);
        }
        context.SaveChanges();
        ts.Complete();
      }
      InstanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      using (var ts = new TransactionScope()) {
        var query = context.Simplests;
        foreach (var o in query)
          o.Value++;
        context.SaveChanges();
        ts.Complete();
      }
    }

    protected override void DeleteMultipleTest()
    {
      using (var ts = new TransactionScope()) {
        var query = context.Simplests;
        foreach (var s in query)
          context.Delete(s);
        context.SaveChanges();
        ts.Complete();
      }
    }

    protected override void InsertSingleTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var s = new Simplest {Id = i, Value = i};
        context.Add(s);
        context.SaveChanges();
      }
      InstanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      var query = context.Simplests;
      foreach (var o in query) {
        o.Value++;
        context.SaveChanges();
      }
    }

    protected override void DeleteSingleTest()
    {
      var query = context.Simplests;
      foreach (var s in query) {
        context.Delete(s);
        context.SaveChanges();
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      var scope = context.GetScope();
      var classId = scope.PersistentMetaData.GetPersistentTypeDescriptor(typeof(Simplest)).ClassId;
      using (var ts = new TransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = (long) i%InstanceCount;
          var objectId = Database.OID.ParseObjectId(null, classId + "-" + id);
          var s = (Simplest) scope.GetObjectById(objectId);
          sum -= s.Id;
        }
        ts.Complete();
      }
      if (count <= InstanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      using (var ts = new TransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = i%InstanceCount;
          var query = context.Simplests.Where(o => o.Id == id);
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    protected override void CompiledLinqQueryTest(int count)
    {
      using (var ts = new TransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = i%InstanceCount;
          var query = GetSimplest(context, id); 
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    protected override void NativeQueryTest(int count)
    {
      using (var ts = new TransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = i%InstanceCount;
          var query = context.GetScope().GetOqlQuery<Simplest>("select * from SimplestExtent AS s where s.Id == $1");
          foreach (var simplest in query.ExecuteEnumerable(id)) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    protected override void LinqMaterializeTest(int count)
    {
      using (var ts = new TransactionScope()) {
        int i = 0;
        while (i < count)
          foreach (var o in GetAllSimplest(context))
            if (++i >= count)
              break;
        ts.Complete();
      }
    }

    protected override void NativeMaterializeTest(int count)
    {
      using (var ts = new TransactionScope()) {
        var scope = context.GetScope();
        int i = 0;
        while (i < count)
          foreach (var o in scope.GetOqlQuery<Simplest>().ExecuteEnumerable())
            if (++i >= count)
              break;
        ts.Complete();
      }
    }

    protected override void LinqQueryPageTest(int count, int pageSize)
    {
      using (var ts = new TransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = (i*pageSize)%InstanceCount;
          var query = GetSimplestPage(context, id, pageSize);
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    static IQueryable GetSimplest(PerformanceTest context, long id)
    {
      var query = 
        from e in context.Simplests
        where e.Id == id
        select e;
      return query;
    }

    static IQueryable GetSimplestPage(PerformanceTest context, long idFrom, int pageSize)
    {
      var query = 
        from e in context.Simplests
        where e.Id >= idFrom
        select e;
      return query.Take(pageSize);
    }

    static IQueryable GetAllSimplest(PerformanceTest context)
    {
      return context.Simplests.Where(s => s.Id > 0);
    }
  }
}