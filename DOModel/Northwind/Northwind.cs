// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexey Kochetov
// Created:    2008.12.01

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xtensive.Tuples;
using Xtensive.Orm;
using Xtensive.Orm.Model;

namespace OrmBattle.DOModel.Northwind
{

  [TableMapping("Categories")]
  [HierarchyRoot]
  public class Category : Entity
  {
    [Field, FieldMapping("CategoryId"), Key]
    public int Id { get; private set; }

    [Field(Length = 15)]
    public string CategoryName { get; set; }

    [Field]
    public string Description { get; set; }

    [Field(LazyLoad = true, Length = 1073741823)]
    public byte[] Picture { get; set; }

    [Field, Association(PairTo = "Category")]
    public EntitySet<Product> Products { get; private set; }

    public Category(Session session)
      : base(session)
    {}
  }

  [TableMapping("Customers")]
  [HierarchyRoot]
  [KeyGenerator(null)]
  public class Customer : Entity
  {
    [Field(Length = 5), FieldMapping("CustomerId"), Key]
    public string Id { get; private set; }

    [Field(Length = 40)]
    public string CompanyName { get; set; }

    [Field(Length = 30)]
    public string ContactName { get; set; }

    [Field(Length = 30)]
    public string ContactTitle { get; set; }

    [Field(Length = 60)]
    public string Address { get; set; }

    [Field(Length = 15)]
    public string City { get; set; }

    [Field(Length = 15)]
    public string Region { get; set; }

    [Field(Length = 10)]
    public string PostalCode { get; set; }

    [Field(Length = 15)]
    public string Country { get; set; }

    [Field(Length = 24)]
    public string Phone { get; set; }

    [Field(Length = 24)]
    public string Fax { get; set; }

    [Field, Association(PairTo = "Customer")]
    public EntitySet<Order> Orders { get; private set; }

    // Constructors

    public Customer(Session session, string id)
      : base(session, id)
    {}
  }

  [HierarchyRoot]
  public class Region : Entity
  {
    [Field, FieldMapping("RegionId"), Key]
    public int Id { get; private set; }

    [Field(Length = 50)]
    public string RegionDescription { get; set; }

    public Region(Session session)
      : base(session)
    {}
  }

  [TableMapping("Suppliers")]
  [HierarchyRoot]
  public class Supplier : Entity
  {
    [Field, FieldMapping("SupplierId"), Key]
    public int Id { get; private set; }

    [Field(Length = 40)]
    public string CompanyName { get; set; }

    [Field(Length = 30)]
    public string ContactName { get; set; }

    [Field(Length = 30)]
    public string ContactTitle { get; set; }

    [Field(Length = 60)]
    public string Address { get; set; }

    [Field(Length = 15)]
    public string City { get; set; }

    [Field(Length = 15)]
    public string Region { get; set; }

    [Field(Length = 10)]
    public string PostalCode { get; set; }

    [Field(Length = 15)]
    public string Country { get; set; }

    [Field(Length = 24)]
    public string Phone { get; set; }

    [Field(Length = 24)]
    public string Fax { get; set; }

    [Field]
    public string HomePage { get; set; }

    public Supplier(Session session)
      : base(session)
    {}
  }

  [TableMapping("Shippers")]
  [HierarchyRoot]
  public class Shipper : Entity
  {
    [Field, FieldMapping("ShipperId"), Key]
    public int Id { get; private set; }

    [Field(Length = 40)]
    public string CompanyName { get; set; }

    [Field(Length = 24)]
    public string Phone { get; set; }

    public Shipper(Session session)
      : base(session)
    {}
  }

  public class ActiveProduct : Product
  {
    public ActiveProduct(Session session) : base(session)
    {}
  }

  public class DiscontinuedProduct : Product
  {
    public DiscontinuedProduct(Session session) : base(session)
    {}
  }

  [TableMapping("Products")]
  [HierarchyRoot(InheritanceSchema.SingleTable)]
  public class Product : Entity
  {
    [Field, FieldMapping("ProductId"), Key]
    public int Id { get; private set; }

    [Field(Length = 40)]
    public string ProductName { get; set; }

    [Field]
    public Supplier Supplier { get; set; }

    [Field]
    public Category Category { get; set; }

    [Field(Length = 20)]
    public string QuantityPerUnit { get; set; }

