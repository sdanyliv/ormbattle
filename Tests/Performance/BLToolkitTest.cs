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
		DbManager           db;
		SqlQuery<Simplests> query;

		public override string ToolName      { get { return "BLToolkit"; } }
		public override string ShortToolName { get { return "BLT";       } }

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
			db    = new DbManager("PerformanceTest");
			query = new SqlQuery<Simplests>();
		}

		protected override void CloseSession()
		{
			db.Dispose();
		}

		static IEnumerable<Simplests> CreateNewSimplests(int count)
		{
			for (var i = 0; i < count; i++)
				yield return new Simplests { Id = i, Value = i };
		}

		protected override void InsertMultipleTest(int count)
		{
			db.BeginTransaction();
			InstanceCount = query.Insert(db, 25, CreateNewSimplests(count));
			db.CommitTransaction();
		}

		protected override void UpdateMultipleTest()
		{
			long sum = (long)InstanceCount * (InstanceCount - 1) / 2;

			db.BeginTransaction();

			var list = query.SelectAll(db);

			foreach (var s in list)
			{
				s.Value++;
				sum -= s.Id;
			}

			query.Update(db, 25, list);

			db.CommitTransaction();

			Assert.AreEqual(0, sum);
		}

		protected override void DeleteMultipleTest()
		{
			db.BeginTransaction();
			query.Delete(db, 25, query.SelectAll(db));
			db.CommitTransaction();
		}

		protected override void InsertSingleTest(int count)
		{
			db.BeginTransaction();

			for (var i = 0; i < count; i++)
				query.Insert(db, new Simplests { Id = i, Value = i });

			db.CommitTransaction();

			InstanceCount = count;
		}

		protected override void UpdateSingleTest()
		{
			long sum = (long)InstanceCount * (InstanceCount - 1) / 2;

			db.BeginTransaction();

			foreach (var s in query.SelectAll(db))
			{
				s.Value++;
				sum -= s.Id;

				query.Update(db, s);
			}

			db.CommitTransaction();

			Assert.AreEqual(0, sum);
		}

		protected override void DeleteSingleTest()
		{
			db.BeginTransaction();

			foreach (var s in query.SelectAll(db))
				query.Delete(db, s);

			db.CommitTransaction();
		}

		protected override void FetchTest(int count)
		{
			long sum = (long)count * (count - 1) / 2;

			db.BeginTransaction();

			for (var i = 0; i < count; i++)
			{
				var s = query.SelectByKey(db, (long)i % InstanceCount);
				sum -= s.Id;
			}

			db.CommitTransaction();

			if (count <= InstanceCount)
				Assert.AreEqual(0, sum);
		}

		protected override void LinqQueryTest(int count)
		{
			db.BeginTransaction();

			for (var i = 0; i < count; i++)
			{
				var id     = (long)i % InstanceCount;
				var result = db.GetTable<Simplests>().Where(o => o.Id == id);

				foreach (var o in result)
				{
					// Doing nothing, just enumerate
				}
			}

			db.CommitTransaction();
		}

		static readonly Func<DbManager,long,IQueryable<Simplests>> _compiledQuery = CompiledQuery.Compile(
			(DbManager db, long id) => db.GetTable<Simplests>().Where(o => o.Id == id));

		protected override void CompiledLinqQueryTest(int count)
		{
			db.BeginTransaction();

			for (var i = 0; i < count; i++)
			{
				var id = (long)i % InstanceCount;
				foreach (var o in _compiledQuery(db, id))
				{
					// Doing nothing, just enumerate
				}
			}

			db.CommitTransaction();
		}

		protected override void NativeQueryTest(int count)
		{
			db.BeginTransaction();

			db
				.SetCommand(@"SELECT * FROM Simplests WHERE Id = @id",
					db.Parameter("@id", DbType.Int32, 4))
				.Prepare();

			for (var i = 0; i < count; i++)
			{
				db.Parameter("@id").Value = i % InstanceCount;

				var result = db.ExecuteObject<Simplests>();
			}

			db.CommitTransaction();
		}

		protected override void LinqMaterializeTest(int count)
		{
			db.BeginTransaction();

			var i = 0;

			while (i < count)
				foreach (var o in db.GetTable<Simplests>().Where(s => s.Id > 0))
					if (++i >= count)
						break;

			db.CommitTransaction();
		}

		protected override void NativeMaterializeTest(int count)
		{
			db.BeginTransaction();

			var i = 0;

			while (i < count)
				foreach (var o in query.SelectAll())
					if (++i >= count)
						break;

			db.CommitTransaction();
		}

		static readonly Func<DbManager,long,int,IQueryable<Simplests>> _pageQuery = CompiledQuery.Compile(
			(DbManager db, long id, int pgSize) => db.GetTable<Simplests>().Where(o => o.Id >= id).Take(pgSize));

		protected override void LinqQueryPageTest(int count, int pageSize)
		{
			db.BeginTransaction();

			for (var i = 0; i < count; i++)
			{
				var id = (i * pageSize) % InstanceCount;

				foreach (var o in _pageQuery(db, id, pageSize))
				{
					// Doing nothing, just enumerate
				}
			}

			db.CommitTransaction();
		}
	}
}
