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

namespace OrmBattle.LLBLGenModel.Northwind
{

	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ActiveProducts.
	/// </summary>
	public enum ActiveProductsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ProductName. </summary>
		ProductName,
		///<summary>SupplierId. </summary>
		SupplierId,
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>QuantityPerUnit. </summary>
		QuantityPerUnit,
		///<summary>UnitPrice. </summary>
		UnitPrice,
		///<summary>UnitsInStock. </summary>
		UnitsInStock,
		///<summary>UnitsOnOrder. </summary>
		UnitsOnOrder,
		///<summary>ReorderLevel. </summary>
		ReorderLevel,
		///<summary>Discontinued. </summary>
		Discontinued,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Categories.
	/// </summary>
	public enum CategoriesFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CategoryName. </summary>
		CategoryName,
		///<summary>Description. </summary>
		Description,
		///<summary>Picture. </summary>
		Picture,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Customers.
	/// </summary>
	public enum CustomersFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CompanyName. </summary>
		CompanyName,
		///<summary>ContactName. </summary>
		ContactName,
		///<summary>ContactTitle. </summary>
		ContactTitle,
		///<summary>Address. </summary>
		Address,
		///<summary>City. </summary>
		City,
		///<summary>Region. </summary>
		Region,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>Country. </summary>
		Country,
		///<summary>Phone. </summary>
		Phone,
		///<summary>Fax. </summary>
		Fax,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DiscontinuedProducts.
	/// </summary>
	public enum DiscontinuedProductsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ProductName. </summary>
		ProductName,
		///<summary>SupplierId. </summary>
		SupplierId,
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>QuantityPerUnit. </summary>
		QuantityPerUnit,
		///<summary>UnitPrice. </summary>
		UnitPrice,
		///<summary>UnitsInStock. </summary>
		UnitsInStock,
		///<summary>UnitsOnOrder. </summary>
		UnitsOnOrder,
		///<summary>ReorderLevel. </summary>
		ReorderLevel,
		///<summary>Discontinued. </summary>
		Discontinued,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Employees.
	/// </summary>
	public enum EmployeesFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>LastName. </summary>
		LastName,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>Title. </summary>
		Title,
		///<summary>TitleOfCourtesy. </summary>
		TitleOfCourtesy,
		///<summary>BirthDate. </summary>
		BirthDate,
		///<summary>HireDate. </summary>
		HireDate,
		///<summary>Address. </summary>
		Address,
		///<summary>City. </summary>
		City,
		///<summary>Region. </summary>
		Region,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>Country. </summary>
		Country,
		///<summary>HomePhone. </summary>
		HomePhone,
		///<summary>Extension. </summary>
		Extension,
		///<summary>Photo. </summary>
		Photo,
		///<summary>Notes. </summary>
		Notes,
		///<summary>PhotoPath. </summary>
		PhotoPath,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrderDetails.
	/// </summary>
	public enum OrderDetailsFieldIndex:int
	{
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>ProductId. </summary>
		ProductId,
		///<summary>UnitPrice. </summary>
		UnitPrice,
		///<summary>Quantity. </summary>
		Quantity,
		///<summary>Discount. </summary>
		Discount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Orders.
	/// </summary>
	public enum OrdersFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EmployeeId. </summary>
		EmployeeId,
		///<summary>OrderDate. </summary>
		OrderDate,
		///<summary>RequiredDate. </summary>
		RequiredDate,
		///<summary>ShippedDate. </summary>
		ShippedDate,
		///<summary>ShipVia. </summary>
		ShipVia,
		///<summary>Freight. </summary>
		Freight,
		///<summary>ShipName. </summary>
		ShipName,
		///<summary>ShipAddress. </summary>
		ShipAddress,
		///<summary>ShipCity. </summary>
		ShipCity,
		///<summary>ShipRegion. </summary>
		ShipRegion,
		///<summary>ShipPostalCode. </summary>
		ShipPostalCode,
		///<summary>ShipCountry. </summary>
		ShipCountry,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Products.
	/// </summary>
	public enum ProductsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ProductName. </summary>
		ProductName,
		///<summary>SupplierId. </summary>
		SupplierId,
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>QuantityPerUnit. </summary>
		QuantityPerUnit,
		///<summary>UnitPrice. </summary>
		UnitPrice,
		///<summary>UnitsInStock. </summary>
		UnitsInStock,
		///<summary>UnitsOnOrder. </summary>
		UnitsOnOrder,
		///<summary>ReorderLevel. </summary>
		ReorderLevel,
		///<summary>Discontinued. </summary>
		Discontinued,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Regions.
	/// </summary>
	public enum RegionsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>RegionDescription. </summary>
		RegionDescription,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Shippers.
	/// </summary>
	public enum ShippersFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CompanyName. </summary>
		CompanyName,
		///<summary>Phone. </summary>
		Phone,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Suppliers.
	/// </summary>
	public enum SuppliersFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CompanyName. </summary>
		CompanyName,
		///<summary>ContactName. </summary>
		ContactName,
		///<summary>ContactTitle. </summary>
		ContactTitle,
		///<summary>Address. </summary>
		Address,
		///<summary>City. </summary>
		City,
		///<summary>Region. </summary>
		Region,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>Country. </summary>
		Country,
		///<summary>Phone. </summary>
		Phone,
		///<summary>Fax. </summary>
		Fax,
		///<summary>HomePage. </summary>
		HomePage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Territories.
	/// </summary>
	public enum TerritoriesFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>TerritoryDescription. </summary>
		TerritoryDescription,
		///<summary>RegionId. </summary>
		RegionId,
		/// <summary></summary>
		AmountOfFields
	}





	/// <summary>
	/// Enum definition for all the entity types defined in this namespace. Used by the entityfields factory.
	/// </summary>
	public enum EntityType:int
	{
		///<summary>ActiveProducts</summary>
		ActiveProductsEntity,
		///<summary>Categories</summary>
		CategoriesEntity,
		///<summary>Customers</summary>
		CustomersEntity,
		///<summary>DiscontinuedProducts</summary>
		DiscontinuedProductsEntity,
		///<summary>Employees</summary>
		EmployeesEntity,
		///<summary>OrderDetails</summary>
		OrderDetailsEntity,
		///<summary>Orders</summary>
		OrdersEntity,
		///<summary>Products</summary>
		ProductsEntity,
		///<summary>Regions</summary>
		RegionsEntity,
		///<summary>Shippers</summary>
		ShippersEntity,
		///<summary>Suppliers</summary>
		SuppliersEntity,
		///<summary>Territories</summary>
		TerritoriesEntity
	}




	#region Custom ConstantsEnums Code
	
	// __LLBLGENPRO_USER_CODE_REGION_START CustomUserConstants
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	#endregion

	#region Included code

	#endregion
}


