// Generated code start
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using Xtensive.Core.Disposing;

namespace OrmBattle.Tests.Linq
{
  using EFModel;
  
  [TestFixture]
  public class EFTest
  {
    protected NorthwindEntities db;

    [TestFixtureSetUp]
    public virtual void Setup()
    {
      db = new NorthwindEntities();
      
      Categories = db.Categories.ToList();
      Customers = db.Customers.ToList();
      Employees = db.Employees.ToList();
      Orders = db.Orders.ToList();
      Suppliers = db.Suppliers.ToList();
      
      Console.Out.WriteLine("Entity Framework");
    }

    [TestFixtureTearDown]
    public virtual void TearDown()
    {
      db.Dispose();
    }

    List<Category> Categories;
    List<Customer> Customers;
    List<Employee> Employees;
    List<Order> Orders;
    List<Supplier> Suppliers;
    
    #region Filtering tests

    [Test]
    [Category("Filtering")]
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
    public void SelectTest()
    {
      
    }

    #endregion


    [Test]
    public void AggregateTest1()
    {
      var sum = db.Orders.Select(o => o.Freight).Sum();
      var sum1 = Orders.Select(o => o.Freight).Sum();
      Assert.AreEqual(sum1, sum);
    }

    [Test]
    public void AggregateTest2()
    {
      var count = db.Orders.Count(o => o.Id > 10);
      var count1 = Orders.Count(o => o.Id > 10);
      Assert.AreEqual(count1, count);
    }

    [Test]
    public void AggregateTest3()
    {
      var result = db.Customers.Where(c => db.Orders.Count(o => o.Customer.Id == c.Id) > 5);
      var expected = Customers.Where(c => db.Orders.Count(o => o.Customer.Id == c.Id) > 5);
      
      Assert.IsTrue(expected.Except(result).Count() == 0);
    }

    [Test]
    public void AggregateTest4()
    {
      var sum = db.Orders.Select(o => (int?)o.Id).Sum();
      var sum1 = Orders.Select(o => (int?)o.Id).Sum();
      Assert.AreEqual(sum1, sum);
    }

    [Test]
    public void AggregateTest5()
    {
      var max = db.Customers.Max(c => db.Orders.Count(o => o.Customer.Id == c.Id));
      var max1 = Customers.Max(c => db.Orders.Count(o => o.Customer.Id == c.Id));
      Assert.AreEqual(max1, max);
    }

    [Test]
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
    public void AllAnyTest1()
    {
      var result =
        from c in db.Customers
        where db.Orders.Where(o => o.Customer == c).All(o => db.Employees.Where(e => o.Employee == e).Any(e => e.FirstName.StartsWith("A")))
        select c;
      var list = result.ToList();
      Assert.AreEqual(2, list.Count);
    }

