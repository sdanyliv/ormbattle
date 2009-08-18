// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.28

using System;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using OrmBattle.NHibernateModel;
using NUnit.Framework;
using NHibernate.Linq;

namespace OrmBattle.Tests.Performance
{
  public class NHibernateTest : TestBase
  {
    private ISessionFactory factory;
    private ISession session;

    protected override void SetUp()
    {
      Configuration cfg = new Configuration().Configure();
      factory = cfg.BuildSessionFactory();
      using(var session = factory.OpenSession()) {
        session.Delete("from Simplest");
        session.Flush();
      }
      Console.Out.WriteLine("NHibernate");
    }

    protected override void TearDown()
    {
      using(var session = factory.OpenSession()) {
        session.Delete("from Simplest");
        session.Flush();
      }
      factory.Dispose();
    }

    protected override void OpenSession()
    {
      session = factory.OpenSession();
      session.FlushMode = FlushMode.Commit;
    }

    protected override void CloseSession()
    {
      session.Dispose();
    }

    protected override void BatchInsertTest(int count)
    {
      using (var transaction = session.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var s = new Simplest(i, i);
          session.Save(s);
          if (i % 25 == 0) { 
            // 25, same as the ADO batch size.
            // Flushes the batch of inserts and releases memory.
            session.Flush();
            session.Clear();
          }
        }
        transaction.Commit();
      }
      instanceCount = count;
    }

    protected override void BatchUpdateTest()
    {
      using (var statelessSession = factory.OpenStatelessSession())
      using (var transaction = statelessSession.BeginTransaction()) {
        var query = statelessSession.CreateQuery("from Simplest").List<Simplest>();
        foreach (var o in query) {
          o.Value++;
          statelessSession.Update(o);
        }
        transaction.Commit();
      }
    }

    protected override void BatchDeleteTest()
    {
      using (var statelessSession = factory.OpenStatelessSession())
      using (var transaction = statelessSession.BeginTransaction()) {
        var query = statelessSession.CreateQuery("from Simplest").List<Simplest>();
        foreach (var o in query)
          statelessSession.Delete(o);
        transaction.Commit();
      }
    }

    protected override void InsertTest(int count)
    {
      using (var insertSession = factory.OpenSession())
      using (var transaction = insertSession.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var s = new Simplest(i, i);
          insertSession.Save(s);
        }
        transaction.Commit();
      }
      instanceCount = count;
    }

    protected override void UpdateTest()
    {
      using (var updateSession = factory.OpenSession())
      using (var transaction = updateSession.BeginTransaction()) {
        var query = updateSession.CreateQuery("from Simplest").List<Simplest>();
        foreach (var o in query) {
          o.Value++;
          updateSession.Update(o);
        }
        transaction.Commit();
      }
    }

    protected override void DeleteTest()
    {
      using (var deleteSession = factory.OpenSession())
      using (var transaction = deleteSession.BeginTransaction()) {
        var query = deleteSession.CreateQuery("from Simplest").List<Simplest>();
        foreach (var o in query) {
          o.Value++;
          deleteSession.Delete(o);
        }
        transaction.Commit();
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      using (var transaction = session.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var key = (long) i%instanceCount;
          var o = session.Get<Simplest>(key);
          sum -= o.Id;
        }
        transaction.Commit();
      }
      if (count <= instanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void QueryTest(int count)
    {
      using (var transaction = session.BeginTransaction()) {
        for (int i = 0; i < count; i++) {
          var id = i%instanceCount;
          var query = session.Linq<Simplest>().Where(s => s.Id == id);
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
      int i = 0;
      using (var transaction = session.BeginTransaction()) {
        while (i < count)
          foreach (var o in session.Linq<Simplest>()) {
            if (++i >= count)
              break;
          }
        transaction.Commit();
      }
    }
  }
}