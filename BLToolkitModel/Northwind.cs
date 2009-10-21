using System;
using System.Data.Linq;

using BLToolkit.DataAccess;
using BLToolkit.Mapping;

using AssociationAttribute = BLToolkit.Mapping.AssociationAttribute;

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

		[Association(ThisKey="CategoryID", OtherKey="CategoryID")]
		public EntitySet<Product> Products;
	}

	[TableName("CustomerCustomerDemo")]
	public class CustomerCustomerDemo
	{
		public string CustomerID;
		public string CustomerTypeID;

		[Association(ThisKey="CustomerTypeID", OtherKey="CustomerTypeID")]
		public CustomerDemographic CustomerDemographics;

		[Association(ThisKey="CustomerID", OtherKey="CustomerID")]
		public Customer Customers;
	}

	[TableName("CustomerDemographics")]
	public class CustomerDemographic
	{
		public string CustomerTypeID;
		public string CustomerDesc;
		
		[Association(ThisKey="CustomerTypeID", OtherKey="CustomerTypeID")]
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

		[Association(ThisKey="CustomerID", OtherKey="CustomerID")]
		public EntitySet<CustomerCustomerDemo> CustomerCustomerDemos;

		[Association(ThisKey="CustomerID", OtherKey="CustomerID")]
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

		[Association(ThisKey="EmployeeID", OtherKey="ReportsTo")]
		public EntitySet<Employee> Employees;

		[Association(ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public EntitySet<EmployeeTerritory> EmployeeTerritories;

		[Association(ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public EntitySet<Order> Orders;
		
		[Association(ThisKey="ReportsTo", OtherKey="EmployeeID")]
		public Employee ReportsToEmployee;
	}

	[TableName("EmployeeTerritories")]
	public class EmployeeTerritory
	{
		public int    EmployeeID;
		public string TerritoryID;

		[Association(ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public Employee Employee;
		
		[Association(ThisKey="TerritoryID", OtherKey="TerritoryID")]
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

		[Association(ThisKey="OrderID", OtherKey="OrderID")]
		public Order Order;
		
		[Association(ThisKey="ProductID", OtherKey="ProductID")]
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

		[Association(ThisKey="OrderID", OtherKey="OrderID")]
		public EntitySet<OrderDetail> OrderDetails;

		[Association(ThisKey="CustomerID", OtherKey="CustomerID")]
		public Customer Customer;

		[Association(ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public Employee Employee;

		[Association(ThisKey="ShipVia", OtherKey="ShipperID")]
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

		[Association(ThisKey="ProductID", OtherKey="ProductID")]
		public EntitySet<OrderDetail> OrderDetails;

		[Association(ThisKey="CategoryID", OtherKey="CategoryID")]
		public Category Category;

		[Association(ThisKey="SupplierID", OtherKey="SupplierID")]
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

		[Association(ThisKey="RegionID", OtherKey="RegionID")]
		public EntitySet<Territory> Territories;
	}

	[TableName("Shippers")]
	public class Shipper
	{
		public int    ShipperID;
		public string CompanyName;
		public string Phone;

		[Association(ThisKey="ShipperID", OtherKey="ShipVia")]
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

		[Association(ThisKey="SupplierID", OtherKey="SupplierID")]
		public EntitySet<Product> Products;
	}

	[TableName("Territories")]
	public class Territory
	{
		public string TerritoryID;
		public string TerritoryDescription;
		public int    RegionID;

		[Association(ThisKey="TerritoryID", OtherKey="TerritoryID")]
		public EntitySet<EmployeeTerritory> EmployeeTerritories;

		[Association(ThisKey="RegionID", OtherKey="RegionID")]
		public Region Region;
	}
}
