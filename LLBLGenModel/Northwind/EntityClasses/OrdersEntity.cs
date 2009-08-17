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
	/// Entity class which represents the entity 'Orders'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrdersEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection	_orderDetails;
		private bool	_alwaysFetchOrderDetails, _alreadyFetchedOrderDetails;

		private CustomersEntity _customer;
		private bool	_alwaysFetchCustomer, _alreadyFetchedCustomer, _customerReturnsNewIfNotFound;
		private EmployeesEntity _employee;
		private bool	_alwaysFetchEmployee, _alreadyFetchedEmployee, _employeeReturnsNewIfNotFound;
		private ShippersEntity _shipper;
		private bool	_alwaysFetchShipper, _alreadyFetchedShipper, _shipperReturnsNewIfNotFound;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Customer</summary>
			public static readonly string Customer = "Customer";
			/// <summary>Member name Employee</summary>
			public static readonly string Employee = "Employee";
			/// <summary>Member name Shipper</summary>
			public static readonly string Shipper = "Shipper";
			/// <summary>Member name OrderDetails</summary>
			public static readonly string OrderDetails = "OrderDetails";


		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrdersEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public OrdersEntity()
		{
			InitClassEmpty(null);
		}


		/// <summary>CTor</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
		public OrdersEntity(System.Int32 id)
		{
			InitClassFetch(id, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public OrdersEntity(System.Int32 id, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(id, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
		/// <param name="validator">The custom validator object for this OrdersEntity</param>
		public OrdersEntity(System.Int32 id, IValidator validator)
		{
			InitClassFetch(id, validator, null);
		}


		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected OrdersEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_orderDetails = (LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection)info.GetValue("_orderDetails", typeof(LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection));
			_alwaysFetchOrderDetails = info.GetBoolean("_alwaysFetchOrderDetails");
			_alreadyFetchedOrderDetails = info.GetBoolean("_alreadyFetchedOrderDetails");

			_customer = (CustomersEntity)info.GetValue("_customer", typeof(CustomersEntity));
			if(_customer!=null)
			{
				_customer.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_customerReturnsNewIfNotFound = info.GetBoolean("_customerReturnsNewIfNotFound");
			_alwaysFetchCustomer = info.GetBoolean("_alwaysFetchCustomer");
			_alreadyFetchedCustomer = info.GetBoolean("_alreadyFetchedCustomer");
			_employee = (EmployeesEntity)info.GetValue("_employee", typeof(EmployeesEntity));
			if(_employee!=null)
			{
				_employee.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_employeeReturnsNewIfNotFound = info.GetBoolean("_employeeReturnsNewIfNotFound");
			_alwaysFetchEmployee = info.GetBoolean("_alwaysFetchEmployee");
			_alreadyFetchedEmployee = info.GetBoolean("_alreadyFetchedEmployee");
			_shipper = (ShippersEntity)info.GetValue("_shipper", typeof(ShippersEntity));
			if(_shipper!=null)
			{
				_shipper.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_shipperReturnsNewIfNotFound = info.GetBoolean("_shipperReturnsNewIfNotFound");
			_alwaysFetchShipper = info.GetBoolean("_alwaysFetchShipper");
			_alreadyFetchedShipper = info.GetBoolean("_alreadyFetchedShipper");

			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((OrdersFieldIndex)fieldIndex)
			{
				case OrdersFieldIndex.CustomerId:
					DesetupSyncCustomer(true, false);
					_alreadyFetchedCustomer = false;
					break;
				case OrdersFieldIndex.EmployeeId:
					DesetupSyncEmployee(true, false);
					_alreadyFetchedEmployee = false;
					break;
				case OrdersFieldIndex.ShipVia:
					DesetupSyncShipper(true, false);
					_alreadyFetchedShipper = false;
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
			_alreadyFetchedOrderDetails = (_orderDetails.Count > 0);

			_alreadyFetchedCustomer = (_customer != null);
			_alreadyFetchedEmployee = (_employee != null);
			_alreadyFetchedShipper = (_shipper != null);

		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return OrdersEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Customer":
					toReturn.Add(OrdersEntity.Relations.CustomersEntityUsingCustomerId);
					break;
				case "Employee":
					toReturn.Add(OrdersEntity.Relations.EmployeesEntityUsingEmployeeId);
					break;
				case "Shipper":
					toReturn.Add(OrdersEntity.Relations.ShippersEntityUsingShipVia);
					break;
				case "OrderDetails":
					toReturn.Add(OrdersEntity.Relations.OrderDetailsEntityUsingOrderId);
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
			info.AddValue("_orderDetails", (!this.MarkedForDeletion?_orderDetails:null));
			info.AddValue("_alwaysFetchOrderDetails", _alwaysFetchOrderDetails);
			info.AddValue("_alreadyFetchedOrderDetails", _alreadyFetchedOrderDetails);

			info.AddValue("_customer", (!this.MarkedForDeletion?_customer:null));
			info.AddValue("_customerReturnsNewIfNotFound", _customerReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchCustomer", _alwaysFetchCustomer);
			info.AddValue("_alreadyFetchedCustomer", _alreadyFetchedCustomer);
			info.AddValue("_employee", (!this.MarkedForDeletion?_employee:null));
			info.AddValue("_employeeReturnsNewIfNotFound", _employeeReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchEmployee", _alwaysFetchEmployee);
			info.AddValue("_alreadyFetchedEmployee", _alreadyFetchedEmployee);
			info.AddValue("_shipper", (!this.MarkedForDeletion?_shipper:null));
			info.AddValue("_shipperReturnsNewIfNotFound", _shipperReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchShipper", _alwaysFetchShipper);
			info.AddValue("_alreadyFetchedShipper", _alreadyFetchedShipper);

			
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
				case "Customer":
					_alreadyFetchedCustomer = true;
					this.Customer = (CustomersEntity)entity;
					break;
				case "Employee":
					_alreadyFetchedEmployee = true;
					this.Employee = (EmployeesEntity)entity;
					break;
				case "Shipper":
					_alreadyFetchedShipper = true;
					this.Shipper = (ShippersEntity)entity;
					break;
				case "OrderDetails":
					_alreadyFetchedOrderDetails = true;
					if(entity!=null)
					{
						this.OrderDetails.Add((OrderDetailsEntity)entity);
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
				case "Customer":
					SetupSyncCustomer(relatedEntity);
					break;
				case "Employee":
					SetupSyncEmployee(relatedEntity);
					break;
				case "Shipper":
					SetupSyncShipper(relatedEntity);
					break;
				case "OrderDetails":
					_orderDetails.Add((OrderDetailsEntity)relatedEntity);
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
				case "Customer":
					DesetupSyncCustomer(false, true);
					break;
				case "Employee":
					DesetupSyncEmployee(false, true);
					break;
				case "Shipper":
					DesetupSyncShipper(false, true);
					break;
				case "OrderDetails":
					base.PerformRelatedEntityRemoval(_orderDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_customer!=null)
			{
				toReturn.Add(_customer);
			}
			if(_employee!=null)
			{
				toReturn.Add(_employee);
			}
			if(_shipper!=null)
			{
				toReturn.Add(_shipper);
			}


			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_orderDetails);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id)
		{
			return FetchUsingPK(id, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(id, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 id, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(id, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
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
		public bool TestOriginalFieldValueForNull(OrdersFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OrdersFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OrdersRelations().GetAllRelations();
		}


		/// <summary> Retrieves all related entities of type 'OrderDetailsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'OrderDetailsEntity'</returns>
		public LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection GetMultiOrderDetails(bool forceFetch)
		{
			return GetMultiOrderDetails(forceFetch, _orderDetails.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'OrderDetailsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'OrderDetailsEntity'</returns>
		public LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection GetMultiOrderDetails(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiOrderDetails(forceFetch, _orderDetails.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'OrderDetailsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection GetMultiOrderDetails(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiOrderDetails(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'OrderDetailsEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection GetMultiOrderDetails(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedOrderDetails || forceFetch || _alwaysFetchOrderDetails) && !base.IsSerializing && !base.IsDeserializing && !base.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_orderDetails.ParticipatesInTransaction)
					{
						base.Transaction.Add(_orderDetails);
					}
				}
				_orderDetails.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_orderDetails.EntityFactoryToUse = entityFactoryToUse;
				}
				_orderDetails.GetMultiManyToOne(this, null, filter);
				_orderDetails.SuppressClearInGetMulti=false;
				_alreadyFetchedOrderDetails = true;
			}
			return _orderDetails;
		}

		/// <summary> Sets the collection parameters for the collection for 'OrderDetails'. These settings will be taken into account
		/// when the property OrderDetails is requested or GetMultiOrderDetails is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersOrderDetails(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_orderDetails.SortClauses=sortClauses;
			_orderDetails.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


		/// <summary> Retrieves the related entity of type 'CustomersEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'CustomersEntity' which is related to this entity.</returns>
		public CustomersEntity GetSingleCustomer()
		{
			return GetSingleCustomer(false);
		}

		/// <summary> Retrieves the related entity of type 'CustomersEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'CustomersEntity' which is related to this entity.</returns>
		public virtual CustomersEntity GetSingleCustomer(bool forceFetch)
		{
			if( ( !_alreadyFetchedCustomer || forceFetch || _alwaysFetchCustomer) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(OrdersEntity.Relations.CustomersEntityUsingCustomerId);

				CustomersEntity newEntity = new CustomersEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.CustomerId);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (CustomersEntity)base.ActiveContext.Get(newEntity);
					}
					this.Customer = newEntity;
				}
				else
				{
					if(_customerReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_customer == null)))
						{
							this.Customer = newEntity;
						}
					}
					else
					{
						this.Customer = null;
					}
				}
				_alreadyFetchedCustomer = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _customer;
		}

		/// <summary> Retrieves the related entity of type 'EmployeesEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'EmployeesEntity' which is related to this entity.</returns>
		public EmployeesEntity GetSingleEmployee()
		{
			return GetSingleEmployee(false);
		}

		/// <summary> Retrieves the related entity of type 'EmployeesEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'EmployeesEntity' which is related to this entity.</returns>
		public virtual EmployeesEntity GetSingleEmployee(bool forceFetch)
		{
			if( ( !_alreadyFetchedEmployee || forceFetch || _alwaysFetchEmployee) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(OrdersEntity.Relations.EmployeesEntityUsingEmployeeId);

				EmployeesEntity newEntity = new EmployeesEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.EmployeeId.GetValueOrDefault());
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (EmployeesEntity)base.ActiveContext.Get(newEntity);
					}
					this.Employee = newEntity;
				}
				else
				{
					if(_employeeReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_employee == null)))
						{
							this.Employee = newEntity;
						}
					}
					else
					{
						this.Employee = null;
					}
				}
				_alreadyFetchedEmployee = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _employee;
		}

		/// <summary> Retrieves the related entity of type 'ShippersEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ShippersEntity' which is related to this entity.</returns>
		public ShippersEntity GetSingleShipper()
		{
			return GetSingleShipper(false);
		}

		/// <summary> Retrieves the related entity of type 'ShippersEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ShippersEntity' which is related to this entity.</returns>
		public virtual ShippersEntity GetSingleShipper(bool forceFetch)
		{
			if( ( !_alreadyFetchedShipper || forceFetch || _alwaysFetchShipper) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(OrdersEntity.Relations.ShippersEntityUsingShipVia);

				ShippersEntity newEntity = new ShippersEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.ShipVia.GetValueOrDefault());
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (ShippersEntity)base.ActiveContext.Get(newEntity);
					}
					this.Shipper = newEntity;
				}
				else
				{
					if(_shipperReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_shipper == null)))
						{
							this.Shipper = newEntity;
						}
					}
					else
					{
						this.Shipper = null;
					}
				}
				_alreadyFetchedShipper = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _shipper;
		}


		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			OrdersDAO dao = (OrdersDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_orderDetails.ActiveContext = base.ActiveContext;

			if(_customer!=null)
			{
				_customer.ActiveContext = base.ActiveContext;
			}
			if(_employee!=null)
			{
				_employee.ActiveContext = base.ActiveContext;
			}
			if(_shipper!=null)
			{
				_shipper.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			OrdersDAO dao = (OrdersDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			OrdersDAO dao = (OrdersDAO)CreateDAOInstance();
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
			return EntityFieldsFactory.CreateEntityFieldsObject(LLBLGenModel.Northwind.EntityType.OrdersEntity);
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
			toReturn.Add("Customer", _customer);
			toReturn.Add("Employee", _employee);
			toReturn.Add("Shipper", _shipper);
			toReturn.Add("OrderDetails", _orderDetails);


			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
		/// <param name="validator">The validator object for this OrdersEntity</param>
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
			_orderDetails = new LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection(new OrderDetailsEntityFactory());
			_orderDetails.SetContainingEntityInfo(this, "Order");
			_alwaysFetchOrderDetails = false;
			_alreadyFetchedOrderDetails = false;

			_customer = null;
			_customerReturnsNewIfNotFound = true;
			_alwaysFetchCustomer = false;
			_alreadyFetchedCustomer = false;
			_employee = null;
			_employeeReturnsNewIfNotFound = true;
			_alwaysFetchEmployee = false;
			_alreadyFetchedEmployee = false;
			_shipper = null;
			_shipperReturnsNewIfNotFound = true;
			_alwaysFetchShipper = false;
			_alreadyFetchedShipper = false;


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

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmployeeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrderDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequiredDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShippedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipVia", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Freight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipCity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipRegion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipPostalCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipCountry", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _customer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customer, new PropertyChangedEventHandler( OnCustomerPropertyChanged ), "Customer", OrdersEntity.Relations.CustomersEntityUsingCustomerId, true, signalRelatedEntity, "Orders", resetFKFields, new int[] { (int)OrdersFieldIndex.CustomerId } );		
			_customer = null;
		}
		
		/// <summary> setups the sync logic for member _customer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomer(IEntity relatedEntity)
		{
			if(_customer!=relatedEntity)
			{		
				DesetupSyncCustomer(true, true);
				_customer = (CustomersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customer, new PropertyChangedEventHandler( OnCustomerPropertyChanged ), "Customer", OrdersEntity.Relations.CustomersEntityUsingCustomerId, true, ref _alreadyFetchedCustomer, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _employee</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEmployee(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _employee, new PropertyChangedEventHandler( OnEmployeePropertyChanged ), "Employee", OrdersEntity.Relations.EmployeesEntityUsingEmployeeId, true, signalRelatedEntity, "Orders", resetFKFields, new int[] { (int)OrdersFieldIndex.EmployeeId } );		
			_employee = null;
		}
		
		/// <summary> setups the sync logic for member _employee</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEmployee(IEntity relatedEntity)
		{
			if(_employee!=relatedEntity)
			{		
				DesetupSyncEmployee(true, true);
				_employee = (EmployeesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _employee, new PropertyChangedEventHandler( OnEmployeePropertyChanged ), "Employee", OrdersEntity.Relations.EmployeesEntityUsingEmployeeId, true, ref _alreadyFetchedEmployee, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEmployeePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shipper</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShipper(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shipper, new PropertyChangedEventHandler( OnShipperPropertyChanged ), "Shipper", OrdersEntity.Relations.ShippersEntityUsingShipVia, true, signalRelatedEntity, "Orders", resetFKFields, new int[] { (int)OrdersFieldIndex.ShipVia } );		
			_shipper = null;
		}
		
		/// <summary> setups the sync logic for member _shipper</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShipper(IEntity relatedEntity)
		{
			if(_shipper!=relatedEntity)
			{		
				DesetupSyncShipper(true, true);
				_shipper = (ShippersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _shipper, new PropertyChangedEventHandler( OnShipperPropertyChanged ), "Shipper", OrdersEntity.Relations.ShippersEntityUsingShipVia, true, ref _alreadyFetchedShipper, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShipperPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="id">PK value for Orders which data should be fetched into this Orders object</param>
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
				base.Fields[(int)OrdersFieldIndex.Id].ForcedCurrentValueWrite(id);
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
			return DAOFactory.CreateOrdersDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new OrdersEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static OrdersRelations Relations
		{
			get	{ return new OrdersRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'OrderDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrderDetails
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection(),
					(IEntityRelation)GetRelationsForField("OrderDetails")[0], (int)LLBLGenModel.Northwind.EntityType.OrdersEntity, (int)LLBLGenModel.Northwind.EntityType.OrderDetailsEntity, 0, null, null, null, "OrderDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Customers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCustomer
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.CustomersCollection(),
					(IEntityRelation)GetRelationsForField("Customer")[0], (int)LLBLGenModel.Northwind.EntityType.OrdersEntity, (int)LLBLGenModel.Northwind.EntityType.CustomersEntity, 0, null, null, null, "Customer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Employees' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathEmployee
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.EmployeesCollection(),
					(IEntityRelation)GetRelationsForField("Employee")[0], (int)LLBLGenModel.Northwind.EntityType.OrdersEntity, (int)LLBLGenModel.Northwind.EntityType.EmployeesEntity, 0, null, null, null, "Employee", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Shippers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathShipper
		{
			get
			{
				return new PrefetchPathElement(new LLBLGenModel.Northwind.CollectionClasses.ShippersCollection(),
					(IEntityRelation)GetRelationsForField("Shipper")[0], (int)LLBLGenModel.Northwind.EntityType.OrdersEntity, (int)LLBLGenModel.Northwind.EntityType.ShippersEntity, 0, null, null, null, "Shipper", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "OrdersEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OrdersEntity.CustomProperties;}
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
			get { return OrdersEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."OrderID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)OrdersFieldIndex.Id, true); }
			set	{ SetValue((int)OrdersFieldIndex.Id, value, true); }
		}
		/// <summary> The CustomerId property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): NChar, 0, 0, 5<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CustomerId
		{
			get { return (System.String)GetValue((int)OrdersFieldIndex.CustomerId, true); }
			set	{ SetValue((int)OrdersFieldIndex.CustomerId, value, true); }
		}
		/// <summary> The EmployeeId property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."EmployeeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> EmployeeId
		{
			get { return (Nullable<System.Int32>)GetValue((int)OrdersFieldIndex.EmployeeId, false); }
			set	{ SetValue((int)OrdersFieldIndex.EmployeeId, value, true); }
		}
		/// <summary> The OrderDate property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."OrderDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> OrderDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OrdersFieldIndex.OrderDate, false); }
			set	{ SetValue((int)OrdersFieldIndex.OrderDate, value, true); }
		}
		/// <summary> The RequiredDate property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."RequiredDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> RequiredDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OrdersFieldIndex.RequiredDate, false); }
			set	{ SetValue((int)OrdersFieldIndex.RequiredDate, value, true); }
		}
		/// <summary> The ShippedDate property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShippedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ShippedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OrdersFieldIndex.ShippedDate, false); }
			set	{ SetValue((int)OrdersFieldIndex.ShippedDate, value, true); }
		}
		/// <summary> The ShipVia property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShipVia"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ShipVia
		{
			get { return (Nullable<System.Int32>)GetValue((int)OrdersFieldIndex.ShipVia, false); }
			set	{ SetValue((int)OrdersFieldIndex.ShipVia, value, true); }
		}
		/// <summary> The Freight property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."Freight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Freight
		{
			get { return (Nullable<System.Decimal>)GetValue((int)OrdersFieldIndex.Freight, false); }
			set	{ SetValue((int)OrdersFieldIndex.Freight, value, true); }
		}
		/// <summary> The ShipName property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShipName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShipName
		{
			get { return (System.String)GetValue((int)OrdersFieldIndex.ShipName, true); }
			set	{ SetValue((int)OrdersFieldIndex.ShipName, value, true); }
		}
		/// <summary> The ShipAddress property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShipAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 60<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShipAddress
		{
			get { return (System.String)GetValue((int)OrdersFieldIndex.ShipAddress, true); }
			set	{ SetValue((int)OrdersFieldIndex.ShipAddress, value, true); }
		}
		/// <summary> The ShipCity property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShipCity"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 15<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShipCity
		{
			get { return (System.String)GetValue((int)OrdersFieldIndex.ShipCity, true); }
			set	{ SetValue((int)OrdersFieldIndex.ShipCity, value, true); }
		}
		/// <summary> The ShipRegion property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShipRegion"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 15<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShipRegion
		{
			get { return (System.String)GetValue((int)OrdersFieldIndex.ShipRegion, true); }
			set	{ SetValue((int)OrdersFieldIndex.ShipRegion, value, true); }
		}
		/// <summary> The ShipPostalCode property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShipPostalCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShipPostalCode
		{
			get { return (System.String)GetValue((int)OrdersFieldIndex.ShipPostalCode, true); }
			set	{ SetValue((int)OrdersFieldIndex.ShipPostalCode, value, true); }
		}
		/// <summary> The ShipCountry property of the Entity Orders<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Orders"."ShipCountry"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 15<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShipCountry
		{
			get { return (System.String)GetValue((int)OrdersFieldIndex.ShipCountry, true); }
			set	{ SetValue((int)OrdersFieldIndex.ShipCountry, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'OrderDetailsEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiOrderDetails()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual LLBLGenModel.Northwind.CollectionClasses.OrderDetailsCollection OrderDetails
		{
			get	{ return GetMultiOrderDetails(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for OrderDetails. When set to true, OrderDetails is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time OrderDetails is accessed. You can always execute
		/// a forced fetch by calling GetMultiOrderDetails(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchOrderDetails
		{
			get	{ return _alwaysFetchOrderDetails; }
			set	{ _alwaysFetchOrderDetails = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property OrderDetails already has been fetched. Setting this property to false when OrderDetails has been fetched
		/// will clear the OrderDetails collection well. Setting this property to true while OrderDetails hasn't been fetched disables lazy loading for OrderDetails</summary>
		[Browsable(false)]
		public bool AlreadyFetchedOrderDetails
		{
			get { return _alreadyFetchedOrderDetails;}
			set 
			{
				if(_alreadyFetchedOrderDetails && !value && (_orderDetails != null))
				{
					_orderDetails.Clear();
				}
				_alreadyFetchedOrderDetails = value;
			}
		}


		/// <summary> Gets / sets related entity of type 'CustomersEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleCustomer()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual CustomersEntity Customer
		{
			get	{ return GetSingleCustomer(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomer(value);
				}
				else
				{
					if(value==null)
					{
						if(_customer != null)
						{
							_customer.UnsetRelatedEntity(this, "Orders");
						}
					}
					else
					{
						if(_customer!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Orders");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Customer. When set to true, Customer is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Customer is accessed. You can always execute
		/// a forced fetch by calling GetSingleCustomer(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCustomer
		{
			get	{ return _alwaysFetchCustomer; }
			set	{ _alwaysFetchCustomer = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Customer already has been fetched. Setting this property to false when Customer has been fetched
		/// will set Customer to null as well. Setting this property to true while Customer hasn't been fetched disables lazy loading for Customer</summary>
		[Browsable(false)]
		public bool AlreadyFetchedCustomer
		{
			get { return _alreadyFetchedCustomer;}
			set 
			{
				if(_alreadyFetchedCustomer && !value)
				{
					this.Customer = null;
				}
				_alreadyFetchedCustomer = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Customer is not found
		/// in the database. When set to true, Customer will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool CustomerReturnsNewIfNotFound
		{
			get	{ return _customerReturnsNewIfNotFound; }
			set { _customerReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'EmployeesEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleEmployee()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual EmployeesEntity Employee
		{
			get	{ return GetSingleEmployee(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEmployee(value);
				}
				else
				{
					if(value==null)
					{
						if(_employee != null)
						{
							_employee.UnsetRelatedEntity(this, "Orders");
						}
					}
					else
					{
						if(_employee!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Orders");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Employee. When set to true, Employee is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Employee is accessed. You can always execute
		/// a forced fetch by calling GetSingleEmployee(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchEmployee
		{
			get	{ return _alwaysFetchEmployee; }
			set	{ _alwaysFetchEmployee = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Employee already has been fetched. Setting this property to false when Employee has been fetched
		/// will set Employee to null as well. Setting this property to true while Employee hasn't been fetched disables lazy loading for Employee</summary>
		[Browsable(false)]
		public bool AlreadyFetchedEmployee
		{
			get { return _alreadyFetchedEmployee;}
			set 
			{
				if(_alreadyFetchedEmployee && !value)
				{
					this.Employee = null;
				}
				_alreadyFetchedEmployee = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Employee is not found
		/// in the database. When set to true, Employee will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool EmployeeReturnsNewIfNotFound
		{
			get	{ return _employeeReturnsNewIfNotFound; }
			set { _employeeReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'ShippersEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleShipper()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual ShippersEntity Shipper
		{
			get	{ return GetSingleShipper(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShipper(value);
				}
				else
				{
					if(value==null)
					{
						if(_shipper != null)
						{
							_shipper.UnsetRelatedEntity(this, "Orders");
						}
					}
					else
					{
						if(_shipper!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Orders");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Shipper. When set to true, Shipper is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Shipper is accessed. You can always execute
		/// a forced fetch by calling GetSingleShipper(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchShipper
		{
			get	{ return _alwaysFetchShipper; }
			set	{ _alwaysFetchShipper = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Shipper already has been fetched. Setting this property to false when Shipper has been fetched
		/// will set Shipper to null as well. Setting this property to true while Shipper hasn't been fetched disables lazy loading for Shipper</summary>
		[Browsable(false)]
		public bool AlreadyFetchedShipper
		{
			get { return _alreadyFetchedShipper;}
			set 
			{
				if(_alreadyFetchedShipper && !value)
				{
					this.Shipper = null;
				}
				_alreadyFetchedShipper = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Shipper is not found
		/// in the database. When set to true, Shipper will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool ShipperReturnsNewIfNotFound
		{
			get	{ return _shipperReturnsNewIfNotFound; }
			set { _shipperReturnsNewIfNotFound = value; }	
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
			get { return (int)LLBLGenModel.Northwind.EntityType.OrdersEntity; }
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
