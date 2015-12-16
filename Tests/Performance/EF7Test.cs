// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:  2009.07.31
// Updated by: Svyatoslav Danyliv
// Created:  2015.11.19

using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Microsoft.Data.Entity;
using NUnit.Framework;
using OrmBattle.EF7Model;

namespace OrmBattle.Tests.Performance
{
    [Serializable]
    public class EF7Test : PerformanceTestBase
    {
        private PerformanceTestContext _context;

        public override string ToolName
        {
            get { return "Entity Framework 7"; }
        }

        public override string ShortToolName
        {
            get { return "EF7"; }
        }

        protected override void Setup()
        {
            using (var dataContext = new PerformanceTestContext())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    foreach (var s in dataContext.Simplests)
                        dataContext.Simplests.Remove(s);
                    dataContext.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        protected override void TearDown()
        {
            using (var dataContext = new PerformanceTestContext())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    foreach (var s in dataContext.Simplests)
                        dataContext.Simplests.Remove(s);
                    dataContext.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        protected override void OpenSession()
        {
            _context = new PerformanceTestContext();
        }

        protected override void CloseSession()
        {
            _context.Dispose();
        }

        protected override void InsertMultipleTest(int count)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                for (var i = 0; i < count; i++)
                {
                    var s = new Simplest {Id = i, Value = i};
                    _context.Simplests.Add(s);
                }
                _context.SaveChanges();
                transaction.Commit();
            }
            InstanceCount = count;
        }

        protected override void UpdateMultipleTest()
        {
            var sum = (long) InstanceCount * (InstanceCount - 1) / 2;
            using (var transaction = _context.Database.BeginTransaction())
            {
                foreach (var s in _context.Simplests)
                {
                    s.Value++;
                    sum -= s.Id;
                }
                _context.SaveChanges();
                transaction.Commit();
            }
            Assert.AreEqual(0, sum);
        }

        protected override void DeleteMultipleTest()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Simplests.RemoveRange(_context.Simplests);
                _context.SaveChanges();
                transaction.Commit();
            }
        }

        protected override void InsertSingleTest(int count)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                for (var i = 0; i < count; i++)
                {
                    var s = new Simplest {Id = i, Value = i};
                    _context.Simplests.Add(s);
                    _context.SaveChanges();
                }
                transaction.Commit();
            }
            InstanceCount = count;
        }

        protected override void UpdateSingleTest()
        {
            var sum = (long) InstanceCount * (InstanceCount - 1) / 2;
            using (var transaction = _context.Database.BeginTransaction())
            {
                foreach (var s in _context.Simplests)
                {
                    s.Value++;
                    sum -= s.Id;
                    _context.SaveChanges();
                }
                transaction.Commit();
            }
            Assert.AreEqual(0, sum);
        }

        protected override void DeleteSingleTest()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                foreach (var s in _context.Simplests)
                {
                    _context.Simplests.Remove(s);
                    _context.SaveChanges();
                }
                transaction.Commit();
            }
        }

        protected override void FetchTest(int count)
        {
            var sum = (long) count * (count - 1) / 2;
            using (var transaction = _context.Database.BeginTransaction())
            {
                for (var i = 0; i < count; i++)
                {
                    var s = _context.Simplests.FirstOrDefault(e => e.Id == (long) i % InstanceCount);
                    sum -= s.Id;
                }
                transaction.Commit();
            }

            if (count <= InstanceCount)
                Assert.AreEqual(0, sum);
        }

        protected override void LinqQueryTest(int count)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                for (var i = 0; i < count; i++)
                {
                    var id = i % InstanceCount;
                    var result = _context.Simplests.Where(o => o.Id == id);
                    foreach (var o in result)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Commit();
            }
        }

//    private static readonly Func<PerformanceTestEntities, long, IQueryable<Simplest>> _compiledQuery =
//      CompiledQuery.Compile<PerformanceTestEntities, long, IQueryable<Simplest>>((_context, id) => 
//        _context.Simplests.Where(o => o.Id==id));

        protected override void CompiledLinqQueryTest(int count)
        {
            throw new NotImplementedException();
//      using (var transaction = _context.Database.BeginTransaction()) {
//        for (int i = 0; i < count; i++) {
//          var id = i % InstanceCount;
//          foreach (var o in _compiledQuery(_context, id)) {
//            // Doing nothing, just enumerate
//          }
//        }
//        transaction.Commit();
//      }
        }

        protected override void NativeQueryTest(int count)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                for (var i = 0; i < count; i++)
                {
                    var id = i % InstanceCount;
                    var result = _context.Simplests.FromSql("select * from Simplests it where it.Id == @id",
                        new ObjectParameter("id", id));
                    foreach (var o in result)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Commit();
            }
        }

        protected override void LinqMaterializeTest(int count)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var i = 0;
                while (i < count)
                    foreach (var o in _context.Simplests.Where(s => s.Id > 0))
                    {
                        if (++i >= count)
                            break;
                    }
                transaction.Commit();
            }
        }

        protected override void NativeMaterializeTest(int count)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var i = 0;
                while (i < count)
                    foreach (var o in _context.Simplests)
                    {
                        if (++i >= count)
                            break;
                    }
                transaction.Commit();
            }
        }

//    private static readonly Func<PerformanceTestEntities, long, int, IQueryable<Simplest>> _pageQuery =
//      CompiledQuery.Compile((PerformanceTestEntities _context, long id, int pageSize) => 
//        _context.Simplests.Where(o => o.Id >= id).Take(pageSize));

        protected override void LinqQueryPageTest(int count, int pageSize)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                for (var i = 0; i < count; i++)
                {
                    var id = i * pageSize % InstanceCount;
                    var pageQuery = _context.Simplests.Where(o => o.Id >= id).Take(pageSize);
                    foreach (var o in pageQuery)
                    {
                        // Doing nothing, just enumerate
                    }
                }
                transaction.Commit();
            }
        }
    }
}