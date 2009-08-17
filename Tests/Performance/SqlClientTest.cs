// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.03

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OrmBattle.NHibernateModel;
using System.Diagnostics;
using NUnit.Framework;
using Xtensive.Core.Diagnostics;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class SqlClientTest : TestBase
  {
    private readonly SqlConnection con = new SqlConnection("Data Source=localhost;"
      + "Initial Catalog = PerformanceTest;"
      + "Integrated Security=SSPI;");


    protected override void SetUp()
    {
      con.Open();
      using (var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "DELETE [dbo].[Simplest]";
        cmd.ExecuteNonQuery();
        transaction.Commit();
      }
      con.Close();
      Console.Out.WriteLine("SqlClient");
    }

    protected override void TearDown()
    {
      con.Open();
      using (var transaction = con.BeginTransaction())
      {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "DELETE [dbo].[Simplest]";
        cmd.ExecuteNonQuery();
        transaction.Commit();
      }
      con.Close();
    }

    protected override void OpenSession()
    {
      con.Open();
    }

    protected override void CloseSession()
    {
      con.Close();
    }


    protected override void InsertTest(int count)
    {
      using (var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.BigInt));
        cmd.Parameters.Add(new SqlParameter("@pValue", SqlDbType.BigInt));
        cmd.CommandText = "INSERT INTO " +
                          "[dbo].[Simplest] ([Simplest].[Id], [Simplest].[Value]) " +
                          "VALUES (@pId, @pValue)";
        cmd.Prepare();

        for (int i = 0; i < count; i++) {
          cmd.Parameters["@pId"].SqlValue = (long) i;
          cmd.Parameters["@pValue"].SqlValue = (long) i;
          cmd.ExecuteNonQuery();
        }

        transaction.Commit();
      }
      instanceCount = count;
    }

    protected override void UpdateTest()
    {
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplest].[Id], [Simplest].[Value] " +
          "FROM [dbo].[Simplest]";
        cmd.Prepare();

        var dr = cmd.ExecuteReader();
        var list = new List<Simplest>();
        while (dr.Read()) {
          if (!dr.IsDBNull(0) && !dr.IsDBNull(1))
            list.Add(new Simplest(dr.GetInt64(0), dr.GetInt64(1)));
        }
        dr.Close();

        cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "UPDATE [dbo].[Simplest] SET [Simplest].[Value] = @pValue WHERE [Simplest].[Id] = @pId";
        cmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.BigInt));
        cmd.Parameters.Add(new SqlParameter("@pValue", SqlDbType.BigInt));
        cmd.Prepare();
        foreach (var l in list) {
          cmd.Parameters["@pId"].SqlValue = l.Id;
          cmd.Parameters["@pValue"].SqlValue = l.Value + 1;
          cmd.ExecuteNonQuery();
        }
        transaction.Commit();
      }
    }

    protected override void DeleteTest()
    {
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplest].[Id], [Simplest].[Value] " +
          "FROM [dbo].[Simplest]";
        cmd.Prepare();

        var dr = cmd.ExecuteReader();
        var list = new List<Simplest>();
        while (dr.Read()) {
          if (!dr.IsDBNull(0) && !dr.IsDBNull(1))
            list.Add(new Simplest(dr.GetInt64(0), dr.GetInt64(1)));
        }
        dr.Close();

        cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "DELETE [dbo].[Simplest] WHERE [Simplest].[Id] = @pId";
        cmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.BigInt));
        cmd.Prepare();

        foreach (var l in list) {
          cmd.Parameters["@pId"].SqlValue = l.Id;
          cmd.ExecuteNonQuery();
        }
        transaction.Commit();
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long) count * (count - 1) / 2;
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplest].[Id], [Simplest].[Value] " + 
          "FROM [dbo].[Simplest] WHERE [Simplest].[Id] = @pId";
        cmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.BigInt));
        cmd.Prepare();
        SqlDataReader dr;

        for (int i = 0; i < count; i++) {
          cmd.Parameters["@pId"].SqlValue = i % instanceCount;
          dr = cmd.ExecuteReader();

          var s = new Simplest();
          while (dr.Read()) {
            if (!dr.IsDBNull(0))
              s.Id = dr.GetInt64(0);
            if (!dr.IsDBNull(1))
              s.Value = dr.GetInt64(1);
          }
          sum -= s.Id;
          dr.Close();
        }
        transaction.Commit();
      }
      if (count <= instanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void QueryTest(int count)
    {
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplest].[Id], [Simplest].[Value] " + 
          "FROM [dbo].[Simplest] WHERE [Simplest].[id] = @pId";
        cmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.BigInt));
        SqlDataReader dr;

        for (int i = 0; i < count; i++) {
          cmd.Parameters["@pId"].SqlValue = i % instanceCount;
          dr = cmd.ExecuteReader();

          var s = new Simplest();
          while (dr.Read()) {
            if (!dr.IsDBNull(0))
              s.Id = dr.GetInt64(0);
            if (!dr.IsDBNull(1))
              s.Value = dr.GetInt64(1);
          }
          dr.Close();
        }
        transaction.Commit();
      }
    }

    protected override void CompiledQueryTest(int count)
    {
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplest].[Id], [Simplest].[Value] " + 
          "FROM [dbo].[Simplest] WHERE [Simplest].[id] = @pId";
        cmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.BigInt));
        cmd.Prepare();
        SqlDataReader dr;

        for (int i = 0; i < count; i++) {
          cmd.Parameters["@pId"].SqlValue = i % instanceCount;
          dr = cmd.ExecuteReader();

          var s = new Simplest();
          while (dr.Read()) {
            if (!dr.IsDBNull(0))
              s.Id = dr.GetInt64(0);
            if (!dr.IsDBNull(1))
              s.Value = dr.GetInt64(1);
          }
          dr.Close();
        }
        transaction.Commit();
      }
    }

    protected override void MaterializeTest(int count)
    {
      long sum = 0;
      int i = 0;
      using(var transaction = con.BeginTransaction()) {
        while (i < count) {
          SqlCommand cmd = con.CreateCommand();
          cmd.Transaction = transaction;
          cmd.CommandText = "SELECT [Simplest].[Id], [Simplest].[Value] " +
            "FROM [dbo].[Simplest]";
          cmd.Prepare();

          SqlDataReader dr = cmd.ExecuteReader();
          while (dr.Read()) {
            var s = new Simplest();
            if (!dr.IsDBNull(0))
              s.Id = dr.GetInt64(0);
            if (!dr.IsDBNull(1))
              s.Value = dr.GetInt64(1);
            sum += s.Id;
            if (++i >= count)
              break;
          }
          dr.Close();
        }
        transaction.Commit();
      }
      Assert.AreEqual((long)count * (count - 1) / 2, sum);
    }
  }
}