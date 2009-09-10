using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace OrmBattle.BLToolkitModel
{
	public abstract class ComparableEntity
	{
		public override bool Equals(object obj)
		{
			return obj != null && GetType() == obj.GetType() && GetKey().Equals(((ComparableEntity)obj).GetKey());
		}

		protected abstract object GetKey();

		public override int GetHashCode()
		{
			return GetKey().GetHashCode();
		}
	}

	[TableName("Categories")]
	public class Category
	{
		[MapField("CategoryID")]
		public int    Id;
		public string CategoryName;
		public string Description;
		public Binary Picture;

		[Association(Name="Category_Product", ThisKey="CategoryID", OtherKey="CategoryID")]
		public EntitySet<Product> Products;
	}

	[TableName("CustomerCustomerDemo")]
	public class CustomerCustomerDemo
	{
		public string CustomerID;
		public string CustomerTypeID;

		[Association(Name="CustomerDemographic_CustomerCustomerDemo", ThisKey="CustomerTypeID", OtherKey="CustomerTypeID", IsForeignKey=true)]
		public CustomerDemographic CustomerDemographics;

		[Association(Name="Customer_CustomerCustomerDemo", ThisKey="CustomerID", OtherKey="CustomerID", IsForeignKey=true)]
		public Customer Customers;
	}

	[TableName("CustomerDemographics")]
	public class CustomerDemographic
	{
		public string CustomerTypeID;
		public string CustomerDesc;
		
		[Association(Name="CustomerDemographic_CustomerCustomerDemo", ThisKey="CustomerTypeID", OtherKey="CustomerTypeID")]
		public EntitySet<CustomerCustomerDemo> CustomerCustomerDemos;
	}

	[TableName("Customers")]
	public class Customer
	{
		[MapField("CustomerID")] public string Id;
		                         public string CompanyName;
		                         public string ContactName;
		                         public string ContactTitle;
		                         public string Address;
		                         public string City;
		                         public string Region;
		                         public string PostalCode;
		                         public string Country;
		                         public string Phone;
		                         public string Fax;

		[Association(Name="Customer_CustomerCustomerDemo", ThisKey="CustomerID", OtherKey="CustomerID")]
		public EntitySet<CustomerCustomerDemo> CustomerCustomerDemos;

		[Association(Name="Customer_Order", ThisKey="CustomerID", OtherKey="CustomerID")]
		public EntitySet<Order> Orders;
	}

	[TableName("Employees")]
	public class Employee
	{
		public int       EmployeeID;
		public string    LastName;
		public string    FirstName;
		public string    Title;
		public string    TitleOfCourtesy;
		public DateTime? BirthDate;
		public DateTime? HireDate;
		public string    Address;
		public string    City;
		public string    Region;
		public string    PostalCode;
		public string    Country;
		public string    HomePhone;
		public string    Extension;
		public Binary    Photo;
		public string    Notes;
		public int?      ReportsTo;
		public string    PhotoPath;

		[Association(Name="Employee_Employee", ThisKey="EmployeeID", OtherKey="ReportsTo")]
		public EntitySet<Employee> Employees;

		[Association(Name="Employee_EmployeeTerritory", ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public EntitySet<EmployeeTerritory> EmployeeTerritories;

		[Association(Name="Employee_Order", ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public EntitySet<Order> Orders;
		
		[Association(Name="Employee_Employee", ThisKey="ReportsTo", OtherKey="EmployeeID", IsForeignKey=true)]
		public Employee ReportsToEmployee;
	}

	[TableName("EmployeeTerritories")]
	public class EmployeeTerritory
	{
		public int    EmployeeID;
		public string TerritoryID;

		[Association(Name="Employee_EmployeeTerritory", ThisKey="EmployeeID", OtherKey="EmployeeID", IsForeignKey=true)]
		public Employee Employee;
		
		[Association(Name="Territory_EmployeeTerritory", ThisKey="TerritoryID", OtherKey="TerritoryID", IsForeignKey=true)]
		public Territory Territory;
	}

	[TableName("Order Details")]
	public class OrderDetail
	{
		public int     OrderID;
		public int     ProductID;
		public decimal UnitPrice;
		public short   Quantity;
		public float   Discount;

		[Association(Name="Order_Order_Detail", ThisKey="OrderID", OtherKey="OrderID", IsForeignKey=true)]
		public Order Order;
		
		[Association(Name="Product_Order_Detail", ThisKey="ProductID", OtherKey="ProductID", IsForeignKey=true)]
		public Product Product;
	}

	[TableName("Orders")]
	public class Order : ComparableEntity
	{
		[MapField("OrderID")] public int       Id;
		                      public string    CustomerID;
		                      public int?      EmployeeID;
		                      public DateTime? OrderDate;
		                      public DateTime? RequiredDate;
		                      public DateTime? ShippedDate;
		                      public int?      ShipVia;
		                      public decimal   Freight;
		                      public string    ShipName;
		                      public string    ShipAddress;
		                      public string    ShipCity;
		[Nullable]            public string    ShipRegion;
		                      public string    ShipPostalCode;
		                      public string    ShipCountry;

		[Association(Name="Order_Order_Detail", ThisKey="OrderID", OtherKey="OrderID")]
		public EntitySet<OrderDetail> OrderDetails;

		[Association(Name="Customer_Order", ThisKey="CustomerID", OtherKey="CustomerID", IsForeignKey=true)]
		public Customer Customer;

		[Association(Name="Employee_Order", ThisKey="EmployeeID", OtherKey="EmployeeID", IsForeignKey=true)]
		public Employee Employee;

		[Association(Name="Shipper_Order", ThisKey="ShipVia", OtherKey="ShipperID", IsForeignKey=true)]
		public Shipper Shipper;

		protected override object GetKey()
		{
			return Id;
		}
	}

	[TableName("Products")]
	public class Product
	{
		[MapField("ProductID")] public int      Id;
		                        public string   ProductName;
		                        public int?     SupplierID;
		                        public int?     CategoryID;
		                        public string   QuantityPerUnit;
		                        public decimal? UnitPrice;
		                        public short?   UnitsInStock;
		                        public short?   UnitsOnOrder;
		                        public short?   ReorderLevel;
		                        public bool     Discontinued;

		[Association(Name="Product_Order_Detail", ThisKey="ProductID", OtherKey="ProductID")]
		public EntitySet<OrderDetail> OrderDetails;

		[Association(Name="Category_Product", ThisKey="CategoryID", OtherKey="CategoryID", IsForeignKey=true)]
		public Category Category;

		[Association(Name="Supplier_Product", ThisKey="SupplierID", OtherKey="SupplierID", IsForeignKey=true)]
		public Supplier Supplier;
	}

	public class ActiveProduct : Product
	{
	}

	public class DiscontinuedProduct : Product
	{
	}

	[TableName("Region")]
	public class Region
	{
		public int    RegionID;
		public string RegionDescription;

		[Association(Name="Region_Territory", ThisKey="RegionID", OtherKey="RegionID")]
		public EntitySet<Territory> Territories;
	}

	[TableName("Shippers")]
	public class Shipper
	{
		public int    ShipperID;
		public string CompanyName;
		public string Phone;

		[Association(Name="Shipper_Order", ThisKey="ShipperID", OtherKey="ShipVia")]
		public EntitySet<Order> Orders;
	}

	[TableName("Suppliers")]
	public class Supplier
	{
		[MapField("SupplierID")] public int    Id;
		                         public string CompanyName;
		                         public string ContactName;
		                         public string ContactTitle;
		                         public string Address;
		                         public string City;
		                         public string Region;
		                         public string PostalCode;
		                         public string Country;
		                         public string Phone;
		                         public string Fax;
		                         public string HomePage;

		[Association(Name="Supplier_Product", ThisKey="SupplierID", OtherKey="SupplierID")]
		public EntitySet<Product> Products;
	}

	[TableName("Territories")]
	public class Territory
	{
		public string TerritoryID;
		public string TerritoryDescription;
		public int    RegionID;

		[Association(Name="Territory_EmployeeTerritory", ThisKey="TerritoryID", OtherKey="TerritoryID")]
		public EntitySet<EmployeeTerritory> EmployeeTerritories;

		[Association(Name="Region_Territory", ThisKey="RegionID", OtherKey="RegionID", IsForeignKey=true)]
		public Region Region;
	}
}
