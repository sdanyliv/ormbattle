// Copyright (C) 2009 ORMBattle.net
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
      get { return Query<Category>.All; }
    }

    public IQueryable<Customer> Customers
    {
      get { return Query<Customer>.All; }
    }

    public IQueryable<Employee> Employees
    {
      get { return Query<Employee>.All; }
    }

    public IQueryable<Order> Orders
    {
      get { return Query<Order>.All; }
    }

    public IQueryable<OrderDetail> OrderDetails
    {
      get { return Query<OrderDetail>.All; }
    }

    public IQueryable<Product> Products
    {
      get { return Query<Product>.All; }
    }

    public IQueryable<ActiveProduct> ActiveProducts
    {
      get { return Query<ActiveProduct>.All; }
    }

    public IQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get { return Query<DiscontinuedProduct>.All; }
    }

    public IQueryable<Region> Regions
    {
      get { return Query<Region>.All; }
    }

    public IQueryable<Shipper> Shippers
    {
      get { return Query<Shipper>.All; }
    }

    public IQueryable<Supplier> Suppliers
    {
      get { return Query<Supplier>.All; }
    }

    public IQueryable<Territory> Territories
    {
      get { return Query<Territory>.All; }
    }
  }
}