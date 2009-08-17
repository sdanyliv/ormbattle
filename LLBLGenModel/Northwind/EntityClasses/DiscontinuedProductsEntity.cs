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
	/// Entity class which represents the entity 'DiscontinuedProducts'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class DiscontinuedProductsEntity : ProductsEntity, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations




		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static new partial class MemberNames
		{
			/// <summary>Member name Category</summary>
			public static readonly string Category = "Category";
			/// <summary>Member name Supplier</summary>
			public static readonly string Supplier = "Supplier";



		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static DiscontinuedProductsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public DiscontinuedProductsEntity()
		{

		}



		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected DiscontinuedProductsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{




			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((DiscontinuedProductsFieldIndex)fieldIndex)
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




		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return DiscontinuedProductsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static new RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{




				default:
					toReturn = ProductsEntity.GetRelationsForField(fieldName);
					break;				
			}
			return toReturn;
		}

		/// <summary> Gets the inheritance info for this entity, if applicable (it's then overriden) or null if not.</summary>
		/// <returns>InheritanceInfo object if this entity is in a hierarchy of type TargetPerEntity, or null otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override IInheritanceInfo GetInheritanceInfo()
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DiscontinuedProductsEntity", false);
		}
		
		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public new static IPredicateExpression GetEntityTypeFilter()
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("DiscontinuedProductsEntity", false);
		}
		
		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public new static IPredicateExpression GetEntityTypeFilter(bool negate)
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("DiscontinuedProductsEntity", negate);
		}

		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{




			
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




				default:
					base.SetRelatedEntityProperty(propertyName, entity);
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



				default:
					base.SetRelatedEntity(relatedEntity, fieldName);
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



				default:
					base.UnsetRelatedEntity(relatedEntity, fieldName, signalRelatedEntityManyToOne);
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();

			toReturn.AddRange(base.GetDependingRelatedEntities());
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();


			toReturn.AddRange(base.GetDependentRelatedEntities());
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();

			toReturn.AddRange(base.GetMemberEntityCollections());
			return toReturn;
		}

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned 
		/// could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="id">PK value for DiscontinuedProducts which data should be fetched into this DiscontinuedProducts object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static new DiscontinuedProductsEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 id, Context contextToUse)
		{
			return FetchPolymorphic(transactionToUse, id, contextToUse, null);
		}
				
		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned 
		/// could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="id">PK value for DiscontinuedProducts which data should be fetched into this DiscontinuedProducts object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static new DiscontinuedProductsEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 id, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			DiscontinuedProductsDAO dao = new DiscontinuedProductsDAO();
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(LLBLGenModel.Northwind.EntityType.DiscontinuedProductsEntity);
			fields[(int)DiscontinuedProductsFieldIndex.Id].ForcedCurrentValueWrite(id);
			return (DiscontinuedProductsEntity)dao.FetchExistingPolymorphic(transactionToUse, fields, contextToUse, excludedIncludedFields);
		}
		


		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(DiscontinuedProductsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(DiscontinuedProductsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the LLBLGenModel.Northwind.EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("DiscontinuedProductsEntity", ((LLBLGenModel.Northwind.EntityType)typeOfEntity).ToString());
		}
				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new DiscontinuedProductsRelations().GetAllRelations();
		}






		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			DiscontinuedProductsDAO dao = (DiscontinuedProductsDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{




			base.AddInternalsToContext();
		}


	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		protected override void InitClassEmpty(IValidator validatorToUse)
		{

			base.InitClassEmpty(validatorToUse);
			if(base.Fields.State==EntityState.New)
			{
				base.Fields[(int)DiscontinuedProductsFieldIndex.Discontinued].ForcedCurrentValueWrite("1");
			}
			InitClassMembers();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END
			


		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected override IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(LLBLGenModel.Northwind.EntityType.DiscontinuedProductsEntity);
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
			Dictionary<string, object> toReturn = base.GetRelatedData();




			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="id">PK value for DiscontinuedProducts which data should be fetched into this DiscontinuedProducts object</param>
		/// <param name="validator">The validator object for this DiscontinuedProductsEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected override void InitClassFetch(System.Int32 id, IValidator validator, IPrefetchPath prefetchPathToUse)
		{

			InitClassMembers();
			base.InitClassFetch(id, validator, prefetchPathToUse);
			if(base.Fields.State==EntityState.New)
			{
				base.Fields[(int)DiscontinuedProductsFieldIndex.Discontinued].ForcedCurrentValueWrite("1");
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			


		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{





			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			

		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();


		}
		#endregion





		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateDiscontinuedProductsDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new DiscontinuedProductsEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public new static DiscontinuedProductsRelations Relations
		{
			get	{ return new DiscontinuedProductsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public new static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}






		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "DiscontinuedProductsEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return DiscontinuedProductsEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public new static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return DiscontinuedProductsEntity.FieldsCustomProperties;}
		}







		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return true;}
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
			get { return (int)LLBLGenModel.Northwind.EntityType.DiscontinuedProductsEntity; }
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
