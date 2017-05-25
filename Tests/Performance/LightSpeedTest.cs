// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.01

using System;
using System.Diagnostics;
using System.Linq;
using LightSpeedModel;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Querying;
using NUnit.Framework;

namespace OrmBattle.Tests.Performance
{
    [Serializable]
    public class LightSpeedTest : PerformanceTestBase
    {
        private LightSpeedContext<PerformanceTestUnitOfWork> context;
        private long minId;
        private long maxId;
        private PerformanceTestUnitOfWork db;

        public override string ToolName
        {
            get { return "LightSpeed"; }
        }

        public override string ShortToolName
        {
            get { return "LS"; }
        }

        protected override void Setup()
        {
            context = new LightSpeedContext<PerformanceTestUnitOfWork>("PerformanceTest");
            using (var db = context.CreateUnitOfWork())
            using (var transaction = db.BeginTransaction())
            {
                foreach (var s in db.Simplests)
                    db.Remove(s);
                db.SaveChanges();
                transaction.Commit();
            }
        }

        protected override void TearDown()
        {
            using (var db = context.CreateUnitOfWork())
            using (var transaction = db.BeginTransaction())
            {
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

        protected override void InsertMultipleTest(int count)
        {
            Simplest min = null;
            Simplest max = null;
            using (var transaction = db.BeginTransaction())
            {
                for (int i = 0; i < count - 1; i++)
                {
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
            InstanceCount = count;
            minId = min.Id;
            maxId = max.Id;
        }

        protected override void UpdateMultipleTest()
        {
            using (var transaction = db.BeginTransaction())
            {
                foreach (var s in db.Simplests)
                {
                    s.Value++;
                }
                db.SaveChanges();
                transaction.Commit();
            }
        }

        protected override void DeleteMultipleTest()
        {
            using (var transaction = db.BeginTransaction())
            {
                foreach (var s in db.Simplests)
                    db.Remove(s);
                db.SaveChanges();
                transaction.Commit();
            }
        }

        protected override void InsertSingleTest(int count)
        {
            Simplest min = null;
            Simplest max = null;
            using (var transaction = db.BeginTransaction())
            {
                for (int i = 0; i < count - 1; i++)
                {
                    var simplest = new Simplest {Value = i};
                    db.Add(simplest);
                    db.SaveChanges();
                    if (min == null)
                        min = simplest;
                }
                max = new Simplest {Value = count - 1};
                db.Add(max);
                db.SaveChanges();
                transaction.Commit();
            }
            InstanceCount = count;
            minId = min.Id;
            maxId = max.Id;
        }

        protected override void UpdateSingleTest()
        {
            using (var transaction = db.BeginTransaction())
            {
                foreach (var s in db.Simplests)
                {
                    s.Value++;
                    db.SaveChanges();
                }
                transaction.Commit();
            }
        }

        protected override void DeleteSingleTest()
        {
            using (var transaction = db.BeginTransaction())
            {
                foreach (var s in db.Simplests)
                {
                    db.Remove(s);
                    db.SaveChanges();
                }
                transaction.Commit();
            }
        }

        protected override void FetchTest(int count)
        {
            using (var transaction = db.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var id = minId + i % InstanceCount;
                    var o = db.FindById<Simplest>(id);
                }
                transaction.Commit();
            }
        }

        protected override void LinqQueryTest(int count)
        {
            using (var transaction = db.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var id = minId + i % InstanceCount;
                    var query = db.Simplests.Where(o => o.Id == id);
                    foreach (var simplest in query)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Commit();
            }
        }

        protected override void CompiledLinqQueryTest(int count)
        {
            throw new NotSupportedException();
        }

        protected override void NativeQueryTest(int count)
        {
            using (var transaction = db.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var id = minId + i % InstanceCount;
                    var query = db.Find<Simplest>(Entity.Attribute("id") == id);
                    foreach (var simplest in query)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Commit();
            }
        }

        protected override void NativeMaterializeTest(int count)
        {
            var query = db.Find<Simplest>();
            using (var transaction = db.BeginTransaction())
            {
                int i = 0;
                while (i < count)
                    foreach (var o in query)
                    {
                        if (++i >= count)
                            break;
                    }
                transaction.Commit();
            }
        }

        protected override void LinqMaterializeTest(int count)
        {
            using (var transaction = db.BeginTransaction())
            {
                int i = 0;
                while (i < count)
                    foreach (var o in db.Simplests.Where(s => s.Id > 0))
                    {
                        if (++i >= count)
                            break;
                    }
                transaction.Commit();
            }
        }

        protected override void LinqQueryPageTest(int count, int pageSize)
        {
            using (var transaction = db.BeginTransaction())
            {
                for (int i = 0; i < count; i++)
                {
                    var id = minId + (i * pageSize) % InstanceCount;
                    var query = db.Simplests.Where(o => o.Id >= id).Take(pageSize);
                    foreach (var simplest in query)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Commit();
            }
        }
    }
}