    [Field]
    public decimal UnitPrice { get; set; }

    [Field]
    public short UnitsInStock { get; set; }

    [Field]
    public short UnitsOnOrder { get; set; }

    [Field]
    public short ReorderLevel { get; set; }

    [Field]
    public bool Discontinued { get; set; }

    public Product(Session session)
      : base(session)
    {}
  }

  [TableMapping("Employees")]
  [HierarchyRoot]
  public class Employee : Entity
  {
    [Field, Key]
    public int Id { get; private set; }

    [Field(Length = 20)]
    public string LastName { get; set; }

    [Field(Length = 10)]
    public string FirstName { get; set; }

    [Field(Length = 30)]
    public string Title { get; set; }

    [Field(Length = 25)]
    public string TitleOfCourtesy { get; set; }

    [Field]
    public DateTime? BirthDate { get; set; }

    [Field]
    public DateTime? HireDate { get; set; }

    [Field(Length = 60)]
    public string Address { get; set; }

    [Field(Length = 15)]
    public string City { get; set; }

    [Field(Length = 15)]
    public string Region { get; set; }

    [Field(Length = 10)]
    public string PostalCode { get; set; }

    [Field(Length = 15)]
    public string Country { get; set; }

    [Field(Length = 24)]
    public string HomePhone { get; set; }

    [Field(Length = 4)]
    public string Extension { get; set; }

    [Field(Length = 1073741823)]
    public byte[] Photo { get; set; }

    [Field(Length = 255)]
    public string PhotoPath { get; set; }

    [Field]
    public string Notes { get; set; }
    
    [Field]
    public Employee ReportsTo { get; set; }

    [Field, Association(PairTo = "ReportsTo")]
    public EntitySet<Employee> ReportingEmployees { get; set; }

    [Field, Association(PairTo = "Employee")]
    public EntitySet<Order> Orders { get; private set; }
    
    [Field]
    public EntitySet<Territory> Territories { get; private set; }

    public Employee(Session session) : base(session)
    {
    }
  }

  [TableMapping("Territories")]
  [HierarchyRoot]
  [KeyGenerator(null)]
  public class Territory : Entity
  {
    [Field(Length = 20), FieldMapping("TerritoryId"), Key]
    public string Id { get; private set; }

    [Field(Length = 50)]
    public string TerritoryDescription { get; set; }

    [Field]
    public Region Region { get; set; }

    [Field, Association(PairTo = "Territories")]
    public EntitySet<Employee> Employees { get; private set; }

    // Constructors

    public Territory(Session session, string id)
      : base(session, id)
    {}
  }

  [TableMapping("Orders")]
  [HierarchyRoot]
  public class Order : Entity
  {
    [Field, FieldMapping("OrderId"), Key]
    public int Id { get; private set; }

    [Field]
    public Customer Customer { get; set; }

    [Field]
    public Employee Employee { get; set; }

    [Field]
    public DateTime? OrderDate { get; set; }

    [Field]
    public DateTime? RequiredDate { get; set; }

    [Field]
    public DateTime? ShippedDate { get; set; }

    [Field]
    public Shipper ShipVia { get; set; }

    [Field]
    public decimal Freight { get; set; }

    [Field(Length = 60)]
    public string ShipName { get; set; }

    [Field(Length = 60)]
    public string ShipAddress { get; set; }

    [Field(Length = 15)]
    public string ShipCity { get; set; }

    [Field(Length = 15)]
    public string ShipRegion { get; set; }

    [Field(Length = 10)]
    public string ShipPostalCode { get; set; }

    [Field(Length = 15)]
    public string ShipCountry { get; set; }

    public Order(Session session) : base(session)
    {}
  }

  [TableMapping("OrderDetails")]
  [HierarchyRoot]
  [KeyGenerator(null)]
  public class OrderDetail : Entity
  {
    [Field, Key(0)]
    public Order Order { get; private set; }

    [Field, Key(1)]
    public Product Product { get; private set; }

    [Field]
    public decimal UnitPrice { get; set; }

    [Field]
    public short Quantity { get; set; }

    [Field]
    public float Discount { get; set; }


    // Constructors

    public OrderDetail(Order order, Product product)
      : base(order.Session, order, product)
    {
    }
  }
}