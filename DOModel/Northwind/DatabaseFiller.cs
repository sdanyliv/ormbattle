// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.09

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xtensive.Storage;

namespace OrmBattle.DOModel.Northwind
{
  public class DataBaseFiller
  {
    private static readonly SqlConnection con = new SqlConnection("Data Source=localhost;"
      + "Initial Catalog = Northwind;"
        + "Integrated Security=SSPI;");

    public static void Fill(Domain domain)
    {
      con.Open();
      SqlTransaction transaction = con.BeginTransaction();
      SqlCommand cmd = con.CreateCommand();
      cmd.Transaction = transaction;
      cmd.CommandText = "Select * from [dbo].[Categories]";
      var reader = cmd.ExecuteReader();

      using (Session.Open(domain))
      using (var tr = Transaction.Open())
      {
        #region  Categories

        var categories = new Dictionary<object, Category>();
        if (reader != null)
        {
          while (reader.Read())
          {
            var category = new Category();
            for (int i = 1; i < reader.FieldCount; i++)
              category[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
            categories.Add(reader.GetValue(0), category);
          }
          reader.Close();
        }

        #endregion

        #region Customers

        var customers = new Dictionary<object, Customer>();
        cmd.CommandText = "Select * from [dbo].[Customers]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var customer = new Customer(reader.GetString(0));
            for (int i = 1; i < reader.FieldCount; i++)
              customer[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
            customers.Add(reader.GetValue(0), customer);
          }
          reader.Close();
        }

        #endregion

        #region Regions

        var regions = new Dictionary<object, Region>();
        cmd.CommandText = "Select * from [dbo].[Region]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var region = new Region();
            for (int i = 1; i < reader.FieldCount; i++)
              region[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
            regions.Add(reader.GetValue(0), region);
          }
          reader.Close();
        }

        #endregion

        #region Suppliers

        var suppliers = new Dictionary<object, Supplier>();
        cmd.CommandText = "Select * from [dbo].[Suppliers]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var supplier = new Supplier();
            for (int i = 1; i < reader.FieldCount; i++)
              supplier[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
            suppliers.Add(reader.GetValue(0), supplier);
          }
          reader.Close();
        }

        #endregion

        #region Shippers

        var shippers = new Dictionary<object, Shipper>();
        cmd.CommandText = "Select * from [dbo].[Shippers]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var shipper = new Shipper();
            for (int i = 1; i < reader.FieldCount; i++)
              shipper[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
            shippers.Add(reader.GetValue(0), shipper);
          }
          reader.Close();
        }

        #endregion

        #region Products

        var products = new Dictionary<object, Product>();
        cmd.CommandText = "Select * from [dbo].[Products]";
        reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
        if (reader != null)
        {
          while (reader.Read())
          {
            var discontinuedColumnIndex = reader.GetOrdinal("Discontinued");
            Product product = reader.GetBoolean(discontinuedColumnIndex)
              ? (Product)new DiscontinuedProduct()
              : new ActiveProduct();
            for (int i = 1; i < reader.FieldCount; i++)
              switch (i)
              {
                case 2:
                  product.Supplier = !reader.IsDBNull(i) ? suppliers[reader.GetValue(i)] : null;
                  break;
                case 3:
                  product.Category = !reader.IsDBNull(i) ? categories[reader.GetValue(i)] : null;
                  break;
                default:
                  if (i != discontinuedColumnIndex)
                    product[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
                  break;
              }
            products.Add(reader.GetValue(0), product);
          }
          reader.Close();
        }

        #endregion

        #region Employees

        var employees = new Dictionary<object, Employee>();
        cmd.CommandText = "Select * from [dbo].[Employees]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var employee = new Employee();
            for (int i = 1; i < reader.FieldCount; i++)
              if (i != 16)
                employee[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
            employees.Add(reader.GetValue(0), employee);
          }
          reader.Close();
        }

        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var employee = employees[reader.GetValue(0)];
            bool isNull = reader.IsDBNull(16);
            if (!isNull)
            {
              int employeeId = reader.GetInt32(16);
              var reportsTo = employees[employeeId];
              if (reportsTo == null)
                throw new NullReferenceException("Employee is null.");
              employee.ReportsTo = reportsTo;
            }
          }
          reader.Close();
        }

        #endregion

        #region Territories

        var territories = new Dictionary<object, Territory>();
        cmd.CommandText = "Select * from [dbo].[Territories]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var territory = new Territory(reader.GetString(0));
            territory.TerritoryDescription = reader.GetString(1);
            territory.Region = regions[reader.GetValue(2)];
            territories.Add(reader.GetValue(0), territory);
          }
          reader.Close();
        }

        #endregion

        #region EmployeeTerritories

        cmd.CommandText = "Select * from [dbo].[EmployeeTerritories]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var territory = territories[reader.GetString(1)];
            var employee = employees[reader.GetInt32(0)];
            if (employee == null)
              throw new NullReferenceException("Employee is null.");
            territory.Employees.Add(employee);
          }
          reader.Close();
        }

        #endregion

        #region Orders

        var orders = new Dictionary<object, Order>();
        cmd.CommandText = "Select * from [dbo].[Orders]";
        reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
        if (reader != null)
        {
          while (reader.Read())
          {
            var order = new Order();
            for (int i = 1; i < reader.FieldCount; i++)
              switch (i)
              {
                case 1:
                  order.Customer = !reader.IsDBNull(i) ? customers[reader.GetValue(i)] : null;
                  break;
                case 2:
                  order.Employee = !reader.IsDBNull(i) ? employees[reader.GetValue(i)] : null;
                  break;
                case 6:
                  order.ShipVia = !reader.IsDBNull(i) ? shippers[reader.GetValue(i)] : null;
                  break;
                default:
                  order[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
                  break;
              }
            orders.Add(reader.GetValue(0), order);
          }
          reader.Close();
        }

        #endregion

        #region OrderDetail

        cmd.CommandText = "Select * from [dbo].[Order Details]";
        reader = cmd.ExecuteReader();
        if (reader != null)
        {
          while (reader.Read())
          {
            var order = orders[reader.GetValue(0)];
            var product = products[reader.GetValue(1)];
            var orderDetails = new OrderDetail(order, product);

            for (int i = 2; i < reader.FieldCount; i++)
              orderDetails[reader.GetName(i)] = !reader.IsDBNull(i) ? reader.GetValue(i) : null;
          }
          reader.Close();
        }

        #endregion

        Session.Current.Persist();
        tr.Complete();
      }
      transaction.Commit();
      con.Close();
    }
  }
}