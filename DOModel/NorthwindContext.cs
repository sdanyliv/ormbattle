// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.31

using System;
using System.Diagnostics;
using System.Linq;
using OrmBattle.DOModel.Northwind;
using Xtensive.Storage;

namespace OrmBattle.DOModel
{
  [Serializable]
  public class NorthwindContext
  {
    public IQueryable<Category> Categories
    {
      get { return Query.All<Category>(); }
    }

    public IQueryable<Customer> Customers
    {
      get { return Query.All<Customer>(); }
    }

    public IQueryable<Employee> Employees
    {
      get { return Query.All<Employee>(); }
    }

    public IQueryable<Order> Orders
    {
      get { return Query.All<Order>(); }
    }

    public IQueryable<OrderDetail> OrderDetails
    {
      get { return Query.All<OrderDetail>(); }
    }

    public IQueryable<Product> Products
    {
      get { return Query.All<Product>(); }
    }

    public IQueryable<ActiveProduct> ActiveProducts
    {
      get { return Query.All<ActiveProduct>(); }
    }

    public IQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get { return Query.All<DiscontinuedProduct>(); }
    }

    public IQueryable<Region> Regions
    {
      get { return Query.All<Region>(); }
    }

    public IQueryable<Shipper> Shippers
    {
      get { return Query.All<Shipper>(); }
    }

    public IQueryable<Supplier> Suppliers
    {
      get { return Query.All<Supplier>(); }
    }

    public IQueryable<Territory> Territories
    {
      get { return Query.All<Territory>(); }
    }
  }
}