///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 1 августа 2009 г. 15:13:01
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.Northwind.HelperClasses
{
	/// <summary>
	/// Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal sealed class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			base.InitClass((12 + 0));
			InitActiveProductsEntityMappings();
			InitCategoriesEntityMappings();
			InitCustomersEntityMappings();
			InitDiscontinuedProductsEntityMappings();
			InitEmployeesEntityMappings();
			InitOrderDetailsEntityMappings();
			InitOrdersEntityMappings();
			InitProductsEntityMappings();
			InitRegionsEntityMappings();
			InitShippersEntityMappings();
			InitSuppliersEntityMappings();
			InitTerritoriesEntityMappings();

		}


		/// <summary>Inits ActiveProductsEntity's mappings</summary>
		private void InitActiveProductsEntityMappings()
		{
			base.AddElementMapping( "ActiveProductsEntity", "Northwind", @"dbo", "Products", 0 );

		}
		/// <summary>Inits CategoriesEntity's mappings</summary>
		private void InitCategoriesEntityMappings()
		{
			base.AddElementMapping( "CategoriesEntity", "Northwind", @"dbo", "Categories", 4 );
			base.AddElementFieldMapping( "CategoriesEntity", "Id", "CategoryID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CategoriesEntity", "CategoryName", "CategoryName", false, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CategoriesEntity", "Description", "Description", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CategoriesEntity", "Picture", "Picture", true, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 3 );
		}
		/// <summary>Inits CustomersEntity's mappings</summary>
		private void InitCustomersEntityMappings()
		{
			base.AddElementMapping( "CustomersEntity", "Northwind", @"dbo", "Customers", 11 );
			base.AddElementFieldMapping( "CustomersEntity", "Id", "CustomerID", false, (int)SqlDbType.NChar, 5, 0, 0, false, "", null, typeof(System.String), 0 );
			base.AddElementFieldMapping( "CustomersEntity", "CompanyName", "CompanyName", false, (int)SqlDbType.NVarChar, 40, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CustomersEntity", "ContactName", "ContactName", true, (int)SqlDbType.NVarChar, 30, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CustomersEntity", "ContactTitle", "ContactTitle", true, (int)SqlDbType.NVarChar, 30, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "CustomersEntity", "Address", "Address", true, (int)SqlDbType.NVarChar, 60, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "CustomersEntity", "City", "City", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "CustomersEntity", "Region", "Region", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "CustomersEntity", "PostalCode", "PostalCode", true, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "CustomersEntity", "Country", "Country", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "CustomersEntity", "Phone", "Phone", true, (int)SqlDbType.NVarChar, 24, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "CustomersEntity", "Fax", "Fax", true, (int)SqlDbType.NVarChar, 24, 0, 0, false, "", null, typeof(System.String), 10 );
		}
		/// <summary>Inits DiscontinuedProductsEntity's mappings</summary>
		private void InitDiscontinuedProductsEntityMappings()
		{
			base.AddElementMapping( "DiscontinuedProductsEntity", "Northwind", @"dbo", "Products", 0 );

		}
		/// <summary>Inits EmployeesEntity's mappings</summary>
		private void InitEmployeesEntityMappings()
		{
			base.AddElementMapping( "EmployeesEntity", "Northwind", @"dbo", "Employees", 17 );
			base.AddElementFieldMapping( "EmployeesEntity", "Id", "EmployeeID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "EmployeesEntity", "LastName", "LastName", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "EmployeesEntity", "FirstName", "FirstName", false, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "EmployeesEntity", "Title", "Title", true, (int)SqlDbType.NVarChar, 30, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "EmployeesEntity", "TitleOfCourtesy", "TitleOfCourtesy", true, (int)SqlDbType.NVarChar, 25, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "EmployeesEntity", "BirthDate", "BirthDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
			base.AddElementFieldMapping( "EmployeesEntity", "HireDate", "HireDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
			base.AddElementFieldMapping( "EmployeesEntity", "Address", "Address", true, (int)SqlDbType.NVarChar, 60, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "EmployeesEntity", "City", "City", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "EmployeesEntity", "Region", "Region", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "EmployeesEntity", "PostalCode", "PostalCode", true, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "EmployeesEntity", "Country", "Country", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "EmployeesEntity", "HomePhone", "HomePhone", true, (int)SqlDbType.NVarChar, 24, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "EmployeesEntity", "Extension", "Extension", true, (int)SqlDbType.NVarChar, 4, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "EmployeesEntity", "Photo", "Photo", true, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 14 );
			base.AddElementFieldMapping( "EmployeesEntity", "Notes", "Notes", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "EmployeesEntity", "PhotoPath", "PhotoPath", true, (int)SqlDbType.NVarChar, 255, 0, 0, false, "", null, typeof(System.String), 16 );
		}
		/// <summary>Inits OrderDetailsEntity's mappings</summary>
		private void InitOrderDetailsEntityMappings()
		{
			base.AddElementMapping( "OrderDetailsEntity", "Northwind", @"dbo", "Order Details", 5 );
			base.AddElementFieldMapping( "OrderDetailsEntity", "OrderId", "OrderID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "OrderDetailsEntity", "ProductId", "ProductID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "OrderDetailsEntity", "UnitPrice", "UnitPrice", false, (int)SqlDbType.Money, 0, 4, 19, false, "", null, typeof(System.Decimal), 2 );
			base.AddElementFieldMapping( "OrderDetailsEntity", "Quantity", "Quantity", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 3 );
			base.AddElementFieldMapping( "OrderDetailsEntity", "Discount", "Discount", false, (int)SqlDbType.Real, 0, 0, 24, false, "", null, typeof(System.Single), 4 );
		}
		/// <summary>Inits OrdersEntity's mappings</summary>
		private void InitOrdersEntityMappings()
		{
			base.AddElementMapping( "OrdersEntity", "Northwind", @"dbo", "Orders", 14 );
			base.AddElementFieldMapping( "OrdersEntity", "Id", "OrderID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "OrdersEntity", "CustomerId", "CustomerID", true, (int)SqlDbType.NChar, 5, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "OrdersEntity", "EmployeeId", "EmployeeID", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "OrdersEntity", "OrderDate", "OrderDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "OrdersEntity", "RequiredDate", "RequiredDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "OrdersEntity", "ShippedDate", "ShippedDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
			base.AddElementFieldMapping( "OrdersEntity", "ShipVia", "ShipVia", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "OrdersEntity", "Freight", "Freight", true, (int)SqlDbType.Money, 0, 4, 19, false, "", null, typeof(System.Decimal), 7 );
			base.AddElementFieldMapping( "OrdersEntity", "ShipName", "ShipName", true, (int)SqlDbType.NVarChar, 40, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "OrdersEntity", "ShipAddress", "ShipAddress", true, (int)SqlDbType.NVarChar, 60, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "OrdersEntity", "ShipCity", "ShipCity", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "OrdersEntity", "ShipRegion", "ShipRegion", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "OrdersEntity", "ShipPostalCode", "ShipPostalCode", true, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "OrdersEntity", "ShipCountry", "ShipCountry", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 13 );
		}
		/// <summary>Inits ProductsEntity's mappings</summary>
		private void InitProductsEntityMappings()
		{
			base.AddElementMapping( "ProductsEntity", "Northwind", @"dbo", "Products", 10 );
			base.AddElementFieldMapping( "ProductsEntity", "Id", "ProductID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ProductsEntity", "ProductName", "ProductName", false, (int)SqlDbType.NVarChar, 40, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ProductsEntity", "SupplierId", "SupplierID", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "ProductsEntity", "CategoryId", "CategoryID", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "ProductsEntity", "QuantityPerUnit", "QuantityPerUnit", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "ProductsEntity", "UnitPrice", "UnitPrice", true, (int)SqlDbType.Money, 0, 4, 19, false, "", null, typeof(System.Decimal), 5 );
			base.AddElementFieldMapping( "ProductsEntity", "UnitsInStock", "UnitsInStock", true, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 6 );
			base.AddElementFieldMapping( "ProductsEntity", "UnitsOnOrder", "UnitsOnOrder", true, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 7 );
			base.AddElementFieldMapping( "ProductsEntity", "ReorderLevel", "ReorderLevel", true, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 8 );
			base.AddElementFieldMapping( "ProductsEntity", "Discontinued", "Discontinued", false, (int)SqlDbType.VarChar, 2, 0, 0, false, "", null, typeof(System.String), 9 );
		}
		/// <summary>Inits RegionsEntity's mappings</summary>
		private void InitRegionsEntityMappings()
		{
			base.AddElementMapping( "RegionsEntity", "Northwind", @"dbo", "Region", 2 );
			base.AddElementFieldMapping( "RegionsEntity", "Id", "RegionID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RegionsEntity", "RegionDescription", "RegionDescription", false, (int)SqlDbType.NChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits ShippersEntity's mappings</summary>
		private void InitShippersEntityMappings()
		{
			base.AddElementMapping( "ShippersEntity", "Northwind", @"dbo", "Shippers", 3 );
			base.AddElementFieldMapping( "ShippersEntity", "Id", "ShipperID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ShippersEntity", "CompanyName", "CompanyName", false, (int)SqlDbType.NVarChar, 40, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ShippersEntity", "Phone", "Phone", true, (int)SqlDbType.NVarChar, 24, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits SuppliersEntity's mappings</summary>
		private void InitSuppliersEntityMappings()
		{
			base.AddElementMapping( "SuppliersEntity", "Northwind", @"dbo", "Suppliers", 12 );
			base.AddElementFieldMapping( "SuppliersEntity", "Id", "SupplierID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "SuppliersEntity", "CompanyName", "CompanyName", false, (int)SqlDbType.NVarChar, 40, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "SuppliersEntity", "ContactName", "ContactName", true, (int)SqlDbType.NVarChar, 30, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "SuppliersEntity", "ContactTitle", "ContactTitle", true, (int)SqlDbType.NVarChar, 30, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "SuppliersEntity", "Address", "Address", true, (int)SqlDbType.NVarChar, 60, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "SuppliersEntity", "City", "City", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "SuppliersEntity", "Region", "Region", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "SuppliersEntity", "PostalCode", "PostalCode", true, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "SuppliersEntity", "Country", "Country", true, (int)SqlDbType.NVarChar, 15, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "SuppliersEntity", "Phone", "Phone", true, (int)SqlDbType.NVarChar, 24, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "SuppliersEntity", "Fax", "Fax", true, (int)SqlDbType.NVarChar, 24, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "SuppliersEntity", "HomePage", "HomePage", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 11 );
		}
		/// <summary>Inits TerritoriesEntity's mappings</summary>
		private void InitTerritoriesEntityMappings()
		{
			base.AddElementMapping( "TerritoriesEntity", "Northwind", @"dbo", "Territories", 3 );
			base.AddElementFieldMapping( "TerritoriesEntity", "Id", "TerritoryID", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 0 );
			base.AddElementFieldMapping( "TerritoriesEntity", "TerritoryDescription", "TerritoryDescription", false, (int)SqlDbType.NChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TerritoriesEntity", "RegionId", "RegionID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}

	}
}