    [Test]
    public void AllAnyTest2()
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
    public void AllAnyTest3()
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
        select new {
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
    public void AllAnyTest4()
    {
      var result = db.Customers.Where(c => c.Orders.Any(o => o.Freight > 400));
      var expected = Customers.Where(c => c.Orders.Any(o => o.Freight > 400));
      Assert.AreEqual(0, expected.Except(result).Count());
      Assert.AreEqual(10, result.ToList().Count);
    }

    [Test]
    public void AllAnyTest5()
    {
      var ids = new[] { "ABCDE", "ALFKI" };
      var result = db.Customers.Where(c => ids.Any(id => c.Id == id));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }
    
    [Test]
    public void AllAnyTest6()
    {
      var customerIDs = new[] {"ALFKI", "ANATR", "AROUT", "BERGS"};
      var result = db.Orders.Where(o => customerIDs.Contains(o.Customer.Id));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(41, list.Count);
    }
    
    
    [Test]
    public void DistinctTest1()
    {
      var result = db.Customers.Select(c => c.Id).Distinct().Take(5);
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void DistinctTest2()
    {
      var result = db.Customers.Select(c => c.Id).Take(5).Distinct();
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void EntitySetReferenceTest()
    {
      var customer = db.Customers.Single(c => c.Id == "ALFKI");
      var result =
        from o in customer.Orders
        join e in db.Employees on o.Employee equals e
        select e;
      Assert.AreEqual(customer.Orders.Count, result.ToList().Count);
    }

    [Test]
    public void FirstSingleTest1()
    {
      var customer = db.Customers.First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void FirstSingleTest2()
    {
      var customer = db.Customers.Where(c => c.Id == "ALFKI").FirstOrDefault();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void FirstSingleTest3()
    {
      var customer = db.Customers.First(c => c.Id == "ALFKI");
      Assert.IsNotNull(customer);
    }

    [Test]
    public void FirstSingleTest4()
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
    public void FirstSingleTest5()
    {
      var customersCount = Customers.Count;
      var result = db.Customers.Select(c => c.Orders.FirstOrDefault());
      var list = result.ToList();
      Assert.AreEqual(customersCount, list.Count);
    }

    [Test]
    public void FirstSingleTest6()
    {
      var customersCount = Customers.Count;
      var result = db.Customers.Select(c => c.Orders.Take(1).SingleOrDefault());
      var list = result.ToList();
      Assert.AreEqual(customersCount, list.Count);
    }

    [Test]
    public void FirstSingleTest7()
    {
      var result = db.Customers.Where(c => c.Orders.Count() > 0).Select(c => c.Orders.Take(1).Single());
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest1()
    {
      var result = db.Products.GroupBy(p => p.UnitPrice);
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest2()
    {
      var category = db.Products
        .GroupBy(p => p.Category)
        .First().Key;
      Assert.IsNotNull(category);
    }

    [Test]
    public void GroupByTest3()
    {
      var result = db.Products
        .GroupBy(p => p.Category)
        .Select(g => g.Where(p2 => p2.UnitPrice == g.Count()));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest4()
    {
      var result = db.Customers.GroupBy(customer => new { customer.City, customer.Address });
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest5()
    {
      var result = db.Orders
        .GroupBy(order => order.ShipCity)
        .Where(grouping => grouping.Key.StartsWith("L"));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest6()
    {
      var result = db.Orders
        .GroupBy(o => o.ShipCity)
        .Where(g => g.Count() > 1);
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest7()
    {
      var result = db.Orders
        .GroupBy(o => o.ShipCity)
        .Select(g => g.Where(o => o.Freight > 0));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest8()
    {
      var result = db.Orders.GroupBy(o => o.ShipName + "String");
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest9()
    {
      var result = db.Customers
        .GroupBy(c => c.City)
        .SelectMany(g => g);

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest10()
    {
      var result = db.Orders
        .GroupBy(o => o.Customer.Id)
        .Select(g => g.Sum(o => o.Freight));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest11()
    {
      var result = db.Orders
        .GroupBy(o => o.Customer)
        .Select(g =>
                new
                {
                  Sum = g.Sum(o => o.Freight),
                  Min = g.Min(o => o.Freight),
                  Max = g.Max(o => o.Freight),
                  Avg = g.Average(o => o.Freight)
                });
      var expected = Orders
        .GroupBy(o => o.Customer)
        .Select(g =>
                new
                {
                  Sum = g.Sum(o => o.Freight),
                  Min = g.Min(o => o.Freight),
                  Max = g.Max(o => o.Freight),
                  Avg = g.Average(o => o.Freight)
                });
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest12()
    {
      var result = db.Customers.GroupBy(c => c.CompanyName.StartsWith("A"));
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest13()
    {
      var result = db.Customers
        .Where(c => c.Orders.Count > 0)
        .GroupBy(c => c.Orders.Average(o => o.Freight) >= 80);
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void GroupByTest14()
    {
      var result = db.Orders
        .GroupBy(o => o.Customer)
        .Select(g => g.Where(o => o.ShipName.StartsWith("A")));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void JoinTest1()
    {
      var result = db.Customers
        .GroupJoin(db.Orders,
                   customer => customer.Id,
                   order => order.Customer.Id,
                   (customer, orders) => new { customer, orders })
        .GroupJoin(db.Employees,
                   customerOrders => customerOrders.customer.City,
                   employee => employee.City,
                   (customerOrders, employees) => new
                   {
                     ords = customerOrders.orders.Count(),
                     emps = employees.Count()
                   });
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void JoinTest2()
    {
      var result =
        from p in db.Products
        join s in db.Suppliers on p.Supplier.Id equals s.Id
        select new { p.ProductName, s.ContactName, s.Phone };

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void JoinTest3()
    {
      var result =
        from c in db.Customers
        join o in db.Orders on c equals o.Customer
        select new { c.ContactName, o.OrderDate };

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void JoinTest4()
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
    public void JoinTest5()
    {
      var result = db.Categories
        .GroupJoin(
        db.Products,
        c => c,
        p => p.Category,
        (c, pGroup) => new { c, pGroup })
        .SelectMany(@t => @t.pGroup.DefaultIfEmpty(),
                    (@t, p) => new { Name = p == null ? "Nothing!" : p.ProductName, @t.c.CategoryName });

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void NestedCollectionsTest1()
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
    public void NestedCollectionsTest2()
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
    public void NestedCollectionsTest3()
    {
      var result = db.Customers
        .Select(c => new { Customer = c, Orders = db.Orders.Where(o => o.Customer == c) })
        .SelectMany(i => i.Orders.Select(o => new { i.Customer, Order = o }));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void NestedCollectionsTest4()
    {
      var result = db.Categories.Where(c => c.Products.Count > 0);

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void OrderByTest1()
    {
      var result = db.Products.Select(p => p).OrderBy(g => g.Id);
      Assert.IsNotNull(result);
    }

    [Test]
    public void OrderByTest2()
    {
      var result = db.OrderDetails
        .Select(od => new { Details = od, Order = od.Order })
        .OrderBy(x => new { x, x.Order.Customer })
        .Select(x => new { x, x.Order.Customer });
      var expected = db.OrderDetails.ToList()
        .Select(od => new { Details = od, Order = od.Order })
        .OrderBy(x => x.Details.Order.Id)
        .ThenBy(x => x.Details.Product.Id)
        .ThenBy(x => x.Details.Order.Id)
        .ThenBy(x => x.Order.Customer.Id)
        .Select(x => new { x, x.Order.Customer });
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    public void OrderByTest3()
    {
      var result = db.Orders
        .OrderBy(o => o.OrderDate)
        .ThenBy(o => o.Freight)
        .Select(o => new { o.OrderDate, o.Freight });
      var expected = db.Orders.ToList()
        .OrderBy(o => o.OrderDate)
        .ThenBy(o => o.Freight)
        .Select(o => new { o.OrderDate, o.Freight });
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    public void OrderByTest4()
    {
      var result = db.Customers.OrderByDescending(c => c.Country)
        .ThenByDescending(c => c.Id).Select(c => c.City);
      var expected = db.Customers.ToList().OrderByDescending(c => c.Country)
        .ThenByDescending(c => c.Id).Select(c => c.City);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    public void OrderByTest5()
    {
      var customers = db.Customers;
      var result = customers.OrderBy(c => c);
      var expected = customers.ToList().OrderBy(c => c.Id);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    public void OrderByTest6()
    {
      var customers = db.Customers;
      List<string> original = customers.Select(c => c.ContactName).ToList().Select(s => s.ToUpper()).ToList();
      original.Sort();
      Assert.IsTrue(original.SequenceEqual(
        customers
          .OrderBy(c => c.ContactName.ToUpper())
          .ToList()
          .Select(c => c.ContactName.ToUpper())));
    }

    [Test]
    public void OrderByTest8()
    {
      var customers = db.Customers;
      List<string> original = customers.Select(c => c.ContactName).ToList();
      original.Sort();

      Assert.IsTrue(original.SequenceEqual(
        customers
          .OrderBy(c => c.ContactName)
          .ToList()
          .Select(c => c.ContactName)));
    }

    [Test]
    public void OrderByTest9()
    {
      var result = db.Customers
        .OrderBy(c => c.Id)
        .Select(c => new { c.Fax, c.Phone });
      var expected = db.Customers.ToList()
        .OrderBy(c => c.Id)
        .Select(c => new { c.Fax, c.Phone });
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    public void OrderByTest10()
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
    public void OrderByTest11()
    {
      var result = db.Customers.OrderBy(c => c.CompanyName)
        .OrderBy(c => c.Country).Select(c => c.City);
      var expected = db.Customers.ToList().OrderBy(c => c.CompanyName)
        .OrderBy(c => c.Country).Select(c => c.City);
      Assert.AreEqual(0, expected.Except(result).Count());
    }

    [Test]
    public void OrderByTest12()
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
    public void OrderByTest13()
    {
      var result = db.Orders.Select(o => o.Employee).Distinct();
      var expected = db.Orders.ToList().Select(o => o.Employee).Distinct();
      Assert.AreEqual(0, result.ToList().Except(expected).Count());
    }

    [Test]
    public void OrderByTest14()
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

    [Test]
    public void OrderByTest15()
    {
      var result = db.Orders.OrderBy(o => o.Freight > 0 && o.ShippedDate != null).ThenBy(o => o.Id).Select(o => o.Id);
      List<int> list = result.ToList();
      List<int> original = db.Orders.ToList().OrderBy(o => o.Freight > 0 && o.ShippedDate != null).ThenBy(o => o.Id).Select(o => o.Id).ToList();
      Assert.IsTrue(list.SequenceEqual(original));
    }

    [Test]
    public void OrderByTest16()
    {
      var result = db.Customers.OrderBy(c => c.Id)
        .Select(c => c.ContactName);
      var expected = db.Customers.ToList().OrderBy(c => c.Id)
        .Select(c => c.ContactName);
      Assert.IsTrue(expected.SequenceEqual(result));
    }

    [Test]
    public void OrderByTest17()
    {
      var result = db.Customers.OrderBy(c => c.Country)
        .ThenBy(c => c.Id).Select(c => c.City);
      var expected = db.Customers.ToList().OrderBy(c => c.Country)
        .ThenBy(c => c.Id).Select(c => c.City);
      Assert.IsTrue(expected.SequenceEqual(result));
    }


    [Test]
    public void SelectManyTest1()
    {
      var result = db.Orders
        .GroupBy(o => o.Customer)
        .SelectMany(g => g.Select(o => o.Customer).Where(c => g.Count() > 2));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectManyTest2()
    {
      var result = db.Orders
        .GroupBy(o => o.Customer)
        .Where(g => g.Count() > 2)
        .SelectMany(g => g.Select(o => o.Customer));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectManyTest3()
    {
      var result = db.Customers.SelectMany(i => i.Orders.Select(t => i));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectManyTest4()
    {
      var result =
        from c in db.Customers
        from o in db.Orders.Where(o => o.Customer == c).Select(o => new { o.Id, c.CompanyName }).DefaultIfEmpty()
        select new { c.ContactName, o };

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectManyTest5()
    {
      var result =
        from c in db.Customers
        from r in (c.Orders.Select(o => c.ContactName + o.ShipName)).Union(c.Orders.Select(o => c.ContactName + o.ShipName))
        orderby r
        select r;

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectTest1()
    {
      var result =
        from p in db.Products
        select p.Supplier.CompanyName;

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectTest2()
    {
      var result =
        from p in db.Products
        select p.Supplier.Address;

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectTest3()
    {
      var result =
        from pd in
          from p in db.Products
          select new { ProductKey = p.Id, p.ProductName, TotalPrice = p.UnitPrice * p.UnitsInStock }
        where pd.TotalPrice > 100
        select new { PKey = pd.ProductKey, pd.ProductName, Total = pd.TotalPrice };

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectTest4()
    {
      var result = from o in db.Orders select o.OrderDate.Value.DayOfWeek;

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SelectTest5()
    {
      var result = from c in db.Customers select c.CompanyName.Equals("lalala");

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SetOperationsTest1()
    {
      var result = db.Customers.Where(c => c.Orders.Count <= 1).Concat(db.Customers.Where(c => c.Orders.Count > 1));

      var list = result.ToList();
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void SetOperationsTest2()
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
      Assert.Greater(list.Count, 0);
    }

    [Test]
    public void TypeCastTest1()
    {
      var result = db.Products.Where(p => p is DiscontinuedProduct);
      var expected = db.Products.ToList().Where(p => p is DiscontinuedProduct);
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
    }

    [Test]
    public void TypeCastTest2()
    {
      var result = db.Products.Where(p => p is Product);
      var expected = db.Products.ToList();
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
    }

    [Test]
    public void TypeCastTest3()
    {
      var result = db.Products.OfType<DiscontinuedProduct>();
      var expected = db.Products.ToList().OfType<DiscontinuedProduct>();
      var list = result.ToList();
      Assert.Greater(list.Count, 0);
      Assert.AreEqual(expected.Count(), list.Count);
    }

    [Test]
    public void TypeCastTest4()
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
    public void TypeCastTest5()
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

    [Test]
    public void WhereTest1()
    {
      var result = db.Customers.Where(c => c.Id.StartsWith("A") || c.Id.StartsWith("L"));

      var list = result.ToList();
      Assert.AreEqual(13, list.Count);
    }

    [Test]
    public void WhereTest2()
    {
      var likeA = "A";
      var likeL = "L";
      var result = db.Customers.Where(c => c.Id.StartsWith(likeA) || c.Id.StartsWith(likeL));

      var list = result.ToList();
      Assert.AreEqual(13, list.Count);
    }

    [Test]
    public void WhereTest3()
    {
      var customerAlfki = db.Customers.Single(c => c.Id == "ALFKI");
      var customer = db.Customers.Where(c => c == customerAlfki).First();

      Assert.AreEqual(customerAlfki, customer);
      Assert.AreSame(customerAlfki, customer);
    }

    [Test]
    public void WhereTest4()
    {
      var customer = db.Customers.Where(c => (c.City ?? "Seattle") == "Seattle").First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void WhereTest5()
    {
      var order = db.Orders.Where(o => (o.Customer.Id == "ALFKI" ? 1000 : 0) == 1000).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest6()
    {
      var customer = db.Customers.Where(c => c.City.Length == 7).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void WhereTest7()
    {
      var customer = db.Customers.Where(c => c.ContactName.Contains("and")).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void WhereTest8()
    {
      var customer = db.Customers.Where(c => c.City.ToLower() == "seattle").First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void WhereTest9()
    {
      var customer = db.Customers.Where(c => c.City.Remove(3) == "Sea").First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void WhereTest10()
    {
      var order = db.Orders.Where(o => o.OrderDate >= new DateTime(o.OrderDate.Value.Year, 1, 1)).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest11()
    {
      var order = db.Orders.Where(o => o.OrderDate.Value.Day == 5).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest12()
    {
      var order = db.Orders.Where(o => o.OrderDate.Value.DayOfWeek == DayOfWeek.Friday).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest13()
    {
      var order = db.Orders.Where(o => o.OrderDate.Value.DayOfYear == 360).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest14()
    {
      var order = db.Orders.Where(o => Math.Abs(o.Id) == 10 || o.Id > 0).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest15()
    {
      var order = db.Orders.Where(o => Math.Asin(Math.Cos(o.Id)) == 0 || o.Id > 0).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest16()
    {
      var order = db.Orders.Where(o => Math.Floor((double)o.Id) == 0 || o.Id > 0).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest17()
    {
      var order = db.Orders.Where(o => Math.Round((decimal)o.Id, 2) == 0 || o.Id > 0).First();
      Assert.IsNotNull(order);
    }

    [Test]
    public void WhereTest18()
    {
      var customer = db.Customers.Where(c => c.City.CompareTo("Seattle") >= 0).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void WhereTest19()
    {
      var customer = db.Customers.Where(c => null != c.City).First();
      Assert.IsNotNull(customer);
    }

    [Test]
    public void WhereTest20()
    {
      var customer = db.Customers.Where(c => !c.Address.Equals(null)).First();
      Assert.IsNotNull(customer);
    }
  }
}
// Generated code end
