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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Data;
using System.Xml.Serialization;
using OrmBattle.LLBLGenModel.Northwind;
using OrmBattle.LLBLGenModel.Northwind.FactoryClasses;
using OrmBattle.LLBLGenModel.Northwind.DaoClasses;
using OrmBattle.LLBLGenModel.Northwind.RelationClasses;
using OrmBattle.LLBLGenModel.Northwind.HelperClasses;
using OrmBattle.LLBLGenModel.Northwind.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.Northwind.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	

	/// <summary>
	/// Entity class which represents the entity 'Categories'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CategoriesEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private LLBLGenModel.Northwind.CollectionClasses.ProductsCollection	_products;
		private bool	_alwaysFetchProducts, _alreadyFetchedProducts;
		private LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection _suppliersCollectionViaProducts;
		private bool	_alwaysFetchSuppliersCollectionViaProducts, _alreadyFetchedSuppliersCollectionViaProducts;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Products</summary>
			public static readonly string Products = "Products";
			/// <summary>Member name SuppliersCollectionViaProducts</summary>
			public static readonly string SuppliersCollectionViaProducts = "SuppliersCollectionViaProducts";

		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CategoriesEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public CategoriesEntity()
		{
			InitClassEmpty(null);
		}


		/// <summary>CTor</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		public CategoriesEntity(System.Int32 id)
		{
			InitClassFetch(id, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public CategoriesEntity(System.Int32 id, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(id, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <param name="validator">The custom validator object for this CategoriesEntity</param>
		public CategoriesEntity(System.Int32 id, IValidator validator)
		{
			InitClassFetch(id, validator, null);
		}


		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CategoriesEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_products = (LLBLGenModel.Northwind.CollectionClasses.ProductsCollection)info.GetValue("_products", typeof(LLBLGenModel.Northwind.CollectionClasses.ProductsCollection));
			_alwaysFetchProducts = info.GetBoolean("_alwaysFetchProducts");
			_alreadyFetchedProducts = info.GetBoolean("_alreadyFetchedProducts");
			_suppliersCollectionViaProducts = (LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection)info.GetValue("_suppliersCollectionViaProducts", typeof(LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection));
			_alwaysFetchSuppliersCollectionViaProducts = info.GetBoolean("_alwaysFetchSuppliersCollectionViaProducts");
			_alreadyFetchedSuppliersCollectionViaProducts = info.GetBoolean("_alreadyFetchedSuppliersCollectionViaProducts");


			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CategoriesFieldIndex)fieldIndex)
			{
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
		
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{
			_alreadyFetchedProducts = (_products.Count > 0);
			_alreadyFetchedSuppliersCollectionViaProducts = (_suppliersCollectionViaProducts.Count > 0);


		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return CategoriesEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Products":
					toReturn.Add(CategoriesEntity.Relations.ProductsEntityUsingCategoryId);
					break;
				case "SuppliersCollectionViaProducts":
					toReturn.Add(CategoriesEntity.Relations.ProductsEntityUsingCategoryId, "CategoriesEntity__", "Products_", JoinHint.None);
					toReturn.Add(ProductsEntity.Relations.SuppliersEntityUsingSupplierId, "Products_", string.Empty, JoinHint.None);
					break;

				default:

					break;				
			}
			return toReturn;
		}



		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_products", (!this.MarkedForDeletion?_products:null));
			info.AddValue("_alwaysFetchProducts", _alwaysFetchProducts);
			info.AddValue("_alreadyFetchedProducts", _alreadyFetchedProducts);
			info.AddValue("_suppliersCollectionViaProducts", (!this.MarkedForDeletion?_suppliersCollectionViaProducts:null));
			info.AddValue("_alwaysFetchSuppliersCollectionViaProducts", _alwaysFetchSuppliersCollectionViaProducts);
			info.AddValue("_alreadyFetchedSuppliersCollectionViaProducts", _alreadyFetchedSuppliersCollectionViaProducts);


			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity entity)
		{
			switch(propertyName)
			{

				case "Products":
					_alreadyFetchedProducts = true;
					if(entity!=null)
					{
						this.Products.Add((ProductsEntity)entity);
					}
					break;
				case "SuppliersCollectionViaProducts":
					_alreadyFetchedSuppliersCollectionViaProducts = true;
					if(entity!=null)
					{
						this.SuppliersCollectionViaProducts.Add((SuppliersEntity)entity);
					}
					break;

				default:

					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{

				case "Products":
					_products.Add((ProductsEntity)relatedEntity);
					break;

				default:

					break;
			}
		}
		
		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{

				case "Products":
					base.PerformRelatedEntityRemoval(_products, relatedEntity, signalRelatedEntityManyToOne);
					break;

				default:

					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();


			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();



			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_products);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id)
		{
			return FetchUsingPK(id, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(id, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(id, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(id, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.Id, null, null, null);
		}

		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CategoriesFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CategoriesFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CategoriesRelations().GetAllRelations();
		}


		/// <summary> Retrieves all related entities of type 'ProductsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ProductsEntity'</returns>
		public LLBLGenModel.Northwind.CollectionClasses.ProductsCollection GetMultiProducts(bool forceFetch)
		{
			return GetMultiProducts(forceFetch, _products.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ProductsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ProductsEntity'</returns>
		public LLBLGenModel.Northwind.CollectionClasses.ProductsCollection GetMultiProducts(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiProducts(forceFetch, _products.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ProductsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public LLBLGenModel.Northwind.CollectionClasses.ProductsCollection GetMultiProducts(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiProducts(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ProductsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual LLBLGenModel.Northwind.CollectionClasses.ProductsCollection GetMultiProducts(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedProducts || forceFetch || _alwaysFetchProducts) && !base.IsSerializing && !base.IsDeserializing && !base.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_products.ParticipatesInTransaction)
					{
						base.Transaction.Add(_products);
					}
				}
				_products.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_products.EntityFactoryToUse = entityFactoryToUse;
				}
				_products.GetMultiManyToOne(this, null, filter);
				_products.SuppressClearInGetMulti=false;
				_alreadyFetchedProducts = true;
			}
			return _products;
		}

		/// <summary> Sets the collection parameters for the collection for 'Products'. These settings will be taken into account
		/// when the property Products is requested or GetMultiProducts is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersProducts(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_products.SortClauses=sortClauses;
			_products.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SuppliersEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SuppliersEntity'</returns>
		public LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection GetMultiSuppliersCollectionViaProducts(bool forceFetch)
		{
			return GetMultiSuppliersCollectionViaProducts(forceFetch, _suppliersCollectionViaProducts.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'SuppliersEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection GetMultiSuppliersCollectionViaProducts(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedSuppliersCollectionViaProducts || forceFetch || _alwaysFetchSuppliersCollectionViaProducts) && !base.IsSerializing && !base.IsDeserializing && !base.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_suppliersCollectionViaProducts.ParticipatesInTransaction)
					{
						base.Transaction.Add(_suppliersCollectionViaProducts);
					}
				}
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(CategoriesFields.Id, ComparisonOperator.Equal, this.Id, "CategoriesEntity__"));
				_suppliersCollectionViaProducts.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_suppliersCollectionViaProducts.EntityFactoryToUse = entityFactoryToUse;
				}
				_suppliersCollectionViaProducts.GetMulti(filter, GetRelationsForField("SuppliersCollectionViaProducts"));
				_suppliersCollectionViaProducts.SuppressClearInGetMulti=false;
				_alreadyFetchedSuppliersCollectionViaProducts = true;
			}
			return _suppliersCollectionViaProducts;
		}

		/// <summary> Sets the collection parameters for the collection for 'SuppliersCollectionViaProducts'. These settings will be taken into account
		/// when the property SuppliersCollectionViaProducts is requested or GetMultiSuppliersCollectionViaProducts is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSuppliersCollectionViaProducts(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_suppliersCollectionViaProducts.SortClauses=sortClauses;
			_suppliersCollectionViaProducts.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}



		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			CategoriesDAO dao = (CategoriesDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_products.ActiveContext = base.ActiveContext;
			_suppliersCollectionViaProducts.ActiveContext = base.ActiveContext;



		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			CategoriesDAO dao = (CategoriesDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			CategoriesDAO dao = (CategoriesDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction, updateRestriction);
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		protected virtual void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			base.Fields = CreateFields();
			base.IsNew=true;
			base.Validator = validatorToUse;

			InitClassMembers();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(LLBLGenModel.Northwind.EntityType.CategoriesEntity);
		}
		
		/// <summary>Creates a new transaction object</summary>
		/// <param name="levelOfIsolation">The level of isolation.</param>
		/// <param name="name">The name.</param>
		protected override ITransaction CreateTransaction( IsolationLevel levelOfIsolation, string name )
		{
			return new Transaction(levelOfIsolation, name);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("Products", _products);
			toReturn.Add("SuppliersCollectionViaProducts", _suppliersCollectionViaProducts);

			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <param name="validator">The validator object for this CategoriesEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 id, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			base.Validator = validator;
			InitClassMembers();
			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(id, prefetchPathToUse, null, null);
			base.IsNew = !wasSuccesful;

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_products = new LLBLGenModel.Northwind.CollectionClasses.ProductsCollection(new ProductsEntityFactory());
			_products.SetContainingEntityInfo(this, "Category");
			_alwaysFetchProducts = false;
			_alreadyFetchedProducts = false;
			_suppliersCollectionViaProducts = new LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection(new SuppliersEntityFactory());
			_alwaysFetchSuppliersCollectionViaProducts = false;
			_alreadyFetchedSuppliersCollectionViaProducts = false;



			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CategoryName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Picture", fieldHashtable);
		}
		#endregion




		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="id">PK value for Categories which data should be fetched into this Categories object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 id, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)CategoriesFieldIndex.Id].ForcedCurrentValueWrite(id);
				dao.FetchExisting(this, base.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (base.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}


		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateCategoriesDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new CategoriesEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static CategoriesRelations Relations
		{
			get	{ return new CategoriesRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Products' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathProducts
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.ProductsCollection(),
					(IEntityRelation)GetRelationsForField("Products")[0], (int)LLBLGenModel.Northwind.EntityType.CategoriesEntity, (int)LLBLGenModel.Northwind.EntityType.ProductsEntity, 0, null, null, null, "Products", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Suppliers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSuppliersCollectionViaProducts
		{
			get
			{
				IEntityRelation intermediateRelation = CategoriesEntity.Relations.ProductsEntityUsingCategoryId;
				intermediateRelation.SetAliases(string.Empty, "Products_");
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection(), intermediateRelation,
					(int)LLBLGenModel.Northwind.EntityType.CategoriesEntity, (int)LLBLGenModel.Northwind.EntityType.SuppliersEntity, 0, null, null, GetRelationsForField("SuppliersCollectionViaProducts"), "SuppliersCollectionViaProducts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "CategoriesEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CategoriesEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return CategoriesEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity Categories<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Categories"."CategoryID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)CategoriesFieldIndex.Id, true); }
			set	{ SetValue((int)CategoriesFieldIndex.Id, value, true); }
		}
		/// <summary> The CategoryName property of the Entity Categories<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Categories"."CategoryName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 15<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CategoryName
		{
			get { return (System.String)GetValue((int)CategoriesFieldIndex.CategoryName, true); }
			set	{ SetValue((int)CategoriesFieldIndex.CategoryName, value, true); }
		}
		/// <summary> The Description property of the Entity Categories<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Categories"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CategoriesFieldIndex.Description, true); }
			set	{ SetValue((int)CategoriesFieldIndex.Description, value, true); }
		}
		/// <summary> The Picture property of the Entity Categories<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Categories"."Picture"<br/>
		/// Table field type characteristics (type, precision, scale, length): Image, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Byte[] Picture
		{
			get { return (System.Byte[])GetValue((int)CategoriesFieldIndex.Picture, true); }
			set	{ SetValue((int)CategoriesFieldIndex.Picture, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'ProductsEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiProducts()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual LLBLGenModel.Northwind.CollectionClasses.ProductsCollection Products
		{
			get	{ return GetMultiProducts(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Products. When set to true, Products is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Products is accessed. You can always execute
		/// a forced fetch by calling GetMultiProducts(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchProducts
		{
			get	{ return _alwaysFetchProducts; }
			set	{ _alwaysFetchProducts = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Products already has been fetched. Setting this property to false when Products has been fetched
		/// will clear the Products collection well. Setting this property to true while Products hasn't been fetched disables lazy loading for Products</summary>
		[Browsable(false)]
		public bool AlreadyFetchedProducts
		{
			get { return _alreadyFetchedProducts;}
			set 
			{
				if(_alreadyFetchedProducts && !value && (_products != null))
				{
					_products.Clear();
				}
				_alreadyFetchedProducts = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'SuppliersEntity' using a relation of type 'm:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSuppliersCollectionViaProducts()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection SuppliersCollectionViaProducts
		{
			get { return GetMultiSuppliersCollectionViaProducts(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SuppliersCollectionViaProducts. When set to true, SuppliersCollectionViaProducts is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SuppliersCollectionViaProducts is accessed. You can always execute
		/// a forced fetch by calling GetMultiSuppliersCollectionViaProducts(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSuppliersCollectionViaProducts
		{
			get	{ return _alwaysFetchSuppliersCollectionViaProducts; }
			set	{ _alwaysFetchSuppliersCollectionViaProducts = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property SuppliersCollectionViaProducts already has been fetched. Setting this property to false when SuppliersCollectionViaProducts has been fetched
		/// will clear the SuppliersCollectionViaProducts collection well. Setting this property to true while SuppliersCollectionViaProducts hasn't been fetched disables lazy loading for SuppliersCollectionViaProducts</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSuppliersCollectionViaProducts
		{
			get { return _alreadyFetchedSuppliersCollectionViaProducts;}
			set 
			{
				if(_alreadyFetchedSuppliersCollectionViaProducts && !value && (_suppliersCollectionViaProducts != null))
				{
					_suppliersCollectionViaProducts.Clear();
				}
				_alreadyFetchedSuppliersCollectionViaProducts = value;
			}
		}




		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary>Returns the LLBLGenModel.Northwind.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)LLBLGenModel.Northwind.EntityType.CategoriesEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Included code

		#endregion
	}
}
