// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.01

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using SubSonic.DataProviders;
using OrmBattle.SubsonicModel.PerformanceTest;
using SubSonic.Query;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class SubsonicTest : TestBase
  {
    private PerformanceTestDB db;
    private SimplestRepository repo;
    private SharedDbConnectionScope scope;

    protected override void SetUp()
    {
      db = new PerformanceTestDB();
      db.Provider.MigrateToDatabase<Simplest>(Assembly.GetExecutingAssembly());
      repo = new SimplestRepository(db);
      repo.DeleteMany(s => true);
      Console.Out.WriteLine("Subsonic");
    }

    protected override void TearDown()
    {
      repo.DeleteMany(s => true);
    }

    protected override void OpenSession()
    {
      scope = new SharedDbConnectionScope();
    }

    protected override void CloseSession()
    {
      scope.Dispose();
    }

    protected override void InsertMultipleTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var simplest = new Simplest {Id = i, Value = i};
        repo.Add(simplest);
      }
      instanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplest) {
        simplest.Value++;
        repo.Update(simplest);
      }
    }

    protected override void DeleteMultipleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplest) {
        repo.Delete(simplest.Id);
      }
    }

    protected override void InsertSingleTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var simplest = new Simplest {Id = i, Value = i};
        repo.Add(simplest);
      }
      instanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplest) {
        simplest.Value++;
        repo.Update(simplest);
      }
    }

    protected override void DeleteSingleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplest) {
        repo.Delete(simplest.Id);
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long) count*(count - 1)/2;
      for (int i = 0; i < count; i++) {
        var id = (long) i%instanceCount;
        var simplest = repo.GetByKey(id);
        sum -= simplest.Id;
      }
      if (count <= instanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var id = i % instanceCount;
        var query = db.Simplest.Where(o => o.Id == id);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
    }

    protected override void CompiledLinqQueryTest(int count)
    {
      Log.Error("Compiled queries are not supported.");
    }

    protected override void NativeQueryTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var id = i % instanceCount;
        var query = new Select().From("Simplest").Where("Id").IsEqualTo(id);
        foreach (var simplest in query.ExecuteTypedList<Simplest>()) {
          // Doing nothing, just enumerate
        }
      }
    }

    protected override void NativeMaterializeTest(int count)
    {
      var query = new Select().From("Simplest");
      int i = 0;
      while (i < count)
        foreach (var o in query.ExecuteTypedList<Simplest>())
          if (++i >= count)
            break;
    }

    protected override void LinqMaterializeTest(int count)
    {
      int i = 0;
      while (i < count)
        foreach (var o in db.Simplest)
          if (++i >= count)
            break;
    }
  }
}