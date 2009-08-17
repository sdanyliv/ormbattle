///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 1 августа 2009 г. 15:13:01
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.Northwind.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	
	/// <summary>
	/// Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal sealed class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private FieldInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			base.InitClass( (12 + 0));
			InitActiveProductsEntityInfos();
			InitCategoriesEntityInfos();
			InitCustomersEntityInfos();
			InitDiscontinuedProductsEntityInfos();
			InitEmployeesEntityInfos();
			InitOrderDetailsEntityInfos();
			InitOrdersEntityInfos();
			InitProductsEntityInfos();
			InitRegionsEntityInfos();
			InitShippersEntityInfos();
			InitSuppliersEntityInfos();
			InitTerritoriesEntityInfos();

			base.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits ActiveProductsEntity's FieldInfo objects</summary>
		private void InitActiveProductsEntityInfos()
		{

		}
		/// <summary>Inits CategoriesEntity's FieldInfo objects</summary>
		private void InitCategoriesEntityInfos()
		{
			base.AddElementFieldInfo("CategoriesEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)CategoriesFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("CategoriesEntity", "CategoryName", typeof(System.String), false, false, false, false,  (int)CategoriesFieldIndex.CategoryName, 15, 0, 0);
			base.AddElementFieldInfo("CategoriesEntity", "Description", typeof(System.String), false, false, false, true,  (int)CategoriesFieldIndex.Description, 1073741823, 0, 0);
			base.AddElementFieldInfo("CategoriesEntity", "Picture", typeof(System.Byte[]), false, false, false, true,  (int)CategoriesFieldIndex.Picture, 2147483647, 0, 0);
		}
		/// <summary>Inits CustomersEntity's FieldInfo objects</summary>
		private void InitCustomersEntityInfos()
		{
			base.AddElementFieldInfo("CustomersEntity", "Id", typeof(System.String), true, false, false, false,  (int)CustomersFieldIndex.Id, 5, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "CompanyName", typeof(System.String), false, false, false, false,  (int)CustomersFieldIndex.CompanyName, 40, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "ContactName", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.ContactName, 30, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "ContactTitle", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.ContactTitle, 30, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "Address", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.Address, 60, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "City", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.City, 15, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "Region", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.Region, 15, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "PostalCode", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.PostalCode, 10, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "Country", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.Country, 15, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "Phone", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.Phone, 24, 0, 0);
			base.AddElementFieldInfo("CustomersEntity", "Fax", typeof(System.String), false, false, false, true,  (int)CustomersFieldIndex.Fax, 24, 0, 0);
		}
		/// <summary>Inits DiscontinuedProductsEntity's FieldInfo objects</summary>
		private void InitDiscontinuedProductsEntityInfos()
		{

		}
		/// <summary>Inits EmployeesEntity's FieldInfo objects</summary>
		private void InitEmployeesEntityInfos()
		{
			base.AddElementFieldInfo("EmployeesEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)EmployeesFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("EmployeesEntity", "LastName", typeof(System.String), false, false, false, false,  (int)EmployeesFieldIndex.LastName, 20, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)EmployeesFieldIndex.FirstName, 10, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "Title", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.Title, 30, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "TitleOfCourtesy", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.TitleOfCourtesy, 25, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "BirthDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)EmployeesFieldIndex.BirthDate, 0, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "HireDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)EmployeesFieldIndex.HireDate, 0, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "Address", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.Address, 60, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "City", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.City, 15, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "Region", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.Region, 15, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "PostalCode", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.PostalCode, 10, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "Country", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.Country, 15, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "HomePhone", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.HomePhone, 24, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "Extension", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.Extension, 4, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "Photo", typeof(System.Byte[]), false, false, false, true,  (int)EmployeesFieldIndex.Photo, 2147483647, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "Notes", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.Notes, 1073741823, 0, 0);
			base.AddElementFieldInfo("EmployeesEntity", "PhotoPath", typeof(System.String), false, false, false, true,  (int)EmployeesFieldIndex.PhotoPath, 255, 0, 0);
		}
		/// <summary>Inits OrderDetailsEntity's FieldInfo objects</summary>
		private void InitOrderDetailsEntityInfos()
		{
			base.AddElementFieldInfo("OrderDetailsEntity", "OrderId", typeof(System.Int32), true, true, false, false,  (int)OrderDetailsFieldIndex.OrderId, 0, 0, 10);
			base.AddElementFieldInfo("OrderDetailsEntity", "ProductId", typeof(System.Int32), true, true, false, false,  (int)OrderDetailsFieldIndex.ProductId, 0, 0, 10);
			base.AddElementFieldInfo("OrderDetailsEntity", "UnitPrice", typeof(System.Decimal), false, false, false, false,  (int)OrderDetailsFieldIndex.UnitPrice, 0, 4, 19);
			base.AddElementFieldInfo("OrderDetailsEntity", "Quantity", typeof(System.Int16), false, false, false, false,  (int)OrderDetailsFieldIndex.Quantity, 0, 0, 5);
			base.AddElementFieldInfo("OrderDetailsEntity", "Discount", typeof(System.Single), false, false, false, false,  (int)OrderDetailsFieldIndex.Discount, 0, 0, 24);
		}
		/// <summary>Inits OrdersEntity's FieldInfo objects</summary>
		private void InitOrdersEntityInfos()
		{
			base.AddElementFieldInfo("OrdersEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)OrdersFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("OrdersEntity", "CustomerId", typeof(System.String), false, true, false, true,  (int)OrdersFieldIndex.CustomerId, 5, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "EmployeeId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)OrdersFieldIndex.EmployeeId, 0, 0, 10);
			base.AddElementFieldInfo("OrdersEntity", "OrderDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)OrdersFieldIndex.OrderDate, 0, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "RequiredDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)OrdersFieldIndex.RequiredDate, 0, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "ShippedDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)OrdersFieldIndex.ShippedDate, 0, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "ShipVia", typeof(Nullable<System.Int32>), false, true, false, true,  (int)OrdersFieldIndex.ShipVia, 0, 0, 10);
			base.AddElementFieldInfo("OrdersEntity", "Freight", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)OrdersFieldIndex.Freight, 0, 4, 19);
			base.AddElementFieldInfo("OrdersEntity", "ShipName", typeof(System.String), false, false, false, true,  (int)OrdersFieldIndex.ShipName, 40, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "ShipAddress", typeof(System.String), false, false, false, true,  (int)OrdersFieldIndex.ShipAddress, 60, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "ShipCity", typeof(System.String), false, false, false, true,  (int)OrdersFieldIndex.ShipCity, 15, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "ShipRegion", typeof(System.String), false, false, false, true,  (int)OrdersFieldIndex.ShipRegion, 15, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "ShipPostalCode", typeof(System.String), false, false, false, true,  (int)OrdersFieldIndex.ShipPostalCode, 10, 0, 0);
			base.AddElementFieldInfo("OrdersEntity", "ShipCountry", typeof(System.String), false, false, false, true,  (int)OrdersFieldIndex.ShipCountry, 15, 0, 0);
		}
		/// <summary>Inits ProductsEntity's FieldInfo objects</summary>
		private void InitProductsEntityInfos()
		{
			base.AddElementFieldInfo("ProductsEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)ProductsFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("ProductsEntity", "ProductName", typeof(System.String), false, false, false, false,  (int)ProductsFieldIndex.ProductName, 40, 0, 0);
			base.AddElementFieldInfo("ProductsEntity", "SupplierId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)ProductsFieldIndex.SupplierId, 0, 0, 10);
			base.AddElementFieldInfo("ProductsEntity", "CategoryId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)ProductsFieldIndex.CategoryId, 0, 0, 10);
			base.AddElementFieldInfo("ProductsEntity", "QuantityPerUnit", typeof(System.String), false, false, false, true,  (int)ProductsFieldIndex.QuantityPerUnit, 20, 0, 0);
			base.AddElementFieldInfo("ProductsEntity", "UnitPrice", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ProductsFieldIndex.UnitPrice, 0, 4, 19);
			base.AddElementFieldInfo("ProductsEntity", "UnitsInStock", typeof(Nullable<System.Int16>), false, false, false, true,  (int)ProductsFieldIndex.UnitsInStock, 0, 0, 5);
			base.AddElementFieldInfo("ProductsEntity", "UnitsOnOrder", typeof(Nullable<System.Int16>), false, false, false, true,  (int)ProductsFieldIndex.UnitsOnOrder, 0, 0, 5);
			base.AddElementFieldInfo("ProductsEntity", "ReorderLevel", typeof(Nullable<System.Int16>), false, false, false, true,  (int)ProductsFieldIndex.ReorderLevel, 0, 0, 5);
			base.AddElementFieldInfo("ProductsEntity", "Discontinued", typeof(System.String), false, false, true, false,  (int)ProductsFieldIndex.Discontinued, 2, 0, 0);
		}
		/// <summary>Inits RegionsEntity's FieldInfo objects</summary>
		private void InitRegionsEntityInfos()
		{
			base.AddElementFieldInfo("RegionsEntity", "Id", typeof(System.Int32), true, false, false, false,  (int)RegionsFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("RegionsEntity", "RegionDescription", typeof(System.String), false, false, false, false,  (int)RegionsFieldIndex.RegionDescription, 50, 0, 0);
		}
		/// <summary>Inits ShippersEntity's FieldInfo objects</summary>
		private void InitShippersEntityInfos()
		{
			base.AddElementFieldInfo("ShippersEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)ShippersFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("ShippersEntity", "CompanyName", typeof(System.String), false, false, false, false,  (int)ShippersFieldIndex.CompanyName, 40, 0, 0);
			base.AddElementFieldInfo("ShippersEntity", "Phone", typeof(System.String), false, false, false, true,  (int)ShippersFieldIndex.Phone, 24, 0, 0);
		}
		/// <summary>Inits SuppliersEntity's FieldInfo objects</summary>
		private void InitSuppliersEntityInfos()
		{
			base.AddElementFieldInfo("SuppliersEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)SuppliersFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("SuppliersEntity", "CompanyName", typeof(System.String), false, false, false, false,  (int)SuppliersFieldIndex.CompanyName, 40, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "ContactName", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.ContactName, 30, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "ContactTitle", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.ContactTitle, 30, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "Address", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.Address, 60, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "City", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.City, 15, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "Region", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.Region, 15, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "PostalCode", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.PostalCode, 10, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "Country", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.Country, 15, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "Phone", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.Phone, 24, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "Fax", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.Fax, 24, 0, 0);
			base.AddElementFieldInfo("SuppliersEntity", "HomePage", typeof(System.String), false, false, false, true,  (int)SuppliersFieldIndex.HomePage, 1073741823, 0, 0);
		}
		/// <summary>Inits TerritoriesEntity's FieldInfo objects</summary>
		private void InitTerritoriesEntityInfos()
		{
			base.AddElementFieldInfo("TerritoriesEntity", "Id", typeof(System.String), true, false, false, false,  (int)TerritoriesFieldIndex.Id, 20, 0, 0);
			base.AddElementFieldInfo("TerritoriesEntity", "TerritoryDescription", typeof(System.String), false, false, false, false,  (int)TerritoriesFieldIndex.TerritoryDescription, 50, 0, 0);
			base.AddElementFieldInfo("TerritoriesEntity", "RegionId", typeof(System.Int32), false, true, false, false,  (int)TerritoriesFieldIndex.RegionId, 0, 0, 10);
		}
		
	}
}




