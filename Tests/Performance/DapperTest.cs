// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.03

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using NUnit.Framework;
using Dapper;
using OrmBattle.DapperModel;

namespace OrmBattle.DapperModel
{
    public class Simplest
    {
        public long Id;
        public long Value;
    }
}

namespace OrmBattle.Tests.Performance
{
    [Serializable]
    public class DapperTest : PerformanceTestBase
    {
        const int BatchLength = 25;

        private readonly SqlConnection _con = new SqlConnection("Data Source=localhost;"
                                                               + "Initial Catalog = PerformanceTest;"
                                                               + "Integrated Security=SSPI;");


        public override string ToolName
        {
            get { return "Dapper"; }
        }

        public override string ShortToolName
        {
            get { return "DPR"; }
        }

        protected override void Setup()
        {
            _con.Open();
            using (var transaction = new TransactionScope())
            {
                _con.Execute("DELETE [dbo].[Simplests]");
                transaction.Complete();
            }
            _con.Close();
        }

        protected override void TearDown()
        {
            _con.Open();
            using (var transaction = new TransactionScope())
            {
                _con.Execute("DELETE [dbo].[Simplests]");
                transaction.Complete();
            }
            _con.Close();
        }

        protected override void OpenSession()
        {
            _con.Open();
        }

        protected override void CloseSession()
        {
            _con.Close();
        }


        protected override void InsertMultipleTest(int count)
        {
            using (var transaction = new TransactionScope())
            {
                var sqlQuery = "INSERT INTO " +
                               "[dbo].[Simplests] ([Simplests].[Id], [Simplests].[Value]) " +
                               "VALUES (@pId, @pValue)";

                for (int i = 0; i < count; i++)
                {
                    _con.Execute(sqlQuery, new { pId = i, pValue = i });
                }

                transaction.Complete();
            }
            InstanceCount = count;
        }

        protected override void UpdateMultipleTest()
        {
            using (var transaction = new TransactionScope())
            {
                _con.Execute("UPDATE [dbo].[Simplests] SET Value = Value + 1");
                transaction.Complete();
            }
        }

        protected override void DeleteMultipleTest()
        {
            using (var transaction = new TransactionScope())
            {
                _con.Execute("DELETE [dbo].[Simplests]");
                transaction.Complete();
            }
        }

        protected override void InsertSingleTest(int count)
        {
            using (var transaction = new TransactionScope())
            {
                var sqlQuery = "INSERT INTO " +
                               "[dbo].[Simplests] ([Simplests].[Id], [Simplests].[Value]) " +
                               "VALUES (@pId, @pValue)";

                for (int i = 0; i < count; i++)
                {
                    _con.Execute(sqlQuery, new { pId = i, pValue = i });
                }

                transaction.Complete();
            }
            InstanceCount = count;
        }

        protected override void UpdateSingleTest()
        {
            using (var transaction = new TransactionScope())
            {
                var list = _con.Query<Simplest>("SELECT [Simplests].[Id], [Simplests].[Value] " +
                                     "FROM [dbo].[Simplests]");

                var sqlQuery = "UPDATE [dbo].[Simplests] SET [Simplests].[Value] = @pValue WHERE [Simplests].[Id] = @pId";

                foreach (var l in list)
                {
                    _con.Execute(sqlQuery, new { pId = l.Id, pValue = l.Value });
                }

                transaction.Complete();
            }
        }

        protected override void DeleteSingleTest()
        {
            using (var transaction = new TransactionScope())
            {
                var list = _con.Query<Simplest>("SELECT [Simplests].[Id], [Simplests].[Value] " +
                                     "FROM [dbo].[Simplests]");

                var sqlQuery = "DELETE [dbo].[Simplests] WHERE [Simplests].[Id] = @pId";

                foreach (var l in list)
                {
                    _con.Execute(sqlQuery, new {pId = l.Id});
                }

                transaction.Complete();
            }
        }

        protected override void FetchTest(int count)
        {
            long sum = (long) count * (count - 1) / 2;
            using (var transaction = new TransactionScope())
            {
                var sqlQuery = "SELECT [Simplests].[Id], [Simplests].[Value] " +
                                  "FROM [dbo].[Simplests] WHERE [Simplests].[Id] = @pId";

                for (int i = 0; i < count; i++)
                {
                    var s = _con.Query<Simplest>(sqlQuery, new {pId = i % InstanceCount}).First();
                    sum -= s.Id;
                }

                transaction.Complete();
            }

            if (count <= InstanceCount)
                Assert.AreEqual(0, sum);
        }

        protected override void LinqQueryTest(int count)
        {
            throw new NotSupportedException();
        }

        protected override void CompiledLinqQueryTest(int count)
        {
            throw new NotSupportedException();
        }

        protected override void NativeQueryTest(int count)
        {
            using (var transaction = new TransactionScope())
            {
                var sqlQuery = "SELECT [Simplests].[Id], [Simplests].[Value] " +
                                  "FROM [dbo].[Simplests] WHERE [Simplests].[Id] = @pId";

                for (int i = 0; i < count; i++)
                {
                    _con.Query<Simplest>(sqlQuery, new { pId = i % InstanceCount }).First();
                }

                transaction.Complete();
            }
        }

        protected override void NativeMaterializeTest(int count)
        {
            using (var transaction = new TransactionScope())
            {
                var sqlQuery = "SELECT [Simplests].[Id], [Simplests].[Value] FROM [dbo].[Simplests]";

                int i = 0;
                while (i < count)
                    foreach (var o in _con.Query<Simplest>(sqlQuery))
                        if (++i >= count)
                            break;

                transaction.Complete();
            }
        }

        protected override void LinqMaterializeTest(int count)
        {
            throw new NotSupportedException();
        }

        protected override void LinqQueryPageTest(int count, int pageSize)
        {
            throw new NotSupportedException();
        }
    }
}