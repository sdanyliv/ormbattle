// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.10.27

using System;
using System.Data.Linq;
using System.Linq;
using EntitySpaces.Interfaces;
using Linq2SqlModel;
using NUnit.Framework;
using OrmBattle.EntitySpacesModel;

namespace OrmBattle.Tests.Performance
{
  public class EntitySpacesTest : PerformanceTestBase
  {
    private PerformanceTestDataContext _db;

    public override string ToolName
    {
      get { return "EntitySpaces"; }
    }

    public override string ShortToolName
    {
      get { return "ES"; }
    }

    protected override void Setup()
    {
      var conn = new esConnectionElement();
      conn.ConnectionString = @"Data Source=.;Initial Catalog=PerformanceTest;Integrated Security=True;Pooling=True;MultipleActiveResultSets = true";
      conn.Name = "PerformanceTest";
      conn.Provider = "EntitySpaces.SqlClientProvider";
      conn.ProviderClass = "DataProvider";
      conn.SqlAccessType = esSqlAccessType.DynamicSQL;
      conn.ProviderMetadataKey = "esDefault";
      conn.DatabaseVersion = "2005";

      esConfigSettings.ConnectionInfo.Connections.Add(conn);
      esConfigSettings.ConnectionInfo.Default = "PerformanceTest";

      esProviderFactory.Factory = new EntitySpaces.LoaderMT.esDataProviderFactory();
      var simplests = new SimplestsCollection();
      simplests.LoadAll();
      simplests.MarkAllAsDeleted();
      simplests.Save();
    }

    protected override void TearDown()
    {
      var simplests = new SimplestsCollection();
      simplests.LoadAll();
      simplests.MarkAllAsDeleted();
      simplests.Save();
    }

    protected override void OpenSession()
    {
      _db = new PerformanceTestDataContext();
      _db.Connection.Open();
    }

    protected override void CloseSession()
    {
      _db.Dispose();
    }

    protected override void InsertMultipleTest(int count)
    {
      var simplests = new SimplestsCollection();
      for (int i = 0; i < count; i++) {
        var simplest = simplests.AddNew();
        simplest.Id = i;
        simplest.Value = i;
      }
      simplests.Save();
      InstanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      var simplests = new SimplestsCollection();
      simplests.LoadAll();
      foreach (var o in simplests)
        o.Value++;
      simplests.Save();
    }

    protected override void DeleteMultipleTest()
    {
      var simplests = new SimplestsCollection();
      simplests.LoadAll();
      simplests.MarkAllAsDeleted();
      simplests.Save();
    }

    protected override void InsertSingleTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestsCollection();
        for (int i = 0; i < count; i++) {
          var simplest = simplests.AddNew();
          simplest.Id = i;
          simplest.Value = i;
          simplests.Save();
        }
        ts.Complete();
      }
      InstanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestsCollection();
        simplests.LoadAll();
        foreach (var o in simplests) {
          o.Value++;
          simplests.Save();
        }
        ts.Complete();
      }
    }

    protected override void DeleteSingleTest()
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestsCollection();
        simplests.LoadAll();
        foreach (var o in simplests) {
          o.MarkAsDeleted();
          simplests.Save();
        }
        ts.Complete();
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long) count*(count - 1)/2;
      using (var ts = new esTransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = (long) i%InstanceCount;
          var simplest = new Simplests();
          simplest.LoadByPrimaryKey(id);
          sum -= simplest.Id.Value;
        }
        ts.Complete();
      }
      if (count <= InstanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = i%InstanceCount;
          var query = new SimplestsCollection();
          query.Load(_db, _db.GetTable<Simplests>().Where(o => o.Id == id));
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    private static readonly Func<PerformanceTestDataContext, long, IQueryable<Simplests>> _compiledQuery =
      CompiledQuery.Compile(
        (PerformanceTestDataContext context, long id) => context.GetTable<Simplests>().Where(o => o.Id == id));


    protected override void CompiledLinqQueryTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = i%InstanceCount;
          var query = new SimplestsCollection();
          query.Load(_db, _compiledQuery(_db, id));
          foreach (var simplest in query) {
            // Doing nothing, just enumerate
          }
        }
        ts.Complete();
      }
    }

    protected override void NativeQueryTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        for (int i = 0; i < count; i++) {
          var simplests = new SimplestsCollection();
          var id = i%InstanceCount;
          simplests.Query.Where(simplests.Query.Id == id);
          if (simplests.Query.Load())
            foreach (var simplest in simplests) {
              // Doing nothing, just enumerate
            }
        }
        ts.Complete();
      }
    }

    protected override void LinqMaterializeTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestsCollection();
        int i = 0;
        while (i < count) {
          simplests.Load(_db, _db.GetTable<Simplests>().Where(o => o.Id > 0));
          foreach (var o in simplests)
            if (++i >= count)
              break;
        }
        ts.Complete();
      }
    }

    protected override void NativeMaterializeTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestsCollection();
        int i = 0;
        while (i < count) {
          simplests.LoadAll();
          foreach (var o in simplests)
            if (++i >= count)
              break;
        }
        ts.Complete();
      }
    }

    static readonly Func<PerformanceTestDataContext, long, int, IQueryable<Simplests>> _pageQuery = CompiledQuery.Compile(
      (PerformanceTestDataContext context, long id, int pgSize) => context.GetTable<Simplests>().Where(o => o.Id >= id).Take(pgSize));

    protected override void LinqQueryPageTest(int count, int pageSize)
    {
      using (var ts = new esTransactionScope()) {
        for (var i = 0; i < count; i++) {
          var id = (i * pageSize) % InstanceCount;
          var simplests = new SimplestsCollection();
          simplests.Load(_db, _pageQuery(_db, id, pageSize));
          foreach (var o in simplests) {
            // Doing nothing, just enumerate
          }
        }

        ts.Complete();
      }
    }
  }
}