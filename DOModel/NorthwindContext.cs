// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.31

using System;
using System.Diagnostics;
using System.Linq;
using OrmBattle.DOModel.Northwind;
using Xtensive.Orm;

namespace OrmBattle.DOModel
{
  [Serializable]
  public class NorthwindContext : IDisposable
  {
    private bool disposed = false;
    private readonly Session session;
    private readonly TransactionScope transactionScope;

    public IQueryable<Category> Categories
    {
      get { return session.Query.All<Category>(); }
    }

    public IQueryable<Customer> Customers
    {
      get { return session.Query.All<Customer>(); }
    }

    public IQueryable<Employee> Employees
    {
      get { return session.Query.All<Employee>(); }
    }

    public IQueryable<Order> Orders
    {
      get { return session.Query.All<Order>(); }
    }

    public IQueryable<OrderDetail> OrderDetails
    {
      get { return session.Query.All<OrderDetail>(); }
    }

    public IQueryable<Product> Products
    {
      get { return session.Query.All<Product>(); }
    }

    public IQueryable<ActiveProduct> ActiveProducts
    {
      get { return session.Query.All<ActiveProduct>(); }
    }

    public IQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get { return session.Query.All<DiscontinuedProduct>(); }
    }

    public IQueryable<Region> Regions
    {
      get { return session.Query.All<Region>(); }
    }

    public IQueryable<Shipper> Shippers
    {
      get { return session.Query.All<Shipper>(); }
    }

    public IQueryable<Supplier> Suppliers
    {
      get { return session.Query.All<Supplier>(); }
    }

    public IQueryable<Territory> Territories
    {
      get { return session.Query.All<Territory>(); }
    }

    public void Dispose()
    {
      if (disposed)
        return;
      transactionScope.Dispose();
      session.Dispose();
    }
    
    public NorthwindContext(Domain domain)
    {
      session = domain.OpenSession();
      transactionScope = session.OpenTransaction();
    }
  }
}