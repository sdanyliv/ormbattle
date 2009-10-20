// Copyright (C) 2009 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.31

// This file is generated from LinqTests.tt

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using Xtensive.Core.Disposing;
using Xtensive.Core.Collections;

namespace OrmBattle.Tests.Linq
{
  using Telerik.OpenAccess;
  using Telerik.OpenAccess.Query;
  using TelerikModel.Northwind;
  
  [TestFixture]
  public class OpenAccessTest : LinqTestBase
  {
    protected IObjectScope scope;
    protected NorthwindContext db;

    public override string ToolName {
      get { return "OpenAccess"; }
    }

    public override string ShortToolName {
      get { return "OA"; }
    }

    public override string SourceFileName {
      get { return @"OpenAccessTest.generated.cs"; }
    }

    protected override void Setup()
    {
      scope = NorthwindContext.ObjectScope();
      db = NorthwindContext.CurrentContext;
      
      Customers = db.Customers.ToList();
      Employees = db.Employees.ToList();
      Orders = db.Orders.ToList();
      Products = db.Products.ToList();
    }

    protected override void TearDown()
    {
      scope.Dispose();
    }

    List<Customer> Customers;
    List<Employee> Employees;
    List<Order> Orders;
    List<Product> Products;
    
    // DTO for testing purposes.
    public class OrderDTO
    {
      public int Id { get; set; }
      public string CustomerId { get; set; }
      public DateTime? OrderDate { get; set;}
    }
    
