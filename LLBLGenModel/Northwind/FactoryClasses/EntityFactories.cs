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
using System.Collections.Generic;
using OrmBattle.LLBLGenModel.Northwind.HelperClasses;

using OrmBattle.LLBLGenModel.Northwind.EntityClasses;
using OrmBattle.LLBLGenModel.Northwind.RelationClasses;
using OrmBattle.LLBLGenModel.Northwind.DaoClasses;
using OrmBattle.LLBLGenModel.Northwind.CollectionClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.Northwind.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	
	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase : EntityFactoryCore
	{
		private string _entityName;
		private LLBLGenModel.Northwind.EntityType _typeOfEntity;
		
		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		public EntityFactoryBase(string entityName, LLBLGenModel.Northwind.EntityType typeOfEntity)
		{
			_entityName = entityName;
			_typeOfEntity = typeOfEntity;
		}

		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.Create((LLBLGenModel.Northwind.EntityType)entityTypeValue);
		}
		
		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public override IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(_typeOfEntity);
		}

		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <param name="objectAlias">The object alias to use for the elements in the relations.</param>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetHierarchyRelations(_entityName, objectAlias);
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public override IEntityFactory GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity)
		{
			IEntityFactory toReturn = (IEntityFactory)InheritanceInfoProviderSingleton.GetInstance().GetEntityFactory(_entityName, fieldValues, entityFieldStartIndexesPerEntity);
			if(toReturn == null)
			{
				toReturn = this;
			}
			return toReturn;
		}
						
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public override IEntityCollection CreateEntityCollection()
		{
			return GeneralEntityCollectionFactory.Create(_typeOfEntity);
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public override string ForEntityName 
		{ 
			get { return _entityName; }
		}
	}
	
	/// <summary>Factory to create new, empty ActiveProductsEntity objects.</summary>
	[Serializable]
	public partial class ActiveProductsEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ActiveProductsEntityFactory() : base("ActiveProductsEntity", LLBLGenModel.Northwind.EntityType.ActiveProductsEntity) { }

		/// <summary>Creates a new, empty ActiveProductsEntity object.</summary>
		/// <returns>A new, empty ActiveProductsEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ActiveProductsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActiveProducts
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new ActiveProductsEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActiveProductsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields CreateHierarchyFields()
		{
			return new EntityFields(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields("ActiveProductsEntity"), InheritanceInfoProviderSingleton.GetInstance(), null);
		}
		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CategoriesEntity objects.</summary>
	[Serializable]
	public partial class CategoriesEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public CategoriesEntityFactory() : base("CategoriesEntity", LLBLGenModel.Northwind.EntityType.CategoriesEntity) { }

		/// <summary>Creates a new, empty CategoriesEntity object.</summary>
		/// <returns>A new, empty CategoriesEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new CategoriesEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCategories
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new CategoriesEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCategoriesUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CustomersEntity objects.</summary>
	[Serializable]
	public partial class CustomersEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public CustomersEntityFactory() : base("CustomersEntity", LLBLGenModel.Northwind.EntityType.CustomersEntity) { }

		/// <summary>Creates a new, empty CustomersEntity object.</summary>
		/// <returns>A new, empty CustomersEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new CustomersEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomers
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new CustomersEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCustomersUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty DiscontinuedProductsEntity objects.</summary>
	[Serializable]
	public partial class DiscontinuedProductsEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public DiscontinuedProductsEntityFactory() : base("DiscontinuedProductsEntity", LLBLGenModel.Northwind.EntityType.DiscontinuedProductsEntity) { }

		/// <summary>Creates a new, empty DiscontinuedProductsEntity object.</summary>
		/// <returns>A new, empty DiscontinuedProductsEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new DiscontinuedProductsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDiscontinuedProducts
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new DiscontinuedProductsEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDiscontinuedProductsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields CreateHierarchyFields()
		{
			return new EntityFields(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields("DiscontinuedProductsEntity"), InheritanceInfoProviderSingleton.GetInstance(), null);
		}
		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty EmployeesEntity objects.</summary>
	[Serializable]
	public partial class EmployeesEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public EmployeesEntityFactory() : base("EmployeesEntity", LLBLGenModel.Northwind.EntityType.EmployeesEntity) { }

		/// <summary>Creates a new, empty EmployeesEntity object.</summary>
		/// <returns>A new, empty EmployeesEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new EmployeesEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEmployees
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new EmployeesEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEmployeesUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty OrderDetailsEntity objects.</summary>
	[Serializable]
	public partial class OrderDetailsEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public OrderDetailsEntityFactory() : base("OrderDetailsEntity", LLBLGenModel.Northwind.EntityType.OrderDetailsEntity) { }

		/// <summary>Creates a new, empty OrderDetailsEntity object.</summary>
		/// <returns>A new, empty OrderDetailsEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new OrderDetailsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrderDetails
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new OrderDetailsEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrderDetailsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty OrdersEntity objects.</summary>
	[Serializable]
	public partial class OrdersEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public OrdersEntityFactory() : base("OrdersEntity", LLBLGenModel.Northwind.EntityType.OrdersEntity) { }

		/// <summary>Creates a new, empty OrdersEntity object.</summary>
		/// <returns>A new, empty OrdersEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new OrdersEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrders
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new OrdersEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrdersUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ProductsEntity objects.</summary>
	[Serializable]
	public partial class ProductsEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ProductsEntityFactory() : base("ProductsEntity", LLBLGenModel.Northwind.EntityType.ProductsEntity) { }

		/// <summary>Creates a new, empty ProductsEntity object.</summary>
		/// <returns>A new, empty ProductsEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ProductsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewProducts
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new ProductsEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewProductsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields CreateHierarchyFields()
		{
			return new EntityFields(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields("ProductsEntity"), InheritanceInfoProviderSingleton.GetInstance(), null);
		}
		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty RegionsEntity objects.</summary>
	[Serializable]
	public partial class RegionsEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public RegionsEntityFactory() : base("RegionsEntity", LLBLGenModel.Northwind.EntityType.RegionsEntity) { }

		/// <summary>Creates a new, empty RegionsEntity object.</summary>
		/// <returns>A new, empty RegionsEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new RegionsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRegions
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new RegionsEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRegionsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ShippersEntity objects.</summary>
	[Serializable]
	public partial class ShippersEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ShippersEntityFactory() : base("ShippersEntity", LLBLGenModel.Northwind.EntityType.ShippersEntity) { }

		/// <summary>Creates a new, empty ShippersEntity object.</summary>
		/// <returns>A new, empty ShippersEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ShippersEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShippers
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new ShippersEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShippersUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SuppliersEntity objects.</summary>
	[Serializable]
	public partial class SuppliersEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SuppliersEntityFactory() : base("SuppliersEntity", LLBLGenModel.Northwind.EntityType.SuppliersEntity) { }

		/// <summary>Creates a new, empty SuppliersEntity object.</summary>
		/// <returns>A new, empty SuppliersEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SuppliersEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSuppliers
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new SuppliersEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSuppliersUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty TerritoriesEntity objects.</summary>
	[Serializable]
	public partial class TerritoriesEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public TerritoriesEntityFactory() : base("TerritoriesEntity", LLBLGenModel.Northwind.EntityType.TerritoriesEntity) { }

		/// <summary>Creates a new, empty TerritoriesEntity object.</summary>
		/// <returns>A new, empty TerritoriesEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new TerritoriesEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTerritories
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}
		
		/// <summary>Creates a new TerritoriesEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTerritoriesUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			return toReturn;
		}

		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new entity collection objects</summary>
	[Serializable]
	public partial class GeneralEntityCollectionFactory
	{
		/// <summary>Creates a new entity collection</summary>
		/// <param name="typeToUse">The entity type to create the collection for.</param>
		/// <returns>A new entity collection object.</returns>
		public static IEntityCollection Create(LLBLGenModel.Northwind.EntityType typeToUse)
		{
			switch(typeToUse)
			{
				case LLBLGenModel.Northwind.EntityType.ActiveProductsEntity:
					return new ActiveProductsCollection();
				case LLBLGenModel.Northwind.EntityType.CategoriesEntity:
					return new CategoriesCollection();
				case LLBLGenModel.Northwind.EntityType.CustomersEntity:
					return new CustomersCollection();
				case LLBLGenModel.Northwind.EntityType.DiscontinuedProductsEntity:
					return new DiscontinuedProductsCollection();
				case LLBLGenModel.Northwind.EntityType.EmployeesEntity:
					return new EmployeesCollection();
				case LLBLGenModel.Northwind.EntityType.OrderDetailsEntity:
					return new OrderDetailsCollection();
				case LLBLGenModel.Northwind.EntityType.OrdersEntity:
					return new OrdersCollection();
				case LLBLGenModel.Northwind.EntityType.ProductsEntity:
					return new ProductsCollection();
				case LLBLGenModel.Northwind.EntityType.RegionsEntity:
					return new RegionsCollection();
				case LLBLGenModel.Northwind.EntityType.ShippersEntity:
					return new ShippersCollection();
				case LLBLGenModel.Northwind.EntityType.SuppliersEntity:
					return new SuppliersCollection();
				case LLBLGenModel.Northwind.EntityType.TerritoriesEntity:
					return new TerritoriesCollection();
				default:
					return null;
			}
		}		
	}
	
	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity Create(LLBLGenModel.Northwind.EntityType entityTypeToCreate)
		{
			IEntityFactory factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case LLBLGenModel.Northwind.EntityType.ActiveProductsEntity:
					factoryToUse = new ActiveProductsEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.CategoriesEntity:
					factoryToUse = new CategoriesEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.CustomersEntity:
					factoryToUse = new CustomersEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.DiscontinuedProductsEntity:
					factoryToUse = new DiscontinuedProductsEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.EmployeesEntity:
					factoryToUse = new EmployeesEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.OrderDetailsEntity:
					factoryToUse = new OrderDetailsEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.OrdersEntity:
					factoryToUse = new OrdersEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.ProductsEntity:
					factoryToUse = new ProductsEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.RegionsEntity:
					factoryToUse = new RegionsEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.ShippersEntity:
					factoryToUse = new ShippersEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.SuppliersEntity:
					factoryToUse = new SuppliersEntityFactory();
					break;
				case LLBLGenModel.Northwind.EntityType.TerritoriesEntity:
					factoryToUse = new TerritoriesEntityFactory();
					break;
			}
			IEntity toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
	
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
#if CF
		/// <summary>Gets the factory of the entity with the LLBLGenModel.Northwind.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(LLBLGenModel.Northwind.EntityType typeOfEntity)
		{
			return GeneralEntityFactory.Create(typeOfEntity).GetEntityFactory();
		}
