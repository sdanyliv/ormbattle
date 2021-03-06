// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.28

using System;
using System.IO;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using OrmBattle.NHibernateModel;
using NUnit.Framework;
using NHibernate.Linq;

namespace OrmBattle.Tests.Performance
{
    public class NHibernateTest : PerformanceTestBase
    {
        private ISessionFactory _factory;
        private ISession _session;

        public override string ToolName
        {
            get { return "NHibernate"; }
        }

        public override string ShortToolName
        {
            get { return "NH"; }
        }

        protected override void Setup()
        {
            var cfg = new Configuration();
            cfg.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hibernate.cfg.xml"));

            _factory = cfg.BuildSessionFactory();
            using (var session = _factory.OpenSession())
            {
                session.Delete("from Simplest");
                session.Flush();
            }
        }

        protected override void TearDown()
        {
            using (var session = _factory.OpenSession())
            {
                session.Delete("from Simplest");
                session.Flush();
            }
            _factory.Dispose();
        }

        protected override void OpenSession()
        {
            _session = _factory.OpenSession();
            _session.FlushMode = FlushMode.Never;
        }

        protected override void CloseSession()
        {
            _session.Dispose();
        }

        protected override void InsertMultipleTest(int count)
        {
            using (var statelessSession = _factory.OpenStatelessSession())
            using (var transaction = statelessSession.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var s = new Simplest(i, i);
                    statelessSession.Insert(s);
                }
                transaction.Commit();
            }
            InstanceCount = count;
        }

        protected override void UpdateMultipleTest()
        {
            using (var statelessSession = _factory.OpenStatelessSession())
            using (var transaction = statelessSession.BeginTransaction())
            {
                var query = statelessSession.CreateQuery("from Simplest").List<Simplest>();
                foreach (var o in query)
                {
                    o.Value++;
                    statelessSession.Update(o);
                }
                transaction.Commit();
            }
        }

        protected override void DeleteMultipleTest()
        {
            using (var statelessSession = _factory.OpenStatelessSession())
            using (var transaction = statelessSession.BeginTransaction())
            {
                var query = statelessSession.CreateQuery("from Simplest").List<Simplest>();
                foreach (var o in query)
                    statelessSession.Delete(o);
                transaction.Commit();
            }
        }

        protected override void InsertSingleTest(int count)
        {
            using (var insertSession = _factory.OpenSession())
            using (var transaction = insertSession.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var s = new Simplest(i, i);
                    insertSession.Save(s);
                    insertSession.Flush();
                    insertSession.Clear();
                }
                transaction.Commit();
            }
            InstanceCount = count;
        }

        protected override void UpdateSingleTest()
        {
            using (var updateSession = _factory.OpenSession())
            using (var transaction = updateSession.BeginTransaction())
            {
                var query = updateSession.CreateQuery("from Simplest").List<Simplest>();
                foreach (var o in query)
                {
                    o.Value++;
                    updateSession.Update(o);
                    updateSession.Flush();
                    // updateSession.Clear();
                }
                transaction.Commit();
            }
        }

        protected override void DeleteSingleTest()
        {
            using (var deleteSession = _factory.OpenSession())
            using (var transaction = deleteSession.BeginTransaction())
            {
                var query = deleteSession.CreateQuery("from Simplest").List<Simplest>();
                foreach (var o in query)
                {
                    o.Value++;
                    deleteSession.Delete(o);
                    deleteSession.Flush();
                    // deleteSession.Clear();
                }
                transaction.Commit();
            }
        }

        protected override void FetchTest(int count)
        {
            long sum = (long) count * (count - 1) / 2;
            using (var transaction = _session.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var key = (long) i % InstanceCount;
                    var o = _session.Get<Simplest>(key);
                    sum -= o.Id;
                }
                transaction.Rollback(); // avoiding dirty checking
            }
            if (count <= InstanceCount)
                Assert.AreEqual(0, sum);
        }

        protected override void LinqQueryTest(int count)
        {
            using (var transaction = _session.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var id = i % InstanceCount;
                    var query = _session.Query<Simplest>().Where(s => s.Id == id);
                    foreach (var simplest in query)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Rollback(); // avoiding dirty checking
            }
        }

        protected override void CompiledLinqQueryTest(int count)
        {
            throw new NotSupportedException();
        }

        protected override void NativeQueryTest(int count)
        {
            using (var transaction = _session.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var id = i % InstanceCount;
                    var query = _session.CreateCriteria<Simplest>()
                        .Add(Expression.Eq("Id", (long) id));
                    foreach (var simplest in query.List())
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Rollback(); // avoiding dirty checking
            }
        }

        protected override void LinqMaterializeTest(int count)
        {
            int i = 0;
            using (var transaction = _session.BeginTransaction())
            {
                while (i < count)
                    foreach (var o in _session.Query<Simplest>().Where(s => s.Id > 0))
                    {
                        if (++i >= count)
                            break;
                    }
                transaction.Rollback(); // avoiding dirty checking
            }
        }

        protected override void NativeMaterializeTest(int count)
        {
            int i = 0;
            using (var transaction = _session.BeginTransaction())
            {
                while (i < count)
                    foreach (var o in _session.CreateCriteria<Simplest>().List())
                    {
                        if (++i >= count)
                            break;
                    }
                transaction.Rollback(); // avoiding dirty checking
            }
        }

        protected override void LinqQueryPageTest(int count, int pageSize)
        {
            using (var transaction = _session.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var id = (i * pageSize) % InstanceCount;
                    var query = _session.Query<Simplest>().Where(s => s.Id >= id).Take(pageSize);
                    foreach (var simplest in query)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Rollback(); // avoiding dirty checking
            }
        }
    }
}