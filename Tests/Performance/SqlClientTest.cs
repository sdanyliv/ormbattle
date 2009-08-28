// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.03

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using OrmBattle.NHibernateModel;
using System.Diagnostics;
using NUnit.Framework;
using Xtensive.Core.Diagnostics;

namespace OrmBattle.Tests.Performance
{
  [Serializable]
  public class SqlClientTest : PerformanceTestBase
  {
    const int BatchLength = 25;

    private readonly SqlConnection con = new SqlConnection("Data Source=localhost;"
      + "Initial Catalog = PerformanceTest;"
      + "Integrated Security=SSPI;");


    public override string ToolName {
      get { return "SqlClient"; }
    }

    public override string ShortToolName {
      get { return "SQL"; }
    }

    protected override void Setup()
    {
      con.Open();
      using (var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "DELETE [dbo].[Simplests]";
        cmd.ExecuteNonQuery();
        transaction.Commit();
      }
      con.Close();
    }

    protected override void TearDown()
    {
      con.Open();
      using (var transaction = con.BeginTransaction())
      {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "DELETE [dbo].[Simplests]";
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


    protected override void InsertMultipleTest(int count)
    {
      var builder = new StringBuilder(8192);
      var parameters = new List<SqlParameter>(50);
      for (int i = 0; i < BatchLength; i++) {
        string idParameterName = "@pId" + i;
        string valueParameterName = "@pValue" + i;
        var idParameter = new SqlParameter(idParameterName, SqlDbType.BigInt);
        var valueParameter = new SqlParameter(valueParameterName, SqlDbType.BigInt);
        builder.AppendLine(string.Format(
          "INSERT INTO [dbo].[Simplests] " +
          "([Simplests].[Id], [Simplests].[Value]) " +
          "VALUES ({0}, {1});", idParameterName, valueParameterName));
        parameters.Add(idParameter);
        parameters.Add(valueParameter); 
      }

      using (var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.Parameters.AddRange(parameters.ToArray());
        cmd.CommandText = builder.ToString();
        cmd.Prepare();

        for (int itemIndex = 0; itemIndex < count; itemIndex++) {
          var batchItem = itemIndex % BatchLength;
          cmd.Parameters["@pId"+batchItem].SqlValue = (long) itemIndex;
          cmd.Parameters["@pValue"+batchItem].SqlValue = (long) itemIndex;
          if (batchItem + 1 == BatchLength)
            cmd.ExecuteNonQuery();
        }

        transaction.Commit();
      }
      instanceCount = count;
    }

    protected override void UpdateMultipleTest()
    {
      var builder = new StringBuilder(8192);
      var parameters = new List<SqlParameter>(50);
      for (int i = 0; i < BatchLength; i++) {
        string idParameterName = "@pId" + i;
        string valueParameterName = "@pValue" + i;
        var idParameter = new SqlParameter(idParameterName, SqlDbType.BigInt);
        var valueParameter = new SqlParameter(valueParameterName, SqlDbType.BigInt);
        builder.AppendLine(string.Format(
          "UPDATE [dbo].[Simplests] " +
          "SET [Simplests].[Value] = {1} " +
          "WHERE [Simplests].[Id] = {0};", idParameterName, valueParameterName));
        parameters.Add(idParameter);
        parameters.Add(valueParameter);
      }

      using (var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplests].[Id], [Simplests].[Value] " +
          "FROM [dbo].[Simplests]";
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
        cmd.Parameters.AddRange(parameters.ToArray());
        cmd.CommandText = builder.ToString();
        cmd.Prepare();

        int itemIndex = 0;
        foreach (var l in list) {
          var batchItem = itemIndex % BatchLength;
          cmd.Parameters["@pId" + batchItem].SqlValue = (long)itemIndex;
          cmd.Parameters["@pValue" + batchItem].SqlValue = (long)itemIndex;
          if (batchItem + 1 == BatchLength)
            cmd.ExecuteNonQuery();
          itemIndex++;
        }
        transaction.Commit();
      }
    }

    protected override void DeleteMultipleTest()
    {
      var builder = new StringBuilder(8192);
      var parameters = new List<SqlParameter>(50);
      builder.Append(
          "DELETE [dbo].[Simplests] " +
          "WHERE [Simplests].[Id] IN (");
      for (int i = 0; i < BatchLength; i++) {
        string idParameterName = "@pId" + i;
        var idParameter = new SqlParameter(idParameterName, SqlDbType.BigInt);
        builder.Append(idParameterName + ", ");
        parameters.Add(idParameter);
      }
      builder.AppendLine("-1);");

      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplests].[Id], [Simplests].[Value] " +
          "FROM [dbo].[Simplests]";
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
        cmd.Parameters.AddRange(parameters.ToArray());
        cmd.CommandText = builder.ToString();
        cmd.Prepare();

        int itemIndex = 0;
        foreach (var l in list) {
          var batchItem = itemIndex % BatchLength;
          cmd.Parameters["@pId" + batchItem].SqlValue = (long)itemIndex;
          if (batchItem + 1 == BatchLength)
            cmd.ExecuteNonQuery();
          itemIndex++;
        }
        transaction.Commit();
      }
    }

    protected override void InsertSingleTest(int count)
    {
      using (var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.BigInt));
        cmd.Parameters.Add(new SqlParameter("@pValue", SqlDbType.BigInt));
        cmd.CommandText = "INSERT INTO " +
                          "[dbo].[Simplests] ([Simplests].[Id], [Simplests].[Value]) " +
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

    protected override void UpdateSingleTest()
    {
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplests].[Id], [Simplests].[Value] " +
          "FROM [dbo].[Simplests]";
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
        cmd.CommandText = "UPDATE [dbo].[Simplests] SET [Simplests].[Value] = @pValue WHERE [Simplests].[Id] = @pId";
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

    protected override void DeleteSingleTest()
    {
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplests].[Id], [Simplests].[Value] " +
          "FROM [dbo].[Simplests]";
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
        cmd.CommandText = "DELETE [dbo].[Simplests] WHERE [Simplests].[Id] = @pId";
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
        cmd.CommandText = "SELECT [Simplests].[Id], [Simplests].[Value] " + 
          "FROM [dbo].[Simplests] WHERE [Simplests].[Id] = @pId";
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

    protected override void LinqQueryTest(int count)
    {
      Log.Error("Linq queries are not supported.");
    }

    protected override void CompiledLinqQueryTest(int count)
    {
      Log.Error("Linq compiled queries are not supported.");
    }

    protected override void NativeQueryTest(int count)
    {
      using(var transaction = con.BeginTransaction()) {
        var cmd = con.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT [Simplests].[Id], [Simplests].[Value] " + 
          "FROM [dbo].[Simplests] WHERE [Simplests].[id] = @pId";
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

    protected override void NativeMaterializeTest(int count)
    {
      long sum = 0;
      int i = 0;
      using(var transaction = con.BeginTransaction()) {
        while (i < count) {
          SqlCommand cmd = con.CreateCommand();
          cmd.Transaction = transaction;
          cmd.CommandText = "SELECT [Simplests].[Id], [Simplests].[Value] " +
            "FROM [dbo].[Simplests]";
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

    protected override void LinqMaterializeTest(int count)
    {
      Log.Error("Linq materialization is not supported.");
    }
  }
}