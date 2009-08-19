/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.1.0803.0
EntitySpaces Driver  : SQL
Date Generated       : 18.08.2009 18:29:06
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace OrmBattle.EntitySpacesModel
{

	[Serializable]
	abstract public class esSimplestCollection : esEntityCollection
	{
		public esSimplestCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "SimplestCollection";
		}

		#region Query Logic
		protected void InitQuery(esSimplestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntityCollection)this).Connection;
		}

		protected bool OnQueryLoaded(DataTable table)
		{
			this.PopulateCollection(table);
			return (this.RowCount > 0) ? true : false;
		}
		
		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery(query as esSimplestQuery);
		}
		#endregion
		
		virtual public Simplest DetachEntity(Simplest entity)
		{
			return base.DetachEntity(entity) as Simplest;
		}
		
		virtual public Simplest AttachEntity(Simplest entity)
		{
			return base.AttachEntity(entity) as Simplest;
		}
		
		virtual public void Combine(SimplestCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Simplest this[int index]
		{
			get
			{
				return base[index] as Simplest;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Simplest);
		}
	}



	[Serializable]
	abstract public class esSimplest : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esSimplestQuery GetDynamicQuery()
		{
			return null;
		}

		public esSimplest()
		{

		}

		public esSimplest(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 id)
		{
			esSimplestQuery query = this.GetDynamicQuery();
			query.Where(query.Id == id);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id",id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		
		
		#region Properties
		
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}

		public override void SetProperty(string name, object value)
		{
			if(this.Row == null) this.AddNew();
			
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value.GetType().ToString() == "System.String")
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "Id": this.str.Id = (string)value; break;							
						case "Value": this.str.Value = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value.GetType().ToString() == "System.Int64")
								this.Id = (System.Int64?)value;
							break;
						
						case "Value":
						
							if (value == null || value.GetType().ToString() == "System.Int64")
								this.Value = (System.Int64?)value;
							break;
					

						default:
							break;
					}
				}
			}
			else if(this.Row.Table.Columns.Contains(name))
			{
				this.Row[name] = value;
			}
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}
		
		
		/// <summary>
		/// Maps to Simplest.Id
		/// </summary>
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(SimplestMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt64(SimplestMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to Simplest.Value
		/// </summary>
		virtual public System.Int64? Value
		{
			get
			{
				return base.GetSystemInt64(SimplestMetadata.ColumnNames.Value);
			}
			
			set
			{
				base.SetSystemInt64(SimplestMetadata.ColumnNames.Value, value);
			}
		}
		
		#endregion	

		#region String Properties


		[BrowsableAttribute( false )]
		public esStrings str
		{
			get
			{
				if (esstrings == null)
				{
					esstrings = new esStrings(this);
				}
				return esstrings;
			}
		}


		[Serializable]
		sealed public class esStrings
		{
			public esStrings(esSimplest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int64? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt64(value);
				}
			}
				
			public System.String Value
			{
				get
				{
					System.Int64? data = entity.Value;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Value = null;
					else entity.Value = Convert.ToInt64(value);
				}
			}
			

			private esSimplest entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esSimplestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntity)this).Connection;
		}

		[System.Diagnostics.DebuggerNonUserCode]
		protected bool OnQueryLoaded(DataTable table)
		{
			bool dataFound = this.PopulateEntity(table);

			if (this.RowCount > 1)
			{
				throw new Exception("esSimplest can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Simplest : esSimplest
	{

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostOneToOneSave.
		/// </summary>
		protected override void ApplyPostOneSaveKeys()
		{
		}
		
	}



	[Serializable]
	abstract public class esSimplestQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return SimplestMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, SimplestMetadata.ColumnNames.Id, esSystemType.Int64);
			}
		} 
		
		public esQueryItem Value
		{
			get
			{
				return new esQueryItem(this, SimplestMetadata.ColumnNames.Value, esSystemType.Int64);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("SimplestCollection")]
	public partial class SimplestCollection : esSimplestCollection, IEnumerable<Simplest>
	{
		public SimplestCollection()
		{

		}
		
		public static implicit operator List<Simplest>(SimplestCollection coll)
		{
			List<Simplest> list = new List<Simplest>();
			
			foreach (Simplest emp in coll)
			{
				list.Add(emp);
			}
			
			return list;
		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return  SimplestMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SimplestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Simplest(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Simplest();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public SimplestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SimplestQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(SimplestQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Simplest AddNew()
		{
			Simplest entity = base.AddNewEntity() as Simplest;
			
			return entity;
		}

		public Simplest FindByPrimaryKey(System.Int64 id)
		{
			return base.FindByPrimaryKey(id) as Simplest;
		}


		#region IEnumerable<Simplest> Members

		IEnumerator<Simplest> IEnumerable<Simplest>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Simplest;
			}
		}

		#endregion
		
		private SimplestQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Simplest' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Simplest ({Id})")]
	[Serializable]
	[Table(Name="Simplest")]
	public partial class Simplest : esSimplest
	{
		public Simplest()
		{

		}
	
		public Simplest(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SimplestMetadata.Meta();
			}
		}
		
		
		
		override protected esSimplestQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SimplestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int64? Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int64? Value
		{
			get { return base.Value;  }
			set { base.Value = value; }
		}


		#endregion



		[BrowsableAttribute( false )]
		public SimplestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SimplestQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(SimplestQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private SimplestQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
	public partial class SimplestQuery : esSimplestQuery
	{
		public SimplestQuery()
		{

		}		
		
		public SimplestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "SimplestQuery";
        }
		
			
	}


	[Serializable]
	public partial class SimplestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SimplestMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SimplestMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SimplestMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 19;
			_columns.Add(c); 
			
				
			c = new esColumnMetadata(SimplestMetadata.ColumnNames.Value, 1, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SimplestMetadata.PropertyNames.Value;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c); 
			
				
		}
		#endregion
	
		static public SimplestMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base._dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base._columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string Id = "Id";
			 public const string Value = "Value";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Value = "Value";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(SimplestMetadata))
			{
				if(SimplestMetadata.mapDelegates == null)
				{
					SimplestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SimplestMetadata.meta == null)
				{
					SimplestMetadata.meta = new SimplestMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();
				

				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("Value", new esTypeMap("bigint", "System.Int64"));			
				
				
				
				meta.Source = "Simplest";
				meta.Destination = "Simplest";
				
				meta.spInsert = "proc_SimplestInsert";				
				meta.spUpdate = "proc_SimplestUpdate";		
				meta.spDelete = "proc_SimplestDelete";
				meta.spLoadAll = "proc_SimplestLoadAll";
				meta.spLoadByPrimaryKey = "proc_SimplestLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SimplestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
