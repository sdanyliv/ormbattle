// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.18

using System;
using System.Diagnostics;
using System.Transactions;
using EntitySpaces.Interfaces;
using NUnit.Framework;
using OrmBattle.EntitySpacesModel;

namespace OrmBattle.Tests.Performance
{
  public class EntitySpacesTest : TestBase
  {
    protected override void SetUp()
    {
      esProviderFactory.Factory = new EntitySpaces.LoaderMT.esDataProviderFactory();
      var simplests = new SimplestCollection();
      simplests.LoadAll();
      simplests.MarkAllAsDeleted();
      simplests.Save();
    }

    protected override void TearDown()
    {
      var simplests = new SimplestCollection();
      simplests.LoadAll();
      simplests.MarkAllAsDeleted();
      simplests.Save();
    }

    protected override void OpenSession()
    {
    }

    protected override void CloseSession()
    {
    }

    protected override void BatchInsertTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestCollection();
        for (int i = 0; i < count; i++) {
          var simplest = simplests.AddNew();
          simplest.Id = i;
          simplest.Value = i;
        }
        simplests.Save();
        ts.Complete();
      }
      instanceCount = count;
    }

    protected override void BatchUpdateTest()
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestCollection();
        simplests.LoadAll();
        foreach (var o in simplests)
          o.Value++;
        simplests.Save();
        ts.Complete();
      }
    }

    protected override void BatchDeleteTest()
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestCollection();
        simplests.LoadAll();
        simplests.MarkAllAsDeleted();
        simplests.Save();
        ts.Complete();
      }
    }

    protected override void InsertTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestCollection();
        for (int i = 0; i < count; i++) {
          var simplest = simplests.AddNew();
          simplest.Id = i;
          simplest.Value = i;
          simplests.Save();
        }
        ts.Complete();
      }
      instanceCount = count;
    }

    protected override void UpdateTest()
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestCollection();
        simplests.LoadAll();
        foreach (var o in simplests) {
          o.Value++;
          simplests.Save();
        }
        ts.Complete();
      }
    }

    protected override void DeleteTest()
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestCollection();
        simplests.LoadAll();
        foreach (var o in simplests) {
          o.MarkAsDeleted();
          simplests.Save();
        }
        ts.Complete();
      }
    }

    protected override void FetchTest(int count)
    {
      long sum = (long)count * (count - 1) / 2;
      using (var ts = new esTransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = (long) i % instanceCount;
          var simplest = new Simplest();
          simplest.LoadByPrimaryKey(id);
          sum -= simplest.Id.Value;
        }
        ts.Complete();
      }
      if (count <= instanceCount)
        Assert.AreEqual(0, sum);
    }

    protected override void QueryTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        for (int i = 0; i < count; i++) {
          var simplests = new SimplestCollection();
          var id = i%instanceCount;
          simplests.Query.Where(simplests.Query.Id == id);
          if(simplests.Query.Load())
            foreach (var simplest in simplests) {
              // Doing nothing, just enumerate
            }
        }
        ts.Complete();
      }
    }

    protected override void CompiledQueryTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        for (int i = 0; i < count; i++) {
          var id = i%instanceCount;
          var simplests = new SimplestCollection();
          simplests.Query.Where(simplests.Query.Id == id);
          if(simplests.Query.Load())
            foreach (var simplest in simplests) {
              // Doing nothing, just enumerate
            }
        }
        ts.Complete();
      }
    }

    protected override void MaterializeTest(int count)
    {
      using (var ts = new esTransactionScope()) {
        var simplests = new SimplestCollection();
        int i = 0;
        while (i < count) {
          simplests.LoadAll();
          foreach (var o in simplests)
            if (++i >= count)
              break;
        }
        ts.Complete();
      }
    }
  }
}