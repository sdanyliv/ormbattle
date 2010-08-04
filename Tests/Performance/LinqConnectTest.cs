using System;
using System.Linq;
using NUnit.Framework;
using OrmBattle.LinqConnectModel;
using Devart.Data.Linq;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class LinqConnectTest : PerformanceTestBase
  {
    private PerformanceTestDataContext _db;

    public override string ToolName
    {
      get { return "Devart LinqConnect"; }
    }

    public override string ShortToolName
    {
      get { return "LC"; }
    }

    protected override void Setup()
    {
      using (var dataContext = new PerformanceTestDataContext()) {
        dataContext.Connection.Open();
        using (dataContext.Transaction = dataContext.Connection.BeginTransaction()) {
          dataContext.Simplests.DeleteAllOnSubmit(dataContext.Simplests);
          dataContext.SubmitChanges();
          dataContext.Transaction.Commit();
        }
      }
    }

    protected override void TearDown()
    {
      using (var dataContext = new PerformanceTestDataContext()) {
        dataContext.Connection.Open();
        using (dataContext.Transaction = dataContext.Connection.BeginTransaction()) {
          dataContext.Simplests.DeleteAllOnSubmit(dataContext.Simplests);
          dataContext.SubmitChanges();
          dataContext.Transaction.Commit();
        }
      }
    }

    protected override void OpenSession()
    {
      _db = new PerformanceTestDataContext();
      _db.Connection.Open();
    }

    protected override void CloseSession()
    {
      _db.Dispose();
    }

    protected override void InsertMultipleTest(int count)
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        for (var i = 0; i < count; i++) {
          var s = new Simplest {Id = i, Value = i};
          _db.Simplests.InsertOnSubmit(s);
        }

        _db.SubmitChanges();
        _db.Transaction.Commit();
      }

      InstanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      var sum = (long) InstanceCount * (InstanceCount - 1) / 2;

      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        // System.Text.StringBuilder sb = new System.Text.StringBuilder();
        // _db.Log = new System.IO.StringWriter(sb);
        foreach (var s in _db.Simplests) {
          s.Value++;
          sum -= s.Id;
        }

        _db.SubmitChanges();
        _db.Transaction.Commit();
      }

      Assert.AreEqual(0, sum);
    }

    protected override void DeleteMultipleTest()
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        _db.Simplests.DeleteAllOnSubmit(_db.Simplests);
        _db.SubmitChanges();
        _db.Transaction.Commit();
      }
    }

    protected override void InsertSingleTest(int count)
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        for (var i = 0; i < count; i++) {
          var s = new Simplest {Id = i, Value = i};
          _db.Simplests.InsertOnSubmit(s);
          _db.SubmitChanges();
        }

        _db.Transaction.Commit();
      }

      InstanceCount = count;
    }

    protected override void UpdateSingleTest()
    {
      var sum = (long) InstanceCount * (InstanceCount - 1) / 2;

      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        foreach (var s in _db.Simplests) {
          s.Value++;
          sum -= s.Id;
          _db.SubmitChanges();
        }

        _db.Transaction.Commit();
      }

      Assert.AreEqual(0, sum);
    }

    protected override void DeleteSingleTest()
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        foreach (var s in _db.Simplests) {
          _db.Simplests.DeleteOnSubmit(s);
          _db.SubmitChanges();
        }

        _db.Transaction.Commit();
      }
    }

    private static readonly Func<PerformanceTestDataContext, long, Simplest> _compiledFetcher =
      CompiledQuery.Compile((PerformanceTestDataContext context, long id) => 
        context.Simplests.SingleOrDefault(o => o.Id==id));

    protected override void FetchTest(int count)
    {
      var sum = (long) count * (count - 1) / 2;

      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        for (var i = 0; i < count; i++) {
          var id = (long) i % InstanceCount;
          var s = _compiledFetcher(_db, id);
          sum -= s.Id;
        }

        _db.Transaction.Commit();
      }

      if (count <= InstanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void LinqQueryTest(int count)
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        for (var i = 0; i < count; i++) {
          var id = (long) i % InstanceCount;
          var result = _db.Simplests.Where(o => o.Id==id);
          foreach (var o in result) {
            // Doing nothing, just enumerate
          }
        }

        _db.Transaction.Commit();
      }
    }

    private static readonly Func<PerformanceTestDataContext, long, IQueryable<Simplest>> _compiledQuery =
      CompiledQuery.Compile((PerformanceTestDataContext context, long id) => 
        context.Simplests.Where(o => o.Id==id));

    protected override void CompiledLinqQueryTest(int count)
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        for (var i = 0; i < count; i++) {
          var id = (long) i % InstanceCount;
          foreach (var o in _compiledQuery(_db, id)) {
            // Doing nothing, just enumerate
          }
        }

        _db.Transaction.Commit();
      }
    }

    protected override void NativeQueryTest(int count)
    {
      throw new NotSupportedException();
    }

    protected override void LinqMaterializeTest(int count)
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        var i = 0;
        while (i < count)
          foreach (var o in _db.Simplests.Where(s => s.Id > 0)) {
            if (++i >= count)
              break;
          }

        _db.Transaction.Commit();
      }
    }

    protected override void NativeMaterializeTest(int count)
    {
      throw new NotSupportedException();
    }

    private static readonly Func<PerformanceTestDataContext, long, int, IQueryable<Simplest>> _pageQuery = CompiledQuery.Compile(
      (PerformanceTestDataContext context, long id, int pgSize) => 
        context.Simplests.Where(o => o.Id >= id).Take(pgSize));

    protected override void LinqQueryPageTest(int count, int pageSize)
    {
      using (_db.Transaction = _db.Connection.BeginTransaction()) {
        for (var i = 0; i < count; i++) {
          var id = (i * pageSize) % InstanceCount;
          foreach (var o in _pageQuery(_db, id, pageSize)) {
            // Doing nothing, just enumerate
          }
        }

        _db.Transaction.Commit();
      }
    }
  }
}