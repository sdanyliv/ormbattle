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
	/// Entity class which represents the entity 'Products'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProductsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations


		private CategoriesEntity _category;
		private bool	_alwaysFetchCategory, _alreadyFetchedCategory, _categoryReturnsNewIfNotFound;
		private SuppliersEntity _supplier;
		private bool	_alwaysFetchSupplier, _alreadyFetchedSupplier, _supplierReturnsNewIfNotFound;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Category</summary>
			public static readonly string Category = "Category";
			/// <summary>Member name Supplier</summary>
			public static readonly string Supplier = "Supplier";



		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ProductsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		internal ProductsEntity()
		{
			InitClassEmpty(null);
		}


		/// <summary>CTor</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		internal ProductsEntity(System.Int32 id)
		{
			InitClassFetch(id, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		internal ProductsEntity(System.Int32 id, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(id, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <param name="validator">The custom validator object for this ProductsEntity</param>
		internal ProductsEntity(System.Int32 id, IValidator validator)
		{
			InitClassFetch(id, validator, null);
		}


		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ProductsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{


			_category = (CategoriesEntity)info.GetValue("_category", typeof(CategoriesEntity));
			if(_category!=null)
			{
				_category.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_categoryReturnsNewIfNotFound = info.GetBoolean("_categoryReturnsNewIfNotFound");
			_alwaysFetchCategory = info.GetBoolean("_alwaysFetchCategory");
			_alreadyFetchedCategory = info.GetBoolean("_alreadyFetchedCategory");
			_supplier = (SuppliersEntity)info.GetValue("_supplier", typeof(SuppliersEntity));
			if(_supplier!=null)
			{
				_supplier.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_supplierReturnsNewIfNotFound = info.GetBoolean("_supplierReturnsNewIfNotFound");
			_alwaysFetchSupplier = info.GetBoolean("_alwaysFetchSupplier");
			_alreadyFetchedSupplier = info.GetBoolean("_alreadyFetchedSupplier");

			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ProductsFieldIndex)fieldIndex)
			{
				case ProductsFieldIndex.SupplierId:
					DesetupSyncSupplier(true, false);
					_alreadyFetchedSupplier = false;
					break;
				case ProductsFieldIndex.CategoryId:
					DesetupSyncCategory(true, false);
					_alreadyFetchedCategory = false;
					break;
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


			_alreadyFetchedCategory = (_category != null);
			_alreadyFetchedSupplier = (_supplier != null);

		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return ProductsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Category":
					toReturn.Add(ProductsEntity.Relations.CategoriesEntityUsingCategoryId);
					break;
				case "Supplier":
					toReturn.Add(ProductsEntity.Relations.SuppliersEntityUsingSupplierId);
					break;



				default:

					break;				
			}
			return toReturn;
		}

		/// <summary> Gets the inheritance info for this entity, if applicable (it's then overriden) or null if not.</summary>
		/// <returns>InheritanceInfo object if this entity is in a hierarchy of type TargetPerEntity, or null otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override IInheritanceInfo GetInheritanceInfo()
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductsEntity", false);
		}
		
		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public  static IPredicateExpression GetEntityTypeFilter()
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("ProductsEntity", false);
		}
		
		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public  static IPredicateExpression GetEntityTypeFilter(bool negate)
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("ProductsEntity", negate);
		}

		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{


			info.AddValue("_category", (!this.MarkedForDeletion?_category:null));
			info.AddValue("_categoryReturnsNewIfNotFound", _categoryReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchCategory", _alwaysFetchCategory);
			info.AddValue("_alreadyFetchedCategory", _alreadyFetchedCategory);
			info.AddValue("_supplier", (!this.MarkedForDeletion?_supplier:null));
			info.AddValue("_supplierReturnsNewIfNotFound", _supplierReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchSupplier", _alwaysFetchSupplier);
			info.AddValue("_alreadyFetchedSupplier", _alreadyFetchedSupplier);

			
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
				case "Category":
					_alreadyFetchedCategory = true;
					this.Category = (CategoriesEntity)entity;
					break;
				case "Supplier":
					_alreadyFetchedSupplier = true;
					this.Supplier = (SuppliersEntity)entity;
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
				case "Category":
					SetupSyncCategory(relatedEntity);
					break;
				case "Supplier":
					SetupSyncSupplier(relatedEntity);
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
				case "Category":
					DesetupSyncCategory(false, true);
					break;
				case "Supplier":
					DesetupSyncSupplier(false, true);
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
			if(_category!=null)
			{
				toReturn.Add(_category);
			}
			if(_supplier!=null)
			{
				toReturn.Add(_supplier);
			}


			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();


			return toReturn;
		}

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned 
		/// could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static  ProductsEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 id, Context contextToUse)
		{
			return FetchPolymorphic(transactionToUse, id, contextToUse, null);
		}
				
		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned 
		/// could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static  ProductsEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 id, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			ProductsDAO dao = new ProductsDAO();
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(LLBLGenModel.Northwind.EntityType.ProductsEntity);
			fields[(int)ProductsFieldIndex.Id].ForcedCurrentValueWrite(id);
			return (ProductsEntity)dao.FetchExistingPolymorphic(transactionToUse, fields, contextToUse, excludedIncludedFields);
		}
		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id)
		{
			return FetchUsingPK(id, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(id, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(id, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
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
		public bool TestOriginalFieldValueForNull(ProductsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ProductsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the LLBLGenModel.Northwind.EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("ProductsEntity", ((LLBLGenModel.Northwind.EntityType)typeOfEntity).ToString());
		}
				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ProductsRelations().GetAllRelations();
		}




		/// <summary> Retrieves the related entity of type 'CategoriesEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'CategoriesEntity' which is related to this entity.</returns>
		public CategoriesEntity GetSingleCategory()
		{
			return GetSingleCategory(false);
		}

		/// <summary> Retrieves the related entity of type 'CategoriesEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'CategoriesEntity' which is related to this entity.</returns>
		public virtual CategoriesEntity GetSingleCategory(bool forceFetch)
		{
			if( ( !_alreadyFetchedCategory || forceFetch || _alwaysFetchCategory) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(ProductsEntity.Relations.CategoriesEntityUsingCategoryId);

				CategoriesEntity newEntity = new CategoriesEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.CategoryId.GetValueOrDefault());
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (CategoriesEntity)base.ActiveContext.Get(newEntity);
					}
					this.Category = newEntity;
				}
				else
				{
					if(_categoryReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_category == null)))
						{
							this.Category = newEntity;
						}
					}
					else
					{
						this.Category = null;
					}
				}
				_alreadyFetchedCategory = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _category;
		}

		/// <summary> Retrieves the related entity of type 'SuppliersEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'SuppliersEntity' which is related to this entity.</returns>
		public SuppliersEntity GetSingleSupplier()
		{
			return GetSingleSupplier(false);
		}

		/// <summary> Retrieves the related entity of type 'SuppliersEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'SuppliersEntity' which is related to this entity.</returns>
		public virtual SuppliersEntity GetSingleSupplier(bool forceFetch)
		{
			if( ( !_alreadyFetchedSupplier || forceFetch || _alwaysFetchSupplier) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(ProductsEntity.Relations.SuppliersEntityUsingSupplierId);

				SuppliersEntity newEntity = new SuppliersEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.SupplierId.GetValueOrDefault());
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (SuppliersEntity)base.ActiveContext.Get(newEntity);
					}
					this.Supplier = newEntity;
				}
				else
				{
					if(_supplierReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_supplier == null)))
						{
							this.Supplier = newEntity;
						}
					}
					else
					{
						this.Supplier = null;
					}
				}
				_alreadyFetchedSupplier = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _supplier;
		}


		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			ProductsDAO dao = (ProductsDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_category!=null)
			{
				_category.ActiveContext = base.ActiveContext;
			}
			if(_supplier!=null)
			{
				_supplier.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			ProductsDAO dao = (ProductsDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			ProductsDAO dao = (ProductsDAO)CreateDAOInstance();
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
			if(base.Fields.State==EntityState.New)
			{
				base.Fields[(int)ProductsFieldIndex.Discontinued].ForcedCurrentValueWrite("");
			}
			InitClassMembers();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(LLBLGenModel.Northwind.EntityType.ProductsEntity);
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
			toReturn.Add("Category", _category);
			toReturn.Add("Supplier", _supplier);



			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
		/// <param name="validator">The validator object for this ProductsEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 id, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			base.Validator = validator;
			InitClassMembers();
			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(id, prefetchPathToUse, null, null);
			base.IsNew = !wasSuccesful;
			if(base.Fields.State==EntityState.New)
			{
				base.Fields[(int)ProductsFieldIndex.Discontinued].ForcedCurrentValueWrite("");
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{


			_category = null;
			_categoryReturnsNewIfNotFound = true;
			_alwaysFetchCategory = false;
			_alreadyFetchedCategory = false;
			_supplier = null;
			_supplierReturnsNewIfNotFound = true;
			_alwaysFetchSupplier = false;
			_alreadyFetchedSupplier = false;


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

			_fieldsCustomProperties.Add("ProductName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SupplierId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CategoryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QuantityPerUnit", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnitPrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnitsInStock", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnitsOnOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReorderLevel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Discontinued", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _category</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCategory(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _category, new PropertyChangedEventHandler( OnCategoryPropertyChanged ), "Category", ProductsEntity.Relations.CategoriesEntityUsingCategoryId, true, signalRelatedEntity, "Products", resetFKFields, new int[] { (int)ProductsFieldIndex.CategoryId } );		
			_category = null;
		}
		
		/// <summary> setups the sync logic for member _category</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCategory(IEntity relatedEntity)
		{
			if(_category!=relatedEntity)
			{		
				DesetupSyncCategory(true, true);
				_category = (CategoriesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _category, new PropertyChangedEventHandler( OnCategoryPropertyChanged ), "Category", ProductsEntity.Relations.CategoriesEntityUsingCategoryId, true, ref _alreadyFetchedCategory, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCategoryPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _supplier</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSupplier(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _supplier, new PropertyChangedEventHandler( OnSupplierPropertyChanged ), "Supplier", ProductsEntity.Relations.SuppliersEntityUsingSupplierId, true, signalRelatedEntity, "Products", resetFKFields, new int[] { (int)ProductsFieldIndex.SupplierId } );		
			_supplier = null;
		}
		
		/// <summary> setups the sync logic for member _supplier</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSupplier(IEntity relatedEntity)
		{
			if(_supplier!=relatedEntity)
			{		
				DesetupSyncSupplier(true, true);
				_supplier = (SuppliersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _supplier, new PropertyChangedEventHandler( OnSupplierPropertyChanged ), "Supplier", ProductsEntity.Relations.SuppliersEntityUsingSupplierId, true, ref _alreadyFetchedSupplier, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSupplierPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="id">PK value for Products which data should be fetched into this Products object</param>
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
				base.Fields[(int)ProductsFieldIndex.Id].ForcedCurrentValueWrite(id);
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
			return DAOFactory.CreateProductsDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ProductsEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ProductsRelations Relations
		{
			get	{ return new ProductsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Categories' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCategory
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.CategoriesCollection(),
					(IEntityRelation)GetRelationsForField("Category")[0], (int)LLBLGenModel.Northwind.EntityType.ProductsEntity, (int)LLBLGenModel.Northwind.EntityType.CategoriesEntity, 0, null, null, null, "Category", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Suppliers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupplier
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.SuppliersCollection(),
					(IEntityRelation)GetRelationsForField("Supplier")[0], (int)LLBLGenModel.Northwind.EntityType.ProductsEntity, (int)LLBLGenModel.Northwind.EntityType.SuppliersEntity, 0, null, null, null, "Supplier", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "ProductsEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ProductsEntity.CustomProperties;}
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
			get { return ProductsEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."ProductID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)ProductsFieldIndex.Id, true); }
			set	{ SetValue((int)ProductsFieldIndex.Id, value, true); }
		}
		/// <summary> The ProductName property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."ProductName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ProductName
		{
			get { return (System.String)GetValue((int)ProductsFieldIndex.ProductName, true); }
			set	{ SetValue((int)ProductsFieldIndex.ProductName, value, true); }
		}
		/// <summary> The SupplierId property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."SupplierID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SupplierId
		{
			get { return (Nullable<System.Int32>)GetValue((int)ProductsFieldIndex.SupplierId, false); }
			set	{ SetValue((int)ProductsFieldIndex.SupplierId, value, true); }
		}
		/// <summary> The CategoryId property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."CategoryID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CategoryId
		{
			get { return (Nullable<System.Int32>)GetValue((int)ProductsFieldIndex.CategoryId, false); }
			set	{ SetValue((int)ProductsFieldIndex.CategoryId, value, true); }
		}
		/// <summary> The QuantityPerUnit property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."QuantityPerUnit"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String QuantityPerUnit
		{
			get { return (System.String)GetValue((int)ProductsFieldIndex.QuantityPerUnit, true); }
			set	{ SetValue((int)ProductsFieldIndex.QuantityPerUnit, value, true); }
		}
		/// <summary> The UnitPrice property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."UnitPrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> UnitPrice
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ProductsFieldIndex.UnitPrice, false); }
			set	{ SetValue((int)ProductsFieldIndex.UnitPrice, value, true); }
		}
		/// <summary> The UnitsInStock property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."UnitsInStock"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int16> UnitsInStock
		{
			get { return (Nullable<System.Int16>)GetValue((int)ProductsFieldIndex.UnitsInStock, false); }
			set	{ SetValue((int)ProductsFieldIndex.UnitsInStock, value, true); }
		}
		/// <summary> The UnitsOnOrder property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."UnitsOnOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int16> UnitsOnOrder
		{
			get { return (Nullable<System.Int16>)GetValue((int)ProductsFieldIndex.UnitsOnOrder, false); }
			set	{ SetValue((int)ProductsFieldIndex.UnitsOnOrder, value, true); }
		}
		/// <summary> The ReorderLevel property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."ReorderLevel"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int16> ReorderLevel
		{
			get { return (Nullable<System.Int16>)GetValue((int)ProductsFieldIndex.ReorderLevel, false); }
			set	{ SetValue((int)ProductsFieldIndex.ReorderLevel, value, true); }
		}
		/// <summary> The Discontinued property of the Entity Products<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Products"."Discontinued"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Discontinued
		{
			get { return (System.String)GetValue((int)ProductsFieldIndex.Discontinued, true); }

		}



		/// <summary> Gets / sets related entity of type 'CategoriesEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleCategory()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual CategoriesEntity Category
		{
			get	{ return GetSingleCategory(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCategory(value);
				}
				else
				{
					if(value==null)
					{
						if(_category != null)
						{
							_category.UnsetRelatedEntity(this, "Products");
						}
					}
					else
					{
						if(_category!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Products");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Category. When set to true, Category is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Category is accessed. You can always execute
		/// a forced fetch by calling GetSingleCategory(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCategory
		{
			get	{ return _alwaysFetchCategory; }
			set	{ _alwaysFetchCategory = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Category already has been fetched. Setting this property to false when Category has been fetched
		/// will set Category to null as well. Setting this property to true while Category hasn't been fetched disables lazy loading for Category</summary>
		[Browsable(false)]
		public bool AlreadyFetchedCategory
		{
			get { return _alreadyFetchedCategory;}
			set 
			{
				if(_alreadyFetchedCategory && !value)
				{
					this.Category = null;
				}
				_alreadyFetchedCategory = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Category is not found
		/// in the database. When set to true, Category will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool CategoryReturnsNewIfNotFound
		{
			get	{ return _categoryReturnsNewIfNotFound; }
			set { _categoryReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'SuppliersEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleSupplier()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual SuppliersEntity Supplier
		{
			get	{ return GetSingleSupplier(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSupplier(value);
				}
				else
				{
					if(value==null)
					{
						if(_supplier != null)
						{
							_supplier.UnsetRelatedEntity(this, "Products");
						}
					}
					else
					{
						if(_supplier!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Products");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Supplier. When set to true, Supplier is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Supplier is accessed. You can always execute
		/// a forced fetch by calling GetSingleSupplier(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupplier
		{
			get	{ return _alwaysFetchSupplier; }
			set	{ _alwaysFetchSupplier = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Supplier already has been fetched. Setting this property to false when Supplier has been fetched
		/// will set Supplier to null as well. Setting this property to true while Supplier hasn't been fetched disables lazy loading for Supplier</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupplier
		{
			get { return _alreadyFetchedSupplier;}
			set 
			{
				if(_alreadyFetchedSupplier && !value)
				{
					this.Supplier = null;
				}
				_alreadyFetchedSupplier = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Supplier is not found
		/// in the database. When set to true, Supplier will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool SupplierReturnsNewIfNotFound
		{
			get	{ return _supplierReturnsNewIfNotFound; }
			set { _supplierReturnsNewIfNotFound = value; }	
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
			get { return InheritanceHierarchyType.TargetPerEntityHierarchy;}
		}
		
		/// <summary>Returns the LLBLGenModel.Northwind.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)LLBLGenModel.Northwind.EntityType.ProductsEntity; }
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
