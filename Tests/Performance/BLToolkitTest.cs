using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BLToolkit.Data.Linq;
using NUnit.Framework;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace OrmBattle.Tests.Performance
{
    using BLToolkitModel;

    [Serializable]
    public class BLToolkitTest : PerformanceTestBase
    {
        DbManager _db;
        SqlQuery<Simplests> _query;

        public override string ToolName
        {
            get { return "BLToolkit"; }
        }

        public override string ShortToolName
        {
            get { return "BLT"; }
        }

        protected override void Setup()
        {
            using (var dbManager = new DbManager("PerformanceTest"))
                dbManager
                    .SetCommand("TRUNCATE TABLE Simplests")
                    .ExecuteNonQuery();
        }

        protected override void TearDown()
        {
            using (var dbManager = new DbManager("PerformanceTest"))
                dbManager
                    .SetCommand("TRUNCATE TABLE Simplests")
                    .ExecuteNonQuery();
        }

        protected override void OpenSession()
        {
            DbManager.DefaultConfiguration = "PerformanceTest";
            _db = new DbManager("PerformanceTest");
            _query = new SqlQuery<Simplests>();
        }

        protected override void CloseSession()
        {
            _db.Dispose();
        }

        static IEnumerable<Simplests> CreateNewSimplests(int count)
        {
            for (var i = 0; i < count; i++)
                yield return new Simplests {Id = i, Value = i};
        }

        protected override void InsertMultipleTest(int count)
        {
            _db.BeginTransaction();
            InstanceCount = _query.Insert(_db, 25, CreateNewSimplests(count));
            _db.CommitTransaction();
        }

        protected override void UpdateMultipleTest()
        {
            long sum = (long) InstanceCount * (InstanceCount - 1) / 2;

            _db.BeginTransaction();

            var list = _query.SelectAll(_db);

            foreach (var s in list)
            {
                s.Value++;
                sum -= s.Id;
            }

            _query.Update(_db, 25, list);

            _db.CommitTransaction();

            Assert.AreEqual(0, sum);
        }

        protected override void DeleteMultipleTest()
        {
            _db.BeginTransaction();
            _query.Delete(_db, 25, _query.SelectAll(_db));
            _db.CommitTransaction();
        }

        protected override void InsertSingleTest(int count)
        {
            _db.BeginTransaction();

            for (var i = 0; i < count; i++)
                _query.Insert(_db, new Simplests {Id = i, Value = i});

            _db.CommitTransaction();

            InstanceCount = count;
        }

        protected override void UpdateSingleTest()
        {
            long sum = (long) InstanceCount * (InstanceCount - 1) / 2;

            _db.BeginTransaction();

            foreach (var s in _query.SelectAll(_db))
            {
                s.Value++;
                sum -= s.Id;

                _query.Update(_db, s);
            }

            _db.CommitTransaction();

            Assert.AreEqual(0, sum);
        }

        protected override void DeleteSingleTest()
        {
            _db.BeginTransaction();

            foreach (var s in _query.SelectAll(_db))
                _query.Delete(_db, s);

            _db.CommitTransaction();
        }

        protected override void FetchTest(int count)
        {
            long sum = (long) count * (count - 1) / 2;

            _db.BeginTransaction();

            for (var i = 0; i < count; i++)
            {
                var s = _query.SelectByKey(_db, (long) i % InstanceCount);
                sum -= s.Id;
            }

            _db.CommitTransaction();

            if (count <= InstanceCount)
                Assert.AreEqual(0, sum);
        }

        protected override void LinqQueryTest(int count)
        {
            _db.BeginTransaction();

            for (var i = 0; i < count; i++)
            {
                var id = (long) i % InstanceCount;
                var result = _db.GetTable<Simplests>().Where(o => o.Id == id);

                foreach (var o in result)
                {
                    // Doing nothing, just enumerate
                }
            }

            _db.CommitTransaction();
        }

        static readonly Func<DbManager, long, IQueryable<Simplests>> _compiledQuery = CompiledQuery.Compile(
            (DbManager db, long id) => db.GetTable<Simplests>().Where(o => o.Id == id));

        protected override void CompiledLinqQueryTest(int count)
        {
            _db.BeginTransaction();

            for (var i = 0; i < count; i++)
            {
                var id = (long) i % InstanceCount;
                foreach (var o in _compiledQuery(_db, id))
                {
                    // Doing nothing, just enumerate
                }
            }

            _db.CommitTransaction();
        }

        protected override void NativeQueryTest(int count)
        {
            _db.BeginTransaction();

            _db
                .SetCommand(@"SELECT * FROM Simplests WHERE Id = @id",
                    _db.Parameter("@id", DbType.Int32, 4))
                .Prepare();

            for (var i = 0; i < count; i++)
            {
                _db.Parameter("@id").Value = i % InstanceCount;

                var result = _db.ExecuteObject<Simplests>();
            }

            _db.CommitTransaction();
        }

        protected override void LinqMaterializeTest(int count)
        {
            _db.BeginTransaction();

            var i = 0;

            while (i < count)
                foreach (var o in _db.GetTable<Simplests>().Where(s => s.Id > 0))
                    if (++i >= count)
                        break;

            _db.CommitTransaction();
        }

        protected override void NativeMaterializeTest(int count)
        {
            _db.BeginTransaction();

            var i = 0;

            while (i < count)
                foreach (var o in _query.SelectAll(_db))
                    if (++i >= count)
                        break;

            _db.CommitTransaction();
        }

        static readonly Func<DbManager, long, int, IQueryable<Simplests>> _pageQuery = CompiledQuery.Compile(
            (DbManager db, long id, int pgSize) => db.GetTable<Simplests>().Where(o => o.Id >= id).Take(pgSize));

        protected override void LinqQueryPageTest(int count, int pageSize)
        {
            _db.BeginTransaction();

            for (var i = 0; i < count; i++)
            {
                var id = (i * pageSize) % InstanceCount;

                foreach (var o in _pageQuery(_db, id, pageSize))
                {
                    // Doing nothing, just enumerate
                }
            }

            _db.CommitTransaction();
        }
    }
}