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
  public class SubsonicTest : PerformanceTestBase
  {
    private PerformanceTestDB db;
    private SimplestRepository repo;
    private SharedDbConnectionScope scope;

    public override string ToolName {
      get { return "Subsonic"; }
    }

    public override string ShortToolName {
      get { return "SS"; }
    }

    protected override void Setup()
    {
      db = new PerformanceTestDB();
      repo = new SimplestRepository(db);
      repo.DeleteMany(s => true);
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
      InstanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplests) {
        simplest.Value++;
        repo.Update(simplest);
      }
    }

    protected override void DeleteMultipleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplests) {
        repo.Delete(simplest.Id);
      }
    }

    protected override void InsertSingleTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var simplest = new Simplest {Id = i, Value = i};
        repo.Add(simplest);
      }
      InstanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplests) {
        simplest.Value++;
        repo.Update(simplest);
      }
    }

    protected override void DeleteSingleTest()
    {
      var i = 0;
      foreach (var simplest in db.Simplests) {
        repo.Delete(simplest.Id);
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long) count*(count - 1)/2;
      for (int i = 0; i < count; i++) {
        var id = (long) i%InstanceCount;
        var simplest = repo.GetByKey(id);
        sum -= simplest.Id;
      }
      if (count <= InstanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        var query = db.Simplests.Where(o => o.Id == id);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
    }

    protected override void CompiledLinqQueryTest(int count)
    {
      throw new NotSupportedException();
    }

    protected override void NativeQueryTest(int count)
    {
      for (int i = 0; i < count; i++) {
        var id = i % InstanceCount;
        var query = new Select().From("Simplests").Where("Id").IsEqualTo(id);
        foreach (var simplest in query.ExecuteTypedList<Simplest>()) {
          // Doing nothing, just enumerate
        }
      }
    }

    protected override void NativeMaterializeTest(int count)
    {
      var query = new Select().From("Simplests");
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
        foreach (var o in db.Simplests)
          if (++i >= count)
            break;
    }

    protected override void LinqQueryPageTest(int count, int pageSize)
    {
      for (int i = 0; i < count; i++) {
        var id = (i*pageSize) % InstanceCount;
        var query = db.Simplests.Where(o => o.Id >= id).Take(pageSize);
        foreach (var simplest in query) {
          // Doing nothing, just enumerate
        }
      }
    }
  }
}