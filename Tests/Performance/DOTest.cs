// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.29

using System.Linq;
using OrmBattle.DOModel;
using NUnit.Framework;
using Xtensive.Core;
using Xtensive.Disposing;
using Xtensive.Orm;
using Xtensive.Orm.Configuration;
using Xtensive.Storage.Rse;
using Xtensive.Orm.Linq;

namespace OrmBattle.Tests.Performance
{
  public class DOTest : PerformanceTestBase
  {
    private Domain domain;
    private Session session;

    public override string ToolName {
      get { return "DataObjects.Net"; }
    }

    public override string ShortToolName {
      get { return "DO"; }
    }

    protected override void Setup()
    {
      var config = DomainConfiguration.Load("mssql2005");
      config.Sessions.Add(new SessionConfiguration("Default"));
      // config.Sessions.Default.CacheType = SessionCacheType.LruWeak;
      config.Sessions.Default.CacheType = SessionCacheType.Infinite;
      config.Types.Register(typeof(Simplest).Assembly, typeof(Simplest).Namespace);
      domain = Domain.Build(config);
      using (var session = domain.OpenSession())
      using (var ts = session.OpenTransaction()) {
        var query = session.Query.Execute(qe => qe.All<Simplest>());
        foreach (var o in query)
          o.Remove();
        ts.Complete();
      }
    }

    protected override void TearDown()
    {
      using (var session = domain.OpenSession())
      using (var ts = session.OpenTransaction()) {
        var query = session.Query.Execute(qe => qe.All<Simplest>());
        foreach (var o in query)
          o.Remove();
        ts.Complete();
      }
      domain.DisposeSafely();
    }

    protected override void OpenSession()
    {
      session = domain.OpenSession();
    }

    protected override void CloseSession()
    {
      session.DisposeSafely();
    }

    protected override void InsertMultipleTest(int count)
    {
      using (var ts = session.OpenTransaction()) {
        for (int i = 0; i < count; i++)
          new Simplest(session, i, i);
        ts.Complete();
      }
      InstanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      using (var ts = session.OpenTransaction()) {
        var query = session.Query.Execute(qe => qe.All<Simplest>());
        foreach (var o in query)
          o.Value++;
        ts.Complete();
      }
    }

    protected override void DeleteMultipleTest()
    {
      using (var ts = session.OpenTransaction()) {
        var query = session.Query.Execute(qe => qe.All<Simplest>());
        foreach (var o in query)
          o.Remove();
        ts.Complete();
      }
    }

    protected override void InsertSingleTest(int count)
    {
      using (var ts = session.OpenTransaction()) {
        for (int i = 0; i < count; i++) {
          new Simplest(session, i, i);
          session.SaveChanges();
        }
        ts.Complete();
      }
      InstanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      using (var ts = session.OpenTransaction()) {
        var query = session.Query.Execute(qe => qe.All<Simplest>());
        foreach (var o in query) {
          o.Value++;
          session.SaveChanges();
        }
        ts.Complete();
      }
    }

    protected override void DeleteSingleTest()
    {
      using (var ts = session.OpenTransaction()) {
        var query = session.Query.Execute(qe => qe.All<Simplest>());
        foreach (var o in query) {
          o.Remove();
          session.SaveChanges();
        }
        ts.Complete();
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      using (var ts = session.OpenTransaction()) {
        for (int i = 0; i < count; i++) {
          var id = (long) i % InstanceCount;
          var o = session.Query.SingleOrDefault<Simplest>(id);
          sum -= o.Id;
        }
        ts.Complete();
      }
      if (count <= InstanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      using (var ts = session.OpenTransaction()) {
        for (int i = 0; i < count; i++) {
          var id = i%InstanceCount;
          var query = session.Query.All<Simplest>().Where(o => o.Id == id);
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    protected override void CompiledLinqQueryTest(int count)
    {
      using (var ts = session.OpenTransaction()) {
        for (int i = 0; i < count; i++) {
          var id = i % InstanceCount;
          var query = session.Query.Execute(qe => qe.All<Simplest>().Where(o => o.Id == id));
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    protected override void NativeQueryTest(int count)
    {
      var primaryIndex = session.Domain.Model.Types[typeof(Simplest)].Indexes.PrimaryIndex;
      long id = 0;
      var recordQuery = primaryIndex.ToRecordQuery().Filter(t => t.GetValueOrDefault<long>(0) == id);
      using (var ts = session.OpenTransaction()) {
        for (int i = 0; i < count; i++) {
          id = i % InstanceCount;
          foreach (var simplest in recordQuery.ToRecordSet(session).ToEntities<Simplest>(0)) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    protected override void LinqMaterializeTest(int count)
    {
      using (var ts = session.OpenTransaction()) {
        int i = 0;
        while (i < count)
          foreach (var o in session.Query.Execute(qe => qe.All<Simplest>().Where(s => s.Id > 0)))
            if (++i >= count)
              break;
        ts.Complete();
      }
    }

    protected override void NativeMaterializeTest(int count)
    {
      var primaryIndex = session.Domain.Model.Types[typeof(Simplest)].Indexes.PrimaryIndex;
      var simplests = primaryIndex.ToRecordQuery().ToRecordSet(session).ToEntities<Simplest>(0);
      using (var ts = session.OpenTransaction()) {
        int i = 0;
        while (i < count) {
          foreach (var o in simplests)
            if (++i >= count)
              break;
        }
        ts.Complete();
      }
    }

    protected override void LinqQueryPageTest(int count, int pageSize)
    {
      var cacheKey = "LinqQueryPageTest.Query-" + pageSize.ToString();
      using (var ts = session.OpenTransaction()) {
        for (int i = 0; i < count; i++) {
          var id = (i*pageSize) % InstanceCount;
          var localPageSize = pageSize;
          var query = session.Query.Execute(cacheKey, qe => 
            qe.All<Simplest>().Where(o => o.Id >= id).Take(() => localPageSize));
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }
  }
}