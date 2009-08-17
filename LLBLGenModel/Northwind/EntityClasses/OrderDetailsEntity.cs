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
	/// Entity class which represents the entity 'OrderDetails'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrderDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations


		private OrdersEntity _order;
		private bool	_alwaysFetchOrder, _alreadyFetchedOrder, _orderReturnsNewIfNotFound;
		private ProductsEntity _product;
		private bool	_alwaysFetchProduct, _alreadyFetchedProduct, _productReturnsNewIfNotFound;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Order</summary>
			public static readonly string Order = "Order";
			/// <summary>Member name Product</summary>
			public static readonly string Product = "Product";



		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrderDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public OrderDetailsEntity()
		{
			InitClassEmpty(null);
		}


		/// <summary>CTor</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		public OrderDetailsEntity(System.Int32 orderId, System.Int32 productId)
		{
			InitClassFetch(orderId, productId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public OrderDetailsEntity(System.Int32 orderId, System.Int32 productId, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(orderId, productId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="validator">The custom validator object for this OrderDetailsEntity</param>
		public OrderDetailsEntity(System.Int32 orderId, System.Int32 productId, IValidator validator)
		{
			InitClassFetch(orderId, productId, validator, null);
		}


		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected OrderDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{


			_order = (OrdersEntity)info.GetValue("_order", typeof(OrdersEntity));
			if(_order!=null)
			{
				_order.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_orderReturnsNewIfNotFound = info.GetBoolean("_orderReturnsNewIfNotFound");
			_alwaysFetchOrder = info.GetBoolean("_alwaysFetchOrder");
			_alreadyFetchedOrder = info.GetBoolean("_alreadyFetchedOrder");
			_product = (ProductsEntity)info.GetValue("_product", typeof(ProductsEntity));
			if(_product!=null)
			{
				_product.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_productReturnsNewIfNotFound = info.GetBoolean("_productReturnsNewIfNotFound");
			_alwaysFetchProduct = info.GetBoolean("_alwaysFetchProduct");
			_alreadyFetchedProduct = info.GetBoolean("_alreadyFetchedProduct");

			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((OrderDetailsFieldIndex)fieldIndex)
			{
				case OrderDetailsFieldIndex.OrderId:
					DesetupSyncOrder(true, false);
					_alreadyFetchedOrder = false;
					break;
				case OrderDetailsFieldIndex.ProductId:
					DesetupSyncProduct(true, false);
					_alreadyFetchedProduct = false;
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


			_alreadyFetchedOrder = (_order != null);
			_alreadyFetchedProduct = (_product != null);

		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return OrderDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Order":
					toReturn.Add(OrderDetailsEntity.Relations.OrdersEntityUsingOrderId);
					break;
				case "Product":
					toReturn.Add(OrderDetailsEntity.Relations.ProductsEntityUsingProductId);
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


			info.AddValue("_order", (!this.MarkedForDeletion?_order:null));
			info.AddValue("_orderReturnsNewIfNotFound", _orderReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchOrder", _alwaysFetchOrder);
			info.AddValue("_alreadyFetchedOrder", _alreadyFetchedOrder);
			info.AddValue("_product", (!this.MarkedForDeletion?_product:null));
			info.AddValue("_productReturnsNewIfNotFound", _productReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchProduct", _alwaysFetchProduct);
			info.AddValue("_alreadyFetchedProduct", _alreadyFetchedProduct);

			
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
				case "Order":
					_alreadyFetchedOrder = true;
					this.Order = (OrdersEntity)entity;
					break;
				case "Product":
					_alreadyFetchedProduct = true;
					this.Product = (ProductsEntity)entity;
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
				case "Order":
					SetupSyncOrder(relatedEntity);
					break;
				case "Product":
					SetupSyncProduct(relatedEntity);
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
				case "Order":
					DesetupSyncOrder(false, true);
					break;
				case "Product":
					DesetupSyncProduct(false, true);
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
			if(_order!=null)
			{
				toReturn.Add(_order);
			}
			if(_product!=null)
			{
				toReturn.Add(_product);
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

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 orderId, System.Int32 productId)
		{
			return FetchUsingPK(orderId, productId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 orderId, System.Int32 productId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(orderId, productId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 orderId, System.Int32 productId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(orderId, productId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 orderId, System.Int32 productId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(orderId, productId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.OrderId, this.ProductId, null, null, null);
		}

		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OrderDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OrderDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OrderDetailsRelations().GetAllRelations();
		}




		/// <summary> Retrieves the related entity of type 'OrdersEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'OrdersEntity' which is related to this entity.</returns>
		public OrdersEntity GetSingleOrder()
		{
			return GetSingleOrder(false);
		}

		/// <summary> Retrieves the related entity of type 'OrdersEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'OrdersEntity' which is related to this entity.</returns>
		public virtual OrdersEntity GetSingleOrder(bool forceFetch)
		{
			if( ( !_alreadyFetchedOrder || forceFetch || _alwaysFetchOrder) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(OrderDetailsEntity.Relations.OrdersEntityUsingOrderId);

				OrdersEntity newEntity = new OrdersEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.OrderId);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (OrdersEntity)base.ActiveContext.Get(newEntity);
					}
					this.Order = newEntity;
				}
				else
				{
					if(_orderReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_order == null)))
						{
							this.Order = newEntity;
						}
					}
					else
					{
						this.Order = null;
					}
				}
				_alreadyFetchedOrder = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _order;
		}

		/// <summary> Retrieves the related entity of type 'ProductsEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ProductsEntity' which is related to this entity.</returns>
		public ProductsEntity GetSingleProduct()
		{
			return GetSingleProduct(false);
		}

		/// <summary> Retrieves the related entity of type 'ProductsEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ProductsEntity' which is related to this entity.</returns>
		public virtual ProductsEntity GetSingleProduct(bool forceFetch)
		{
			if( ( !_alreadyFetchedProduct || forceFetch || _alwaysFetchProduct) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(OrderDetailsEntity.Relations.ProductsEntityUsingProductId);
				// always fetch, even if performLazyLoading is false, because the related entity can be abstract so we can't simply use new. 
				ProductsEntity newEntity = ProductsEntity.FetchPolymorphic(base.Transaction, this.ProductId, base.ActiveContext);
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = (newEntity.Fields.State==EntityState.Fetched);
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (ProductsEntity)base.ActiveContext.Get(newEntity);
					}
					this.Product = newEntity;
				}
				else
				{
					if(_productReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_product == null)))
						{
							this.Product = newEntity;
						}
					}
					else
					{
						this.Product = null;
					}
				}
				_alreadyFetchedProduct = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _product;
		}


		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			OrderDetailsDAO dao = (OrderDetailsDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_order!=null)
			{
				_order.ActiveContext = base.ActiveContext;
			}
			if(_product!=null)
			{
				_product.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			OrderDetailsDAO dao = (OrderDetailsDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			OrderDetailsDAO dao = (OrderDetailsDAO)CreateDAOInstance();
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
			return EntityFieldsFactory.CreateEntityFieldsObject(LLBLGenModel.Northwind.EntityType.OrderDetailsEntity);
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
			toReturn.Add("Order", _order);
			toReturn.Add("Product", _product);



			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="validator">The validator object for this OrderDetailsEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 orderId, System.Int32 productId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			base.Validator = validator;
			InitClassMembers();
			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(orderId, productId, prefetchPathToUse, null, null);
			base.IsNew = !wasSuccesful;

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{


			_order = null;
			_orderReturnsNewIfNotFound = true;
			_alwaysFetchOrder = false;
			_alreadyFetchedOrder = false;
			_product = null;
			_productReturnsNewIfNotFound = true;
			_alwaysFetchProduct = false;
			_alreadyFetchedProduct = false;


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

			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProductId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnitPrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Quantity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Discount", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _order</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrder(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _order, new PropertyChangedEventHandler( OnOrderPropertyChanged ), "Order", OrderDetailsEntity.Relations.OrdersEntityUsingOrderId, true, signalRelatedEntity, "OrderDetails", resetFKFields, new int[] { (int)OrderDetailsFieldIndex.OrderId } );		
			_order = null;
		}
		
		/// <summary> setups the sync logic for member _order</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrder(IEntity relatedEntity)
		{
			if(_order!=relatedEntity)
			{		
				DesetupSyncOrder(true, true);
				_order = (OrdersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _order, new PropertyChangedEventHandler( OnOrderPropertyChanged ), "Order", OrderDetailsEntity.Relations.OrdersEntityUsingOrderId, true, ref _alreadyFetchedOrder, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrderPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _product</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProduct(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _product, new PropertyChangedEventHandler( OnProductPropertyChanged ), "Product", OrderDetailsEntity.Relations.ProductsEntityUsingProductId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)OrderDetailsFieldIndex.ProductId } );		
			_product = null;
		}
		
		/// <summary> setups the sync logic for member _product</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProduct(IEntity relatedEntity)
		{
			if(_product!=relatedEntity)
			{		
				DesetupSyncProduct(true, true);
				_product = (ProductsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _product, new PropertyChangedEventHandler( OnProductPropertyChanged ), "Product", OrderDetailsEntity.Relations.ProductsEntityUsingProductId, true, ref _alreadyFetchedProduct, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProductPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="orderId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="productId">PK value for OrderDetails which data should be fetched into this OrderDetails object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 orderId, System.Int32 productId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)OrderDetailsFieldIndex.OrderId].ForcedCurrentValueWrite(orderId);
				base.Fields[(int)OrderDetailsFieldIndex.ProductId].ForcedCurrentValueWrite(productId);
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
			return DAOFactory.CreateOrderDetailsDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new OrderDetailsEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static OrderDetailsRelations Relations
		{
			get	{ return new OrderDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Orders' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrder
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.OrdersCollection(),
					(IEntityRelation)GetRelationsForField("Order")[0], (int)LLBLGenModel.Northwind.EntityType.OrderDetailsEntity, (int)LLBLGenModel.Northwind.EntityType.OrdersEntity, 0, null, null, null, "Order", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Products' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathProduct
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.ProductsCollection(),
					(IEntityRelation)GetRelationsForField("Product")[0], (int)LLBLGenModel.Northwind.EntityType.OrderDetailsEntity, (int)LLBLGenModel.Northwind.EntityType.ProductsEntity, 0, null, null, null, "Product", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "OrderDetailsEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OrderDetailsEntity.CustomProperties;}
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
			get { return OrderDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The OrderId property of the Entity OrderDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Order Details"."OrderID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 OrderId
		{
			get { return (System.Int32)GetValue((int)OrderDetailsFieldIndex.OrderId, true); }
			set	{ SetValue((int)OrderDetailsFieldIndex.OrderId, value, true); }
		}
		/// <summary> The ProductId property of the Entity OrderDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Order Details"."ProductID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ProductId
		{
			get { return (System.Int32)GetValue((int)OrderDetailsFieldIndex.ProductId, true); }
			set	{ SetValue((int)OrderDetailsFieldIndex.ProductId, value, true); }
		}
		/// <summary> The UnitPrice property of the Entity OrderDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Order Details"."UnitPrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal UnitPrice
		{
			get { return (System.Decimal)GetValue((int)OrderDetailsFieldIndex.UnitPrice, true); }
			set	{ SetValue((int)OrderDetailsFieldIndex.UnitPrice, value, true); }
		}
		/// <summary> The Quantity property of the Entity OrderDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Order Details"."Quantity"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Quantity
		{
			get { return (System.Int16)GetValue((int)OrderDetailsFieldIndex.Quantity, true); }
			set	{ SetValue((int)OrderDetailsFieldIndex.Quantity, value, true); }
		}
		/// <summary> The Discount property of the Entity OrderDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Order Details"."Discount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Real, 24, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Single Discount
		{
			get { return (System.Single)GetValue((int)OrderDetailsFieldIndex.Discount, true); }
			set	{ SetValue((int)OrderDetailsFieldIndex.Discount, value, true); }
		}



		/// <summary> Gets / sets related entity of type 'OrdersEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleOrder()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual OrdersEntity Order
		{
			get	{ return GetSingleOrder(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrder(value);
				}
				else
				{
					if(value==null)
					{
						if(_order != null)
						{
							_order.UnsetRelatedEntity(this, "OrderDetails");
						}
					}
					else
					{
						if(_order!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "OrderDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Order. When set to true, Order is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Order is accessed. You can always execute
		/// a forced fetch by calling GetSingleOrder(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchOrder
		{
			get	{ return _alwaysFetchOrder; }
			set	{ _alwaysFetchOrder = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Order already has been fetched. Setting this property to false when Order has been fetched
		/// will set Order to null as well. Setting this property to true while Order hasn't been fetched disables lazy loading for Order</summary>
		[Browsable(false)]
		public bool AlreadyFetchedOrder
		{
			get { return _alreadyFetchedOrder;}
			set 
			{
				if(_alreadyFetchedOrder && !value)
				{
					this.Order = null;
				}
				_alreadyFetchedOrder = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Order is not found
		/// in the database. When set to true, Order will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool OrderReturnsNewIfNotFound
		{
			get	{ return _orderReturnsNewIfNotFound; }
			set { _orderReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'ProductsEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleProduct()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual ProductsEntity Product
		{
			get	{ return GetSingleProduct(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProduct(value);
				}
				else
				{
					if(value==null)
					{
						if(_product != null)
						{
							UnsetRelatedEntity(_product, "Product");
						}
					}
					else
					{
						if(_product!=value)
						{
							SetRelatedEntity((IEntity)value, "Product");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Product. When set to true, Product is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Product is accessed. You can always execute
		/// a forced fetch by calling GetSingleProduct(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchProduct
		{
			get	{ return _alwaysFetchProduct; }
			set	{ _alwaysFetchProduct = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Product already has been fetched. Setting this property to false when Product has been fetched
		/// will set Product to null as well. Setting this property to true while Product hasn't been fetched disables lazy loading for Product</summary>
		[Browsable(false)]
		public bool AlreadyFetchedProduct
		{
			get { return _alreadyFetchedProduct;}
			set 
			{
				if(_alreadyFetchedProduct && !value)
				{
					this.Product = null;
				}
				_alreadyFetchedProduct = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Product is not found
		/// in the database. When set to true, Product will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool ProductReturnsNewIfNotFound
		{
			get	{ return _productReturnsNewIfNotFound; }
			set { _productReturnsNewIfNotFound = value; }	
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
			get { return (int)LLBLGenModel.Northwind.EntityType.OrderDetailsEntity; }
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
