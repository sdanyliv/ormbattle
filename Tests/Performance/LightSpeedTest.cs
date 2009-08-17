// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.01

using System;
using System.Diagnostics;
using System.Linq;
using LightSpeedModel;
using Mindscape.LightSpeed;
using NUnit.Framework;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class LightSpeedTest : TestBase
  {
    private LightSpeedContext<PerformanceTestUnitOfWork> context;
    private long minId;
    private long maxId;
    private PerformanceTestUnitOfWork db;

    protected override void SetUp()
    {
      context = new LightSpeedContext<PerformanceTestUnitOfWork>("PerformanceTest");
      using (var db = context.CreateUnitOfWork())
      using (var transaction = db.BeginTransaction()) {
        foreach (var s in db.Simplests)
          db.Remove(s);
        db.SaveChanges();
        transaction.Commit();
      }
      Console.Out.WriteLine("LightSpeed");
    }

    protected override void TearDown()
    {
      using (var db = context.CreateUnitOfWork())
      using (var transaction = db.BeginTransaction()) {
        foreach (var s in db.Simplests)
          db.Remove(s);
        db.SaveChanges();
        transaction.Commit();
      }
    }

    protected override void OpenSession()
    {
      db = context.CreateUnitOfWork();
    }

    protected override void CloseSession()
    {
      db.Dispose();
    }

    protected override void InsertTest(int count)
    {
      Simplest min = null;
      Simplest max = null;
      using (var transaction = db.BeginTransaction()) {
        for (int i = 0; i < count - 1; i++) {
          var simplest = new Simplest {Value = i};
          db.Add(simplest);
          if (min == null)
            min = simplest;
        }
        max = new Simplest {Value = count - 1};
        db.Add(max);
        db.SaveChanges();
        transaction.Commit();
      }
      instanceCount = count;
      minId = min.Id;
      maxId = max.Id;
    }

    protected override void UpdateTest()
    {
      using (var transaction = db.BeginTransaction()) {
        foreach (var s in db.Simplests) {
          s.Value++;
        }
        db.SaveChanges();
        transaction.Commit();
      }
    }

    protected override void DeleteTest()
    {
      using (var transaction = db.BeginTransaction()) {
        foreach (var s in db.Simplests)
          db.Remove(s);
        db.SaveChanges();
        transaction.Commit();
      }
    }

    protected override void FetchTest(int count)
    {
      var ids = Enumerable.Range((int) minId, (int) (maxId - minId));
      using (var transaction = db.BeginTransaction()) {
        foreach (var id in ids) {
          var o = db.FindOne<Simplest>(id);
        }
        transaction.Commit();
      }
    }

    protected override void QueryTest(int count)
    {
      var ids = Enumerable.Range((int)minId, (int)(maxId - minId));
      using (var transaction = db.BeginTransaction()) {
        foreach (var i in ids) {
          int id = i;
          var query = db.Simplests.Where(o => o.Id == id);
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
      using (var transaction = db.BeginTransaction()) {
        int i = 0;
        while (i < count)
          foreach (var o in db.Simplests) {
            if (++i >= count)
              break;
          }
        transaction.Commit();
      }
    }
  }
}