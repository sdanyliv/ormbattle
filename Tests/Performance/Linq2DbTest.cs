using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NUnit.Framework;

using LinqToDB;
using LinqToDB.Data;

namespace OrmBattle.Tests.Performance
{
	using Linq2DbModel;

	[Serializable]
	public class Linq2DbTest : PerformanceTestBase
	{
		DataConnection          _db;
	    ITable<Simplests>       _table;

        public override string ToolName      { get { return "Linq2Db"; } }
		public override string ShortToolName { get { return "L2DB";       } }

		protected override void Setup()
		{
			using (var dbManager = new DataConnection("PerformanceTest"))
				dbManager.SetCommand("TRUNCATE TABLE Simplests")
					.Execute();
		}

		protected override void TearDown()
		{
			using (var dbManager = new DataConnection("PerformanceTest"))
				dbManager
					.SetCommand("TRUNCATE TABLE Simplests")
                    .Execute();
        }

        protected override void OpenSession()
		{
			DataConnection.DefaultConfiguration = "PerformanceTest";
			_db    = new DataConnection("PerformanceTest");
            _table = _db.GetTable<Simplests>();
		}

		protected override void CloseSession()
		{
			_db.Dispose();
		}

		static IEnumerable<Simplests> CreateNewSimplests(int count)
		{
			for (var i = 0; i < count; i++)
				yield return new Simplests { Id = i, Value = i };
		}

		protected override void InsertMultipleTest(int count)
		{
			_db.BeginTransaction();
			InstanceCount = (int) _db.BulkCopy(CreateNewSimplests(count)).RowsCopied;
			_db.CommitTransaction();
		}

		protected override void UpdateMultipleTest()
		{
			long sum = InstanceCount * (InstanceCount - 1) / 2;

			_db.BeginTransaction();

		    _table
                .Set(s => s.Value, s => s.Value + 1)
                .Update();

            _db.CommitTransaction();

//			Assert.AreEqual(0, sum);
		}

		protected override void DeleteMultipleTest()
		{
			_db.BeginTransaction();
			_table.Delete();
			_db.CommitTransaction();
		}

		protected override void InsertSingleTest(int count)
		{
			_db.BeginTransaction();

		    for (var i = 0; i < count; i++)
		        _table.Insert(() => new Simplests {Id = i, Value = i});

			_db.CommitTransaction();

			InstanceCount = count;
		}

		protected override void UpdateSingleTest()
		{
			long sum = InstanceCount * (InstanceCount - 1) / 2;

			_db.BeginTransaction();

			foreach (var s in _table.ToList())
			{
				s.Value++;
				sum -= s.Id;

				_db.Update(s);
			}

			_db.CommitTransaction();

			Assert.AreEqual(0, sum);
		}

		protected override void DeleteSingleTest()
		{
			_db.BeginTransaction();

			foreach (var s in _table.ToList())
				_db.Delete(s);

			_db.CommitTransaction();
		}

		protected override void FetchTest(int count)
		{
			long sum = (long)count * (count - 1) / 2;

			_db.BeginTransaction();

			for (var i = 0; i < count; i++)
			{
			    var id = i % InstanceCount;
                var s = _table.FirstOrDefault(q => q.Id == id);
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
				var id     = (long)i % InstanceCount;
				var result = _table.Where(o => o.Id == id);

				foreach (var o in result)
				{
					// Doing nothing, just enumerate
				}
			}

			_db.CommitTransaction();
		}

		static readonly Func<DataConnection,long,IQueryable<Simplests>> CompiledQuery = LinqToDB.CompiledQuery.Compile(
			(DataConnection db, long id) => db.GetTable<Simplests>().Where(o => o.Id == id));

		protected override void CompiledLinqQueryTest(int count)
		{
			_db.BeginTransaction();

			for (var i = 0; i < count; i++)
			{
				var id = i % InstanceCount;
				foreach (var o in CompiledQuery(_db, id))
				{
					// Doing nothing, just enumerate
				}
			}

			_db.CommitTransaction();
		}

		protected override void NativeQueryTest(int count)
		{
			_db.BeginTransaction();

            var command = DataConnectionExtensions.SetCommand(_db, @"SELECT * FROM Simplests WHERE Id = @id", new DataParameter("@id", DbType.Int32));

			for (var i = 0; i < count; i++)
			{
                command.Parameters[0].Value = i % InstanceCount;
				var result = command.Execute<Simplests>();
			}

			_db.CommitTransaction();
		}

		protected override void LinqMaterializeTest(int count)
		{
			_db.BeginTransaction();

			var i = 0;

			while (i < count)
				foreach (var o in _table.Where(s => s.Id > 0))
					if (++i >= count)
						break;

			_db.CommitTransaction();
		}

		protected override void NativeMaterializeTest(int count)
		{
			_db.BeginTransaction();

			var i = 0;

			while (i < count)
				foreach (var o in _table)
					if (++i >= count)
						break;

			_db.CommitTransaction();
		}

	    static readonly Func<DataConnection, long, int, IQueryable<Simplests>> PageQuery = LinqToDB.CompiledQuery.Compile(
	        (DataConnection db, long id, int pgSize) => db.GetTable<Simplests>().Where(o => o.Id >= id).Take(pgSize));

		protected override void LinqQueryPageTest(int count, int pageSize)
		{
			_db.BeginTransaction();

			for (var i = 0; i < count; i++)
			{
				var id = (i * pageSize) % InstanceCount;

				foreach (var o in PageQuery(_db, id, pageSize))
				{
					// Doing nothing, just enumerate
				}
			}

			_db.CommitTransaction();
		}
	}
}
