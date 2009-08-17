///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 1 августа 2009 г. 15:13:01
// Code is generated using templates: SD.TemplateBindings.Linq
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using OrmBattle.LLBLGenModel.Northwind;
using OrmBattle.LLBLGenModel.Northwind.DaoClasses;
using OrmBattle.LLBLGenModel.Northwind.EntityClasses;
using OrmBattle.LLBLGenModel.Northwind.FactoryClasses;
using OrmBattle.LLBLGenModel.Northwind.HelperClasses;
using OrmBattle.LLBLGenModel.Northwind.RelationClasses;

namespace OrmBattle.LLBLGenModel.Northwind.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData : ILinqMetaData
	{
		#region Class Member Declarations
		private ITransaction _transactionToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the transaction object to use empty. This is ok if you're not executing queries created with this
		/// meta data inside a transaction. If you're executing the queries created with this meta-data inside a transaction, either set the Transaction property
		/// on the IQueryable.Provider instance of the created LLBLGenProQuery object prior to execution or use the ctor which accepts a transaction object.</summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse) : this(transactionToUse, null)
		{
		}
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse, FunctionMappingStore customFunctionMappings)
		{
			_transactionToUse = transactionToUse;
			_customFunctionMappings = customFunctionMappings;
		}
		
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((LLBLGenModel.Northwind.EntityType)typeOfEntity)
			{
				case LLBLGenModel.Northwind.EntityType.ActiveProductsEntity:
					toReturn = this.ActiveProducts;
					break;
				case LLBLGenModel.Northwind.EntityType.CategoriesEntity:
					toReturn = this.Categories;
					break;
				case LLBLGenModel.Northwind.EntityType.CustomersEntity:
					toReturn = this.Customers;
					break;
				case LLBLGenModel.Northwind.EntityType.DiscontinuedProductsEntity:
					toReturn = this.DiscontinuedProducts;
					break;
				case LLBLGenModel.Northwind.EntityType.EmployeesEntity:
					toReturn = this.Employees;
					break;
				case LLBLGenModel.Northwind.EntityType.OrderDetailsEntity:
					toReturn = this.OrderDetails;
					break;
				case LLBLGenModel.Northwind.EntityType.OrdersEntity:
					toReturn = this.Orders;
					break;
				case LLBLGenModel.Northwind.EntityType.ProductsEntity:
					toReturn = this.Products;
					break;
				case LLBLGenModel.Northwind.EntityType.RegionsEntity:
					toReturn = this.Regions;
					break;
				case LLBLGenModel.Northwind.EntityType.ShippersEntity:
					toReturn = this.Shippers;
					break;
				case LLBLGenModel.Northwind.EntityType.SuppliersEntity:
					toReturn = this.Suppliers;
					break;
				case LLBLGenModel.Northwind.EntityType.TerritoriesEntity:
					toReturn = this.Territories;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting ActiveProductsEntity instances in the database.</summary>
		public DataSource<ActiveProductsEntity> ActiveProducts
		{
			get { return new DataSource<ActiveProductsEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting CategoriesEntity instances in the database.</summary>
		public DataSource<CategoriesEntity> Categories
		{
			get { return new DataSource<CategoriesEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting CustomersEntity instances in the database.</summary>
		public DataSource<CustomersEntity> Customers
		{
			get { return new DataSource<CustomersEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting DiscontinuedProductsEntity instances in the database.</summary>
		public DataSource<DiscontinuedProductsEntity> DiscontinuedProducts
		{
			get { return new DataSource<DiscontinuedProductsEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting EmployeesEntity instances in the database.</summary>
		public DataSource<EmployeesEntity> Employees
		{
			get { return new DataSource<EmployeesEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting OrderDetailsEntity instances in the database.</summary>
		public DataSource<OrderDetailsEntity> OrderDetails
		{
			get { return new DataSource<OrderDetailsEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting OrdersEntity instances in the database.</summary>
		public DataSource<OrdersEntity> Orders
		{
			get { return new DataSource<OrdersEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ProductsEntity instances in the database.</summary>
		public DataSource<ProductsEntity> Products
		{
			get { return new DataSource<ProductsEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting RegionsEntity instances in the database.</summary>
		public DataSource<RegionsEntity> Regions
		{
			get { return new DataSource<RegionsEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ShippersEntity instances in the database.</summary>
		public DataSource<ShippersEntity> Shippers
		{
			get { return new DataSource<ShippersEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SuppliersEntity instances in the database.</summary>
		public DataSource<SuppliersEntity> Suppliers
		{
			get { return new DataSource<SuppliersEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting TerritoriesEntity instances in the database.</summary>
		public DataSource<TerritoriesEntity> Territories
		{
			get { return new DataSource<TerritoriesEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		#region Class Property Declarations
		/// <summary> Gets / sets the ITransaction to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public ITransaction TransactionToUse
		{
			get { return _transactionToUse;}
			set { _transactionToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}