    #region Filtering tests

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereTest()
    {
      var result = from o in db.Orders
                   where o.ShipCity == "Seattle"
                   select o;
      var expected = from o in Orders
                     where o.ShipCity == "Seattle"
                     select o;
      var list = result.ToList();
      Assert.AreEqual(14, list.Count);
      Assert.AreEqual(0, expected.Except(list).Count());
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereParameterTest()
    {
      var city = "Seattle";
      var result = from o in db.Orders
                   where o.ShipCity == city
                   select o;
      var expected = from o in Orders
                     where o.ShipCity == city
                     select o;
      var list = result.ToList();
      Assert.AreEqual(14, list.Count);
      Assert.AreEqual(0, expected.Except(list).Count());
      
      city = "Rio de Janeiro";
      list = result.ToList();
      Assert.AreEqual(34, list.Count);
      Assert.AreEqual(0, expected.Except(list).Count());
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereConditionsTest()
    {
      var result = from p in db.Products
                  where p.UnitsInStock < p.ReorderLevel && p.UnitsOnOrder == 0
                  select p;
      var list = result.ToList();
      Assert.AreEqual(1, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereNullTest()
    {
      var result = from o in db.Orders
                   where o.ShipRegion == null
                   select o;
      var list = result.ToList();
      Assert.AreEqual(507, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereNullParameterTest()
    {
      string region = null;
      var result = from o in db.Orders
                   where o.ShipRegion == region
                   select o;
      var list = result.ToList();
      Assert.AreEqual(507, list.Count);

      region = "WA";
      list = result.ToList();
      Assert.AreEqual(19, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereNullableTest()
    {
      var result = from o in db.Orders
                   where !o.ShippedDate.HasValue
                   select o;
      var list = result.ToList();
      Assert.AreEqual(21, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereNullableParameterTest()
    {
      DateTime? shippedDate = null;
      var result = from o in db.Orders
                   where o.ShippedDate == shippedDate
                   select o;
      var list = result.ToList();
      Assert.AreEqual(21, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereCoalesceTest()
    {
      var result = from o in db.Orders
                   where (o.ShipRegion ?? "N/A") == "N/A"
                   select o;
      var list = result.ToList();
      Assert.AreEqual(507, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereConditionalTest()
    {
      var result = from o in db.Orders
                   where (o.ShipCity == "Seattle" ? "Home" : "Other") == "Home"
                   select o;
      var list = result.ToList();
      Assert.AreEqual(14, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Failed.
    // Exception: SQLException
    // Message:
    //   Incorrect syntax near '='.
    public void WhereConditionalBooleanTest()
    {
      var result = from o in db.Orders
                   where o.ShipCity == "Seattle" ? true : false
                   select o;
      var list = result.ToList();
      Assert.AreEqual(14, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Failed.
    // Exception: ArgumentOutOfRangeException
    // Message:
    //   Using the variable or parameter not possible in this context.
    //   Parameter name: name
    //   Actual value was o.
    public void WhereAnonymousParameterTest()
    {
      var cityRegion = new {City = "Seattle", Region = "WA"};
      var result = from o in db.Orders
                   where new { City = o.ShipCity, Region = o.ShipRegion } == cityRegion
                   select o;
      var list = result.ToList();
      Assert.AreEqual(14, list.Count);
    }

    [Test]
    [Category("Filtering")]
    // Passed.
    public void WhereEntityParameterTest()
    {
      var order = db.Orders.OrderBy(o => o.OrderDate).First();
      var result = from o in db.Orders
                   where o == order
                   select o;
      var list = result.ToList();
      Assert.AreEqual(1, list.Count);
      Assert.AreEqual(order, list[0]);
      Assert.AreSame(order, list[0]);
    }

    #endregion

    #region Projection tests

    [Test]
    [Category("Projections")]
    // Passed.
    public void SelectTest()
    {
      var result = from o in db.Orders
                   select o.ShipRegion;
      var expected = from o in Orders
                     select o.ShipRegion;
      var list = result.ToList();
      Assert.AreEqual(expected.Count(), list.Count);
      Assert.AreEqual(0, expected.Except(list).Count());
    }

    [Test]
    [Category("Projections")]
    // Failed.
    // Exception: OpenAccessException
    // Message:
    //   Invalid projection type used. (OpenAccessRuntime.DataObjects.query.EqualNode)
    public void SelectBooleanTest()
    {
      var result = from o in db.Orders
                   select o.ShipRegion == "WA";
      var expected = from o in Orders
                     select o.ShipRegion == "WA";
      var list = result.ToList();
      Assert.AreEqual(expected.Count(), list.Count);
      Assert.AreEqual(0, expected.Except(list).Count());
    }

    [Test]
    [Category("Projections")]
    // Passed.
    public void SelectCalculatedTest()
    {
      var result = from o in db.Orders
                   select o.Freight * 1000;
      var expected = from o in Orders
                     select o.Freight * 1000;
      var list = result.ToList();
      var expectedList = expected.ToList();
      list.Sort();
      expectedList.Sort();
      Assert.AreEqual(expectedList.Count, list.Count);
      expectedList.Zip(list, (i, j) => {
                               Assert.AreEqual(i,j);
                               return true;
                             });
    }

    [Test]
    [Category("Projections")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Second Select not implemented: OrderExtent.Select(o => (o.Freight * 1000)).Where(r => (r > 100000)).Select(r => (r / 1000))
    public void SelectNestedCalculatedTest()
    {
      var result = from r in
                     from o in db.Orders
                     select o.Freight*1000
                   where r > 100000
                   select r/1000;
      var expected = from o in Orders
                     where o.Freight > 100
                     select o.Freight;
      var list = result.ToList();
      var expectedList = expected.ToList();
      list.Sort();
      expectedList.Sort();
      Assert.AreEqual(187, list.Count);
      Assert.AreEqual(expectedList.Count, list.Count);
      expectedList.Zip(list, (i, j) => {
                               Assert.AreEqual(i,j);
                               return true;
                             });
    }

    [Test]
    [Category("Projections")]
    // Passed.
    public void SelectAnonymousTest()
    {
      var result = from o in db.Orders
                   select new {OrderID = o.Id, o.OrderDate, o.Freight};
      var expected = from o in Orders
                   select new { OrderID = o.Id, o.OrderDate, o.Freight };
      var list = result.ToList();
      Assert.AreEqual(expected.Count(), list.Count);
      Assert.AreEqual(0, expected.Except(list).Count());
    }

    [Test]
    [Category("Projections")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:Where(IQueryable`1,Expression`1)' on the database server side currently not implemented.
    public void SelectSubqueryTest()
    {
      var result = from o in db.Orders
                   select db.Customers.Where(c => c.Id == o.Customer.Id);
      var expected = from o in Orders
                     select Customers.Where(c => c.Id == o.Customer.Id);
      var list = result.ToList();
      Assert.AreEqual(expected.Count(), list.Count);
      expected.Zip(result, (expectedCustomers, actualCustomers) => {
                             Assert.AreEqual(expectedCustomers.Count(), actualCustomers.Count());
                             Assert.AreEqual(0, expectedCustomers.Except(actualCustomers));
                             return true;
                           });
    }

    [Test]
    [Category("Projections")]
    // Passed.
    public void SelectDtoTest()
    {
      var result = from o in db.Orders
                   select new OrderDTO{ Id = o.Id, CustomerId = o.Customer.Id, OrderDate = o.OrderDate};
      var list = result.ToList();
      Assert.AreEqual(Orders.Count(), list.Count);
    }

    [Test]
    [Category("Projections")]
    // Passed.
    public void SelectNestedDtoTest()
    {
      var result = from r in
                     from o in db.Orders
                     select new OrderDTO {Id = o.Id, CustomerId = o.Customer.Id, OrderDate = o.OrderDate}
                   where r.OrderDate > new DateTime(1998, 01, 01)
                   select r;
      var list = result.ToList();
      Assert.AreEqual(267, list.Count);
    }

    [Test]
    [Category("Projections")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.SelectMany(c => c.Orders, (c, o) => new <>f__AnonymousType2`2(c = c, o = o)).Where(<>h__TransparentIdentifier23 => (<>h__TransparentIdentifier23.o.Freight < 500,00))
    public void SelectManyAnonymousTest()
    {
      var result = from c in db.Customers
                   from o in c.Orders
                   where o.Freight < 500.00M
                   select new {CustomerId = c.Id, o.Id, o.Freight};
      var list = result.ToList();
      Assert.AreEqual(817, list.Count);
    }

    [Test]
    [Category("Projections")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.SelectMany(c => c.Orders, (c, o) => new <>f__AnonymousType2`2(c = c, o = o)).Select(<>h__TransparentIdentifier24 => new <>f__AnonymousType4`2(<>h__TransparentIdentifier24 = <>h__TransparentIdentifier24, freight = <>h__TransparentIdentifier24.o.Freight)).Where(<>h__TransparentIdentifier25 => (<>h__TransparentIdentifier25.freight < 500,00))
    public void SelectManyLetTest()
    {
      var result = from c in db.Customers
                   from o in c.Orders
                   let freight = o.Freight
                   where freight < 500.00M
                   select new { CustomerId = c.Id, o.Id, freight };
      var list = result.ToList();
      Assert.AreEqual(817, list.Count);
    }

    [Test]
    [Category("Projections")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Having clauses not implemented yet: OrderExtent.GroupBy(o => o.Customer).Where(g => (g.Count() > 20))
    public void SelectManyGroupByTest()
    {
      var result = db.Orders
        .GroupBy(o => o.Customer)
        .Where(g => g.Count() > 20)
        .SelectMany(g => g.Select(o => o.Customer));

      var list = result.ToList();
      Assert.AreEqual(89, list.Count);
    }

    [Test]
    [Category("Projections")]
    // Failed with assertion.
    // Exception: AssertionException
    // Message:
    //     Expected: 830
    //     But was:  91
    public void SelectManyOuterProjectionTest()
    {
      var result = db.Customers.SelectMany(i => i.Orders.Select(t => i));

      var list = result.ToList();
      Assert.AreEqual(830, list.Count);
    }

    [Test]
    [Category("Projections")]
    // Failed.
    // Exception: InvalidCastException
    // Message:
    //   Object must implement IConvertible.
    public void SelectManyLeftJoinTest()
    {
      var result =
        from c in db.Customers
        from o in c.Orders.Select(o => new { o.Id, c.CompanyName }).DefaultIfEmpty()
        select new { c.ContactName, o };

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    #endregion

    #region Take / Skip tests

    [Test]
    [Category("Take/Skip")]
    // Passed.
    public void TakeTest()
    {
      var result = (from o in db.Orders
                   orderby o.OrderDate, o.Id
                   select o).Take(10);
      var expected = (from o in Orders
                    orderby o.OrderDate, o.Id
                    select o).Take(10);
      var list = result.ToList();
      Assert.AreEqual(10, list.Count);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Take/Skip")]
    // Passed.
    public void SkipTest()
    {
      var result = (from o in db.Orders
                    orderby o.OrderDate, o.Id
                    select o).Skip(10);
      var expected = (from o in Orders
                      orderby o.OrderDate, o.Id
                      select o).Skip(10);
      var list = result.ToList();
      Assert.AreEqual(820, list.Count);
      Assert.IsTrue(expected.SequenceEqual(result));

    }

    [Test]
    [Category("Take/Skip")]
    // Passed.
    public void TakeSkipTest()
    {
      var result = (from o in db.Orders
                    orderby o.OrderDate, o.Id
                    select o).Skip(10).Take(10);
      var expected = (from o in Orders
                      orderby o.OrderDate, o.Id
                      select o).Skip(10).Take(10);
      var list = result.ToList();
      Assert.AreEqual(10, list.Count);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Take/Skip")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Enumerable:Take(IEnumerable`1,Int32)' on the database server side currently not implemented.
    public void TakeNestedTest()
    {
      var result = 
        from c in db.Customers
        select new { Customer = c, TopOrders = c.Orders.OrderByDescending(o => o.OrderDate).Take(5) };
      var expected =
        from c in Customers
        select new { Customer = c, TopOrders = c.Orders.OrderByDescending(o => o.OrderDate).Take(5) };
      var list = result.ToList();
      Assert.AreEqual(expected.Count(), list.Count);
      foreach (var anonymous in list) {
        var count = anonymous.TopOrders.ToList().Count;
        Assert.GreaterOrEqual(count, 0);
        Assert.LessOrEqual(count, 5);
      }
    }

    [Test]
    [Category("Take/Skip")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Second Skip not implemented: OrderExtent.OrderBy(o => o.OrderDate).Skip(100).Take(50).OrderBy(o => o.RequiredDate).Where(o => (o.OrderDate != Convert(null))).Select(o => o.RequiredDate).Distinct().Skip(10)
    public void ComplexTakeSkipTest()
    {
      var original = db.Orders.ToList()
        .OrderBy(o => o.OrderDate)
        .Skip(100)
        .Take(50)
        .OrderBy(o => o.RequiredDate)
        .Where(o => o.OrderDate != null)
        .Select(o => o.RequiredDate)
        .Distinct()
        .Skip(10);
      var result = db.Orders
        .OrderBy(o => o.OrderDate)
        .Skip(100)
        .Take(50)
        .OrderBy(o => o.RequiredDate)
        .Where(o => o.OrderDate != null)
        .Select(o => o.RequiredDate)
        .Distinct()
        .Skip(10);
      var originalList = original.ToList();
      var resultList = result.ToList();
      Assert.AreEqual(originalList.Count, resultList.Count);
      Assert.IsTrue(originalList.SequenceEqual(resultList));
    }

    #endregion

    #region Ordering tests

    [Test]
    [Category("Ordering")]
    // Passed.
    public void OrderByTest()
    {
      var result = 
        from o in db.Orders
        orderby o.OrderDate, o.ShippedDate descending, o.Id
        select o;
      var expected =
        from o in Orders
        orderby o.OrderDate, o.ShippedDate descending, o.Id
        select o;

      var list = result.ToList();
      var expectedList = expected.ToList();
      Assert.AreEqual(expectedList.Count, list.Count);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Ordering")]
    // Passed.
    public void OrderByWhereTest()
    {
      var result = (from o in db.Orders
                    orderby o.OrderDate, o.Id
                    where o.OrderDate > new DateTime(1997, 1, 1)
                    select o).Take(10);
      var expected = (from o in Orders
                      where o.OrderDate > new DateTime(1997, 1, 1)
                      orderby o.OrderDate, o.Id
                      select o).Take(10);
      var list = result.ToList();
      Assert.AreEqual(10, list.Count);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Ordering")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Not implemented: VisitBinary Multiply
    public void OrderByCalculatedColumnTest()
    {
      var result =
        from o in db.Orders
        orderby o.Freight * o.Id descending
        select o;
      var expected =
        from o in Orders
        orderby o.Freight * o.Id descending
        select o;
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Ordering")]
    // Failed.
    // Exception: NullReferenceException
    // Message:
    //   Object reference not set to an instance of an object.
    public void OrderByEntityTest()
    {
      var result =
        from o in db.Orders
        orderby o
        select o;
      var expected =
        from o in Orders
        orderby o.Id
        select o;
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Ordering")]
    // Failed.
    // Exception: InvalidCastException
    // Message:
    //   Unable to cast object of type 'System.Linq.Expressions.NewExpression' to type 'OpenAccessRuntime.DataObjects.query.Node'.
    public void OrderByAnonymousTest()
    {
      var result =
        from o in db.Orders
        orderby new {o.OrderDate, o.ShippedDate, o.Id} 
        select o;
      var expected =
        from o in Orders
        orderby o.OrderDate, o.ShippedDate, o.Id
        select o;
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Ordering")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Second Select not implemented: CustomerExtent.OrderBy(c => c.CompanyName).Select(c => c.City).Distinct().OrderBy(c => c).Select(c => c)
    public void OrderByDistinctTest()
    {
      var result = db.Customers
        .OrderBy(c => c.CompanyName)
        .Select(c => c.City)
        .Distinct()
        .OrderBy(c => c)
        .Select(c => c);
      var expected = db.Customers
        .ToList()
        .Select(c => c.City)
        .Distinct()
        .OrderBy(c => c)
        .Select(c => c);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Ordering")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.OrderBy(c => c.ContactName).SelectMany(c => value(OrmBattle.Tests.Linq.OpenAccessTest).db.Orders.OrderBy(o => o.OrderDate), (c, o) => new <>f__AnonymousType2`2(c = c, o = o)).Where(<>h__TransparentIdentifier5b => (<>h__TransparentIdentifier5b.c = <>h__TransparentIdentifier5b.o.Customer))
    public void OrderBySelectManyTest()
    {
      var result =
        from c in db.Customers.OrderBy(c => c.ContactName)
        from o in db.Orders.OrderBy(o => o.OrderDate)
        where c == o.Customer
        select new { c.ContactName, o.OrderDate };
      var expected =
        from c in db.Customers.ToList().OrderBy(c => c.ContactName)
        from o in db.Orders.ToList().OrderBy(o => o.OrderDate)
        where c == o.Customer
        select new { c.ContactName, o.OrderDate };
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    [Category("Ordering")]
    // Failed.
    // Exception: OpenAccessException
    // Message:
    //   Invalid node in orders: AndNode@2ca534
    public void OrderByPredicateTest()
    {
      var result = db.Orders.OrderBy(o => o.Freight > 0 && o.ShippedDate != null).ThenBy(o => o.Id).Select(o => o.Id);
      var list = result.ToList();
      var original = Orders.OrderBy(o => o.Freight > 0 && o.ShippedDate != null).ThenBy(o => o.Id).Select(o => o.Id).ToList();
      Assert.IsTrue(list.SequenceEqual(original));
    }

    #endregion

    #region Grouping tests

    [Test]
    [Category("Grouping")]
    // Passed.
    public void GroupByTest()
    {
      var result = from o in db.Orders
                   group o by o.OrderDate;
      var list = result.ToList();
      Assert.AreEqual(480, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Passed.
    public void GroupByReferenceTest()
    {
      var result = from o in db.Orders
                   group o by o.Customer;
      var list = result.ToList();
      Assert.AreEqual(89, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Having clauses not implemented yet: OrderExtent.GroupBy(o => o.OrderDate).Where(g => (g.Count() > 5))
    public void GroupByWhereTest()
    {
      var result = 
        from o in db.Orders
        group o by o.OrderDate into g
                                 where g.Count() > 5
                                 select g;
      var list = result.ToList();
      Assert.AreEqual(1, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Passed.
    public void GroupByTestAnonymous()
    {
      var result = from c in db.Customers
                   group c by new {c.Region, c.City};
      var list = result.ToList();
      Assert.AreEqual(69, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Failed.
    // Exception: InvalidOperationException
    // Message:
    //   The query contains a 'Group By' expression but no aggregates.
    public void GroupByCalculatedTest()
    {
      var result =
        from o in db.Orders
        group o by o.Freight > 50 ? o.Freight > 100 ? "expensive" : "average" : "cheap" into g
                                                                                          select g;
      var list = result.ToList();
      Assert.AreEqual(3, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Failed.
    // Exception: InvalidCastException
    // Message:
    //   Unable to cast object of type 'System.String' to type 'OrmBattle.TelerikModel.Northwind.Customer'.
    public void GroupBySelectManyTest()
    {
      var result = db.Customers
        .GroupBy(c => c.City)
        .SelectMany(g => g);

      var list = result.ToList();
      Assert.AreEqual(91, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Passed.
    public void GroupByCalculateAggregateTest()
    {
      var result = 
        from o in db.Orders
        group o by o.Customer into g
        select g.Sum(o => o.Freight);

      var list = result.ToList();
      Assert.AreEqual(89, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Passed.
    public void GroupByCalculateManyAggreagetes()
    {
      var result = 
        from o in db.Orders
        group o by o.Customer into g
                                select  new
                                        {
                                          Sum = g.Sum(o => o.Freight),
                                          Min = g.Min(o => o.Freight),
                                          Max = g.Max(o => o.Freight),
                                          Avg = g.Average(o => o.Freight)
                                        };

      var list = result.ToList();
      Assert.AreEqual(89, list.Count);
    }

    [Test]
    [Category("Grouping")]
    // Failed.
    // Exception: OpenAccessException
    // Message:
    //   Identifier 'Freight' is not a parameter or variable or field of 'OrmBattle.TelerikModel.Northwind.Customer'. If 'Freight' is a property please add the FieldAlias attribute to it.
    public void GroupByAggregate()
    {
      var result = 
        from c in db.Customers
        group c by c.Orders.Average(o => o.Freight) >= 80;
      var list = result.ToList();
      Assert.AreEqual(2, list.Count);
      var firstGroupList = list.First(g => !g.Key).ToList();
      Assert.AreEqual(71, firstGroupList.Count);
    }

    [Test]
    [Category("Grouping")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Enumerable:Select(IEnumerable`1,Func`2)' on the database server side currently not implemented.
    public void ComplexGroupingTest()
    {
      var result = 
        from c in db.Customers
        select new {
          c.CompanyName, 
          YearGroups =
            from o in c.Orders
            group o by o.OrderDate.Value.Year into yg
            select new {
              Year = yg.Key,
              MonthGroups = 
                from o in yg
                group o by o.OrderDate.Value.Month into mg
                select new { Month = mg.Key, Orders = mg }
              }
          };
      var list = result.ToList();
      foreach (var customer in list) {
        var ordersList = customer.YearGroups.ToList();
        Assert.LessOrEqual(ordersList.Count, 3);
      }
    }

    #endregion

    #region Set operations / Distinct tests

    [Test]
    [Category("Set operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.Where(c => (c.Orders.Count <= 1)).Concat(CustomerExtent.Where(c => (c.Orders.Count > 1)))
    public void ConcatTest()
    {
      var result = db.Customers.Where(c => c.Orders.Count <= 1).Concat(db.Customers.Where(c => c.Orders.Count > 1));
      var list = result.ToList();
      Assert.AreEqual(91, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.Select(c => c.Phone).Union(CustomerExtent.Select(c => c.Fax))
    public void UnionTest()
    {
      var result = (
                     from c in db.Customers
                     select c.Phone)
        .Union(
        from c in db.Customers
        select c.Fax)
        .Union(
        from e in db.Employees
        select e.HomePhone
        );

      var list = result.ToList();
      Assert.AreEqual(167, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.Except(CustomerExtent.Where(c => (c.Orders.Count() > 0)))
    public void ExceptTest()
    {
      var result =
        db.Customers.Except(db.Customers.Where(c => c.Orders.Count() > 0));
      var list = result.ToList();
      Assert.AreEqual(2, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.Intersect(CustomerExtent.Where(c => (c.Orders.Count() > 0)))
    public void IntersectTest()
    {
      var result =
        db.Customers.Intersect(db.Customers.Where(c => c.Orders.Count() > 0));
      var list = result.ToList();
      Assert.AreEqual(89, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Passed.
    public void DistinctTest()
    {
      var result = db.Orders.Select(c => c.Freight).Distinct();
      var list = result.ToList();
      Assert.AreEqual(799, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Passed.
    public void DistinctTakeLastTest()
    {
      var result = 
        (from o in db.Orders
         orderby o.OrderDate
         select o.OrderDate).Distinct().Take(5);
      var list = result.ToList();
      Assert.AreEqual(5, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Failed with assertion.
    // Exception: AssertionException
    // Message:
    //     Expected: 4
    //     But was:  5
    public void DistinctTakeFirstTest()
    {
      var result =
        (from o in db.Orders
         orderby o.OrderDate
         select o.OrderDate).Take(5).Distinct();
      var list = result.ToList();
      Assert.AreEqual(4, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Passed.
    public void DistinctEntityTest()
    {
      var result = db.Customers.Distinct();
      var list = result.ToList();
      Assert.AreEqual(91, list.Count);
    }

    [Test]
    [Category("Set operations")]
    // Passed.
    public void DistinctAnonymousTest()
    {
      var result = db.Customers.Select(c => new {c.Region, c.City}).Distinct();
      var list = result.ToList();
      Assert.AreEqual(69, list.Count);
    }

    #endregion

    #region Type casts

    [Test]
    [Category("Type casts")]
    // Passed.
    public void TypeCastIsChildTest()
    {
      var result = db.Products.Where(p => p is DiscontinuedProduct);
      var expected = db.Products.ToList().Where(p => p is DiscontinuedProduct);
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
    }

    [Test]
    [Category("Type casts")]
    // Passed.
    public void TypeCastIsParentTest()
    {
      var result = db.Products.Where(p => p is Product);
      var expected = db.Products.ToList();
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
    }

    [Test]
    [Category("Type casts")]
    // Failed.
    // Exception: NullReferenceException
    // Message:
    //   Object reference not set to an instance of an object.
    public void TypeCastIsChildConditionalTest()
    {
      var result = db.Products
        .Select(x => x is DiscontinuedProduct
                       ? x
                       : null);

      var expected = db.Products.ToList()
        .Select(x => x is DiscontinuedProduct
                       ? x
                       : null);

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
      Assert.IsTrue(list.Except(expected).Count() == 0);
      Assert.IsTrue(list.Contains(null));
    }

    [Test]
    [Category("Type casts")]
    // Passed.
    public void TypeCastOfTypeTest()
    {
      var result = db.Products.OfType<DiscontinuedProduct>();
      var expected = db.Products.ToList().OfType<DiscontinuedProduct>();
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
    }

    [Test]
    [Category("Type casts")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Second Select not implemented: DiscontinuedProductExtent.Select(discontinuedProduct => (discontinuedProduct As Product)).Select(product => IIF((product = null), "NULL", product.ProductName))
    public void TypeCastAsTest()
    {
      var result = db.DiscontinuedProducts
        .Select(discontinuedProduct => discontinuedProduct as Product)
        .Select(product =>
                product == null
                  ? "NULL"
                  : product.ProductName);

      var expected = db.DiscontinuedProducts.ToList()
        .Select(discontinuedProduct => discontinuedProduct as Product)
        .Select(product =>
                product == null
                  ? "NULL"
                  : product.ProductName);

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
      Assert.IsTrue(list.Except(expected).Count() == 0);
    }

    #endregion

    #region Element operations

    [Test]
    [Category("Element operations")]
    // Passed.
    public void FirstTest()
    {
      var customer = db.Customers.First();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Element operations")]
    // Passed.
    public void FirstOrDefaultTest()
    {
      var customer = db.Customers.Where(c => c.Id == "ALFKI").FirstOrDefault();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Element operations")]
    // Passed.
    public void FirstPredicateTest()
    {
      var customer = db.Customers.First(c => c.Id == "ALFKI");
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Element operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:FirstOrDefault(IQueryable`1)' on the database server side currently not implemented.
    public void NestedFirstOrDefaultTest()
    {
      var result =
        from p in db.Products
        select new
               {
                 ProductID = p.Id,
                 MaxOrder = db.OrderDetails
          .Where(od => od.Product == p)
          .OrderByDescending(od => od.UnitPrice * od.Quantity)
          .FirstOrDefault()
          .Order
               };
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    [Category("Element operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Enumerable:FirstOrDefault(IEnumerable`1)' on the database server side currently not implemented.
    public void FirstOrDefaultEntitySetTest()
    {
      var customersCount = Customers.Count;
      var result = db.Customers.Select(c => c.Orders.FirstOrDefault());
      var list = result.ToList();
      Assert.AreEqual(customersCount, list.Count);
    }

    [Test]
    [Category("Element operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Enumerable:SingleOrDefault(IEnumerable`1)' on the database server side currently not implemented.
    public void NestedSingleOrDefaultTest()
    {
      var customersCount = Customers.Count;
      var result = db.Customers.Select(c => c.Orders.Take(1).SingleOrDefault());
      var list = result.ToList();
      Assert.AreEqual(customersCount, list.Count);
    }

    [Test]
    [Category("Element operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Enumerable:Single(IEnumerable`1)' on the database server side currently not implemented.
    public void NestedSingleTest()
    {
      var result = db.Customers.Where(c => c.Orders.Count() > 0).Select(c => c.Orders.Take(1).Single());
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    [Category("Element operations")]
    // Passed.
    public void ElementAtTest()
    {
      var customer = db.Customers.OrderBy(c => c.Id).ElementAt(15);
      Assert.IsNotNull(customer);
      Assert.AreEqual("CONSH", customer.Id);
    }

    [Test]
    [Category("Element operations")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Enumerable:ElementAt(IEnumerable`1,Int32)' on the database server side currently not implemented.
    public void NestedElementAtTest()
    {
      var result = 
        from c in db.Customers
        where c.Orders.Count() > 5
        select c.Orders.ElementAt(3);

      var list = result.ToList();
      Assert.AreEqual(63, list.Count);
    }
    
    #endregion


    #region Contains / Any / All tests

    [Test]
    [Category("All/Any/Contains")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:All(IQueryable`1,Expression`1)' on the database server side currently not implemented.
    public void AllNestedTest()
    {
      var result =
        from c in db.Customers
        where db.Orders.Where(o => o.Customer == c).All(o => db.Employees.Where(e => o.Employee == e).Any(e => e.FirstName.StartsWith("A")))
        select c;
      var list = result.ToList();
      Assert.AreEqual(2, list.Count);
    }

    [Test]
    [Category("All/Any/Contains")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:All(IQueryable`1,Expression`1)' on the database server side currently not implemented.
    public void ComplexAllTest()
    {
      var result =
        from o in db.Orders
        where
          db.Customers.Where(c => c == o.Customer).All(c => c.CompanyName.StartsWith("A")) ||
          db.Employees.Where(e => e == o.Employee).All(e => e.FirstName.EndsWith("t"))
        select o;
      var expected =
        from o in Orders
        where
          Customers.Where(c => c == o.Customer).All(c => c.CompanyName.StartsWith("A")) ||
          Employees.Where(e => e == o.Employee).All(e => e.FirstName.EndsWith("t"))
        select o;

      Assert.AreEqual(0, expected.Except(result).Count());
      Assert.AreEqual(result.ToList().Count, 366);
    }

    [Test]
    [Category("All/Any/Contains")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:Contains(IQueryable`1,Customer)' on the database server side currently not implemented.
    public void ContainsNestedTest()
    {
      var result = from c in db.Customers
                   select new
                          {
                            Customer = c,
                            HasNewOrders = db.Orders
                     .Where(o => o.OrderDate > new DateTime(2001, 1, 1))
                     .Select(o => o.Customer)
                     .Contains(c)
                          };

      var expected =
        from c in Customers
        select new
               {
                 Customer = c,
                 HasNewOrders = Orders
          .Where(o => o.OrderDate > new DateTime(2001, 1, 1))
          .Select(o => o.Customer)
          .Contains(c)
               };
      Assert.AreEqual(0, expected.Except(result).Count());
      Assert.AreEqual(0, result.ToList().Count(i => i.HasNewOrders));
    }

    [Test]
    [Category("All/Any/Contains")]
    // Passed.
    public void AnyTest()
    {
      var result = db.Customers.Where(c => c.Orders.Any(o => o.Freight > 400));
      var expected = Customers.Where(c => c.Orders.Any(o => o.Freight > 400));
      Assert.AreEqual(0, expected.Except(result).Count());
      Assert.AreEqual(10, result.ToList().Count);
    }

    [Test]
    [Category("All/Any/Contains")]
    // Failed.
    // Exception: InvalidOperationException
    // Message:
    //   Must specify parameter on right side of operation.
    public void AnyParameterizedTest()
    {
      var ids = new[] { "ABCDE", "ALFKI" };
      var result = db.Customers.Where(c => ids.Any(id => c.Id == id));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    [Category("All/Any/Contains")]
    // Passed.
    public void ContainsParameterizedTest()
    {
      var customerIDs = new[] { "ALFKI", "ANATR", "AROUT", "BERGS" };
      var result = db.Orders.Where(o => customerIDs.Contains(o.Customer.Id));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(41, list.Count);
    }

    #endregion

    #region Aggregates tests

    [Test]
    [Category("Aggregates")]
    // Passed.
    public void SumTest()
    {
      var sum = db.Orders.Select(o => o.Freight).Sum();
      var sum1 = Orders.Select(o => o.Freight).Sum();
      Assert.AreEqual(sum1, sum);
    }

    [Test]
    [Category("Aggregates")]
    // Passed.
    public void CountPredicateTest()
    {
      var count = db.Orders.Count(o => o.Id > 10);
      var count1 = Orders.Count(o => o.Id > 10);
      Assert.AreEqual(count1, count);
    }

    [Test]
    [Category("Aggregates")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:Count(IQueryable`1,Expression`1)' on the database server side currently not implemented.
    public void NestedCountTest()
    {
      var result = db.Customers.Where(c => db.Orders.Count(o => o.Customer.Id == c.Id) > 5);
      var expected = Customers.Where(c => db.Orders.Count(o => o.Customer.Id == c.Id) > 5);
      
      Assert.IsTrue(expected.Except(result).Count() == 0);
    }

    [Test]
    [Category("Aggregates")]
    // Passed.
    public void NullableSumTest()
    {
      var sum = db.Orders.Select(o => (int?)o.Id).Sum();
      var sum1 = Orders.Select(o => (int?)o.Id).Sum();
      Assert.AreEqual(sum1, sum);
    }

    [Test]
    [Category("Aggregates")]
    // Failed.
    // Exception: InvalidCastException
    // Message:
    //   Unable to cast object of type 'System.Linq.Expressions.UnaryExpression' to type 'System.Linq.Expressions.Expression`1[System.Func`2[OrmBattle.TelerikModel.Northwind.Customer,System.Int32]]'.
    public void MaxCountTest()
    {
      var max = db.Customers.Max(c => db.Orders.Count(o => o.Customer.Id == c.Id));
      var max1 = Customers.Max(c => db.Orders.Count(o => o.Customer.Id == c.Id));
      Assert.AreEqual(max1, max);
    }

    #endregion

    #region Join tests

    [Test]
    [Category("Join")]
    // Passed.
    public void GroupJoinTest()
    {
      var result = 
        from c in db.Customers
        join o in db.Orders on c.Id equals o.Customer.Id into go
        join e in db.Employees on c.City equals e.City into ge
        select new {
                     OrdersCount = go.Count(),
                     EmployeesCount = ge.Count()
                   };
      var list = result.ToList();
      Assert.AreEqual(91, list.Count);
    }

    [Test]
    [Category("Join")]
    // Passed.
    public void JoinTest()
    {
      var result =
        from p in db.Products
        join s in db.Suppliers on p.Supplier.Id equals s.Id
        select new { p.ProductName, s.ContactName, s.Phone };

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    [Category("Join")]
    // Passed.
    public void JoinByAnonymousTest()
    {
      var result =
        from c in db.Customers
        join o in db.Orders on new { Customer = c, Name = c.ContactName } equals
          new { o.Customer, Name = o.Customer.ContactName }
        select new { c.ContactName, o.OrderDate };

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    [Category("Join")]
    // Passed.
    public void LeftJoinTest()
    {
      var result = 
        from c in db.Categories
        join p in db.Products on c.Id equals p.Category.Id into g
        from p in g.DefaultIfEmpty()
        select new { Name = p == null ? "Nothing!" : p.ProductName, c.CategoryName };
        
      var list = result.ToList();
      Assert.AreEqual(77, list.Count);
    }

    #endregion

    #region References tests

    [Test]
    [Category("References")]
    // Passed.
    public void JoinByReferenceTest()
    {
      var result =
        from c in db.Customers
        join o in db.Orders on c equals o.Customer
        select new { c.ContactName, o.OrderDate };

      var list = result.ToList();
      Assert.AreEqual(830, list.Count);
    }

    [Test]
    [Category("References")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   CustomerExtent.SelectMany(c => value(OrmBattle.Tests.Linq.OpenAccessTest).db.Orders, (c, o) => new <>f__AnonymousType2`2(c = c, o = o)).Where(<>h__TransparentIdentifiera3 => (<>h__TransparentIdentifiera3.c = <>h__TransparentIdentifiera3.o.Customer))
    public void CompareReferenceTest()
    {
      var result =
        from c in db.Customers
        from o in db.Orders
        where c == o.Customer
        select new { c.ContactName, o.OrderDate };

      var list = result.ToList();
      Assert.AreEqual(830, list.Count);
    }

    [Test]
    [Category("References")]
    // Passed.
    public void ReferenceNavigationTestTest()
    {
      var result =
        from od in db.OrderDetails
        where od.Product.Category.CategoryName == "Seafood"
        select new {od.Order, od.Product};

      var list = result.ToList();
      Assert.AreEqual(330, list.Count);
      foreach (var anonymous in list) {
        Assert.IsNotNull(anonymous);
        Assert.IsNotNull(anonymous.Order);
        Assert.IsNotNull(anonymous.Product);
      }
    }

    [Test]
    [Category("References")]
    // Passed.
    public void EntitySetCountTest()
    {
      var result = db.Categories.Where(c => c.Products.Count > 10);
      var list = result.ToList();
      Assert.AreEqual(4, list.Count);
    }

    #endregion


    #region Complex tests

    [Test]
    [Category("Complex")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:Select(IQueryable`1,Expression`1)' on the database server side currently not implemented.
    public void ComplexTest1()
    {
      var result = db.Suppliers.Select(
        supplier => db.Products.Select(
                      product => db.Products.Where(p => p.Id == product.Id && p.Supplier.Id == supplier.Id)));
      var count = result.ToList().Count;
      Assert.Greater(count, 0);
      foreach (var queryable in result) {
        foreach (var queryable1 in queryable) {
          foreach (var product in queryable1) {
            Assert.IsNotNull(product);
          }
        }
      }
    }

    [Test]
    [Category("Complex")]
    // Failed.
    // Exception: NotImplementedException
    // Message:
    //   GroupBy with restrictions on group not implemented yet.
    public void ComplexTest2()
    {
      var result = db.Customers
        .GroupBy(c => c.Country, (country, customers) => customers.Where(k => k.CompanyName.Substring(0, 1) == country.Substring(0, 1)))
        .SelectMany(k => k);
      var expected = Customers
        .GroupBy(c => c.Country, (country, customers) => customers.Where(k => k.CompanyName.Substring(0, 1) == country.Substring(0, 1)))
        .SelectMany(k => k);
        
      Assert.AreEqual(0, expected.Except(result).Count());
    }

    [Test]
    [Category("Complex")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:Select(IQueryable`1,Expression`1)' on the database server side currently not implemented.
    public void ComplexTest3()
    {
      var products = db.Products;
      var suppliers = db.Suppliers;
      var result = from p in products
                   select new
                          {
                            Product = p,
                            Suppliers = suppliers
                     .Where(s => s.Id == p.Supplier.Id)
                     .Select(s => s.CompanyName)
                          };
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      foreach (var p in list)
        foreach (var companyName in p.Suppliers)
          Assert.IsNotNull(companyName);
    }

    [Test]
    [Category("Complex")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Second Select not implemented: CustomerExtent.Take(2).Select(c => value(OrmBattle.Tests.Linq.OpenAccessTest).db.Orders.Select(o => value(OrmBattle.Tests.Linq.OpenAccessTest).db.Employees.Take(2).Where(e => e.Orders.Contains(o))).Where(o => (o.Count() > 0))).Select(os => os)
    public void ComplexTest4()
    {
      var result = db.Customers
        .Take(2)
        .Select(c => db.Orders.Select(o => db.Employees.Take(2).Where(e => e.Orders.Contains(o))).Where(o => o.Count() > 0))
        .Select(os => os);

      var list = result.ToList();
      Assert.Greater(list.Count, 0);

      foreach (var item in list)
        item.ToList();
    }

    [Test]
    [Category("Complex")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Second Select not implemented: CustomerExtent.Select(c => new <>f__AnonymousType1a`2(Customer = c, Orders = value(OrmBattle.Tests.Linq.OpenAccessTest).db.Orders)).Select(i => i.Customer.Orders)
    public void ComplexTest5()
    {
      var result = db.Customers
        .Select(c => new { Customer = c, Orders = db.Orders })
        .Select(i => i.Customer.Orders);

      var list = result.ToList();
      Assert.Greater(list.Count, 0);

      foreach (var item in list)
        item.ToList();
    }

    [Test]
    [Category("Complex")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Linq.Queryable:Where(IQueryable`1,Expression`1)' on the database server side currently not implemented.
    public void ComplexTest6()
    {
      var result = db.Customers
        .Select(c => new { Customer = c, Orders = db.Orders.Where(o => o.Customer == c) })
        .SelectMany(i => i.Orders.Select(o => new { i.Customer, Order = o }));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    #endregion

    #region Standard functions tests

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void StringStartsWithTest()
    {
      var result = db.Customers.Where(c => c.Id.StartsWith("A") || c.Id.StartsWith("L"));

      var list = result.ToList();
      Assert.AreEqual(13, list.Count);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void StringStartsWithParameterizedTest()
    {
      var likeA = "A";
      var likeL = "L";
      var result = db.Customers.Where(c => c.Id.StartsWith(likeA) || c.Id.StartsWith(likeL));

      var list = result.ToList();
      Assert.AreEqual(13, list.Count);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void StringLengthTest()
    {
      var customer = db.Customers.Where(c => c.City.Length == 7).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void StringContainsTest()
    {
      var customer = db.Customers.Where(c => c.ContactName.Contains("and")).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void StringToLowerTest()
    {
      var customer = db.Customers.Where(c => c.City.ToLower() == "seattle").First();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void StringRemoveTest()
    {
      var customer = db.Customers.Where(c => c.City.Remove(3) == "Sea").First();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: ArgumentOutOfRangeException
    // Message:
    //   Using the variable or parameter not possible in this context.
    //   Parameter name: name
    //   Actual value was o.
    public void DateTimeTest()
    {
      var order = db.Orders.Where(o => o.OrderDate >= new DateTime(o.OrderDate.Value.Year, 1, 1)).First();
      Assert.IsNotNull(order);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void DateTimeDayTest()
    {
      var order = db.Orders.Where(o => o.OrderDate.Value.Day == 5).First();
      Assert.IsNotNull(order);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.DateTime:get_DayOfWeek()' on the database server side currently not implemented.
    public void DateTimeDayOfWeek()
    {
      var order = db.Orders.Where(o => o.OrderDate.Value.DayOfWeek == DayOfWeek.Friday).First();
      Assert.IsNotNull(order);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.DateTime:get_DayOfYear()' on the database server side currently not implemented.
    public void DateTimeDayOfYear()
    {
      var order = db.Orders.Where(o => o.OrderDate.Value.DayOfYear == 360).First();
      Assert.IsNotNull(order);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Abs(Int32)' on the database server side currently not implemented.
    public void MathAbsTest()
    {
      var order = db.Orders.Where(o => Math.Abs(o.Id) == 10 || o.Id > 0).First();
      Assert.IsNotNull(order);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Asin(Double)' on the database server side currently not implemented.
    public void MathTrignometricTest()
    {
      var order = db.Orders.Where(o => Math.Asin(Math.Cos(o.Id)) == 0 || o.Id > 0).First();
      Assert.IsNotNull(order);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Floor(Decimal)' on the database server side currently not implemented.
    public void MathFloorTest()
    {
      var result = db.Orders.Where(o => Math.Floor(o.Freight) == 140);
      var list = result.ToList();
      Assert.AreEqual(2, list.Count);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Ceiling(Decimal)' on the database server side currently not implemented.
    public void MathCeilingTest()
    {
      var result = db.Orders.Where(o => Math.Ceiling(o.Freight) == 141);
      var list = result.ToList();
      Assert.AreEqual(2, list.Count);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Truncate(Decimal)' on the database server side currently not implemented.
    public void MathTruncateTest()
    {
      var result = db.Orders.Where(o => Math.Truncate(o.Freight) == 141);
      var list = result.ToList();
      Assert.AreEqual(2, list.Count);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Round(Decimal,Int32,MidpointRounding)' on the database server side currently not implemented.
    public void MathRoundAwayFromZeroTest()
    {
      var result = db.Orders.Where(o => Math.Round(o.Freight/10, 1, MidpointRounding.AwayFromZero) == 6.5m );
      var list = result.ToList();
      Assert.AreEqual(7, list.Count);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Round(Decimal,Int32,MidpointRounding)' on the database server side currently not implemented.
    public void MathRoundToEvenTest()
    {
      var result = db.Orders.Where(o => Math.Round(o.Freight / 10, 1, MidpointRounding.ToEven) == 6.5m);
      var list = result.ToList();
      Assert.AreEqual(6, list.Count);
    }

    [Test]
    [Category("Standard functions")]
    // Failed.
    // Exception: NotSupportedException
    // Message:
    //   Execution of 'System.Math:Round(Decimal,Int32)' on the database server side currently not implemented.
    public void MathRoundDefaultTest()
    {
      var result = db.Orders.Where(o => Math.Round(o.Freight / 10, 1) == 6.5m);
      var list = result.ToList();
      Assert.AreEqual(6, list.Count);
    }


    [Test]
    [Category("Standard functions")]
    // Passed.
    public void StringCompareToTest()
    {
      var customer = db.Customers.Where(c => c.City.CompareTo("Seattle") >= 0).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void ComparisonWithNullTest()
    {
      var customer = db.Customers.Where(c => null != c.City).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    [Category("Standard functions")]
    // Passed.
    public void EqualsWithNullTest()
    {
      var customer = db.Customers.Where(c => !c.Address.Equals(null)).First();
      Assert.IsNotNull(customer);
    }

    #endregion
  }
}