#else
		private static Dictionary<Type, IEntityFactory> _factoryPerType = new Dictionary<Type, IEntityFactory>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			Array entityTypeValues = Enum.GetValues(typeof(LLBLGenModel.Northwind.EntityType));
			foreach(int entityTypeValue in entityTypeValues)
			{
				IEntity dummy = GeneralEntityFactory.Create((LLBLGenModel.Northwind.EntityType)entityTypeValue);
				_factoryPerType.Add(dummy.GetType(), dummy.GetEntityFactory());
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(Type typeOfEntity)
		{
			IEntityFactory toReturn = null;
			_factoryPerType.TryGetValue(typeOfEntity, out toReturn);
			return toReturn;
		}

		/// <summary>Gets the factory of the entity with the LLBLGenModel.Northwind.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(LLBLGenModel.Northwind.EntityType typeOfEntity)
		{
			return GetFactory(GeneralEntityFactory.Create(typeOfEntity).GetType());
		}
#endif
	}
	
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator
	{
		/// <summary>Gets the factory of the Entity type with the LLBLGenModel.Northwind.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory GetFactory(int entityTypeValue)
		{
			return (IEntityFactory)this.GetFactoryImpl(entityTypeValue);
		}

		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory GetFactory(Type typeOfEntity)
		{
			return (IEntityFactory)this.GetFactoryImpl(typeOfEntity);
		}

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields CreateResultsetFields(int numberOfFields)
		{
			return new ResultsetFields(numberOfFields);
		}
		
		/// <summary>Gets an instance of the TypedListDAO class to execute dynamic lists and projections.</summary>
		/// <returns>ready to use typedlistDAO</returns>
		public IDao GetTypedListDao()
		{
			return new TypedListDAO();
		}
		
		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand)
		{
			return new DynamicRelation(leftOperand);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperand">The right operand.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (LLBLGenModel.Northwind.EntityType)Enum.Parse(typeof(LLBLGenModel.Northwind.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperandEntityName">Name of the entity which is used as the left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasLeftOperand">The alias of the left operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((LLBLGenModel.Northwind.EntityType)Enum.Parse(typeof(LLBLGenModel.Northwind.EntityType), leftOperandEntityName, false), joinType, (LLBLGenModel.Northwind.EntityType)Enum.Parse(typeof(LLBLGenModel.Northwind.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
				
		/// <summary>Obtains the inheritance info provider instance from the singleton </summary>
		/// <returns>The singleton instance of the inheritance info provider</returns>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}

		/// <summary>Implementation of the routine which gets the factory of the Entity type with the LLBLGenModel.Northwind.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue)
		{
			return EntityFactoryFactory.GetFactory((LLBLGenModel.Northwind.EntityType)entityTypeValue);
		}
#if !CF		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity)
		{
			return EntityFactoryFactory.GetFactory(typeOfEntity);
		}
#endif
	}
}
