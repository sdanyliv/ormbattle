
/*
===============================================================================
                    EntitySpaces 2010 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2010.1.0802.0
EntitySpaces Driver  : SQL
Date Generated       : 04.08.2010 21:50:57
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Xml.Serialization;


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace OrmBattle.EntitySpacesModel
{
	/// <summary>
	/// Encapsulates the 'Simplests' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[XmlType("Simplests")]
	[Table(Name="Simplests")]	
	public partial class Simplests : esSimplests
	{	
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
        protected override esEntityDebuggerView[] Debug
        {
            get { return base.Debug; }
        }

        override public esEntity CreateInstance()
        {
            return new Simplests();
        }
		
        #region Static Quick Access Methods
		static public void Delete(System.Int64 id)
        {
            var obj = new Simplests();
			obj.Id = id;
            obj.AcceptChanges();
            obj.MarkAsDeleted();
            obj.Save();
        }

	    static public void Delete(System.Int64 id, esSqlAccessType sqlAccessType)
        {
            var obj = new Simplests();
			obj.Id = id;
            obj.AcceptChanges();
            obj.MarkAsDeleted();
            obj.Save(sqlAccessType);
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
		
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("SimplestsCollection")]
	public partial class SimplestsCollection : esSimplestsCollection, IEnumerable<Simplests>
	{
		public Simplests FindByPrimaryKey(System.Int64 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class SimplestsQuery : esSimplestsQuery
	{
		public SimplestsQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        public SimplestsQuery()
        {
        }	

        override protected string GetQueryName()
        {
            return "SimplestsQuery";
        }
		
					
	
        #region Explicit Casts
		
        public static explicit operator string(SimplestsQuery query)
        {
            return SimplestsQuery.SerializeHelper.ToXml(query);
        }

        public static explicit operator SimplestsQuery(string query)
        {
            return (SimplestsQuery)SimplestsQuery.SerializeHelper.FromXml(query, typeof(SimplestsQuery));
        }
		
        #endregion		
	}


	[Serializable]
	abstract public class esSimplests : esEntity
	{
		public esSimplests()
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
			SimplestsQuery query = new SimplestsQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
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
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
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
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
								OnPropertyChanged(SimplestsMetadata.PropertyNames.Id);
							break;
						
						case "Value":
						
							if (value == null || value is System.Int64)
								this.Value = (System.Int64?)value;
								OnPropertyChanged(SimplestsMetadata.PropertyNames.Value);
							break;
					

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}
		
		
		/// <summary>
		/// Maps to Simplests.Id
		/// </summary>
		
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(SimplestsMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt64(SimplestsMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(SimplestsMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Simplests.Value
		/// </summary>
		
		virtual public System.Int64? Value
		{
			get
			{
				return base.GetSystemInt64(SimplestsMetadata.ColumnNames.Value);
			}
			
			set
			{
				if(base.SetSystemInt64(SimplestsMetadata.ColumnNames.Value, value))
				{
					OnPropertyChanged(SimplestsMetadata.PropertyNames.Value);
				}
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
			public esStrings(esSimplests entity)
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
			

			private esSimplests entity;
		}
		#endregion
		
        #region Housekeeping methods

        override protected IMetadata Meta
        {
            get
            {
                return SimplestsMetadata.Meta();
            }
        }

        #endregion		
		
        #region Query Logic

        public SimplestsQuery Query
        {
            get
            {
                if (this.query == null)
                {
                    this.query = new SimplestsQuery();
                    InitQuery(this.query);
                }

                return this.query;
            }
        }

        public bool Load(SimplestsQuery query)
        {
            this.query = query;
            InitQuery(this.query);
            return this.Query.Load();
        }
		
        protected void InitQuery(SimplestsQuery query)
        {
            query.OnLoadDelegate = this.OnQueryLoaded;
			
            if (!query.es2.HasConnection)
            {
                query.es2.Connection = ((IEntity)this).Connection;
            }			
        }

        #endregion
		
        private SimplestsQuery query;		
		
		[NonSerialized]
		private esStrings esstrings;
	}



	[Serializable]
	abstract public class esSimplestsCollection : esEntityCollection<Simplests>
	{
        #region Housekeeping methods
        override protected IMetadata Meta
        {
            get
            {
                return SimplestsMetadata.Meta();
            }
        }

        protected override string GetCollectionName()
        {
			return "SimplestsCollection";
        }

        #endregion		
		
        #region Query Logic

#if (!WindowsCE)
        [BrowsableAttribute(false)]
#endif
        public SimplestsQuery Query
        {
            get
            {
                if (this.query == null)
                {
                    this.query = new SimplestsQuery();
                    InitQuery(this.query);
                }

                return this.query;
            }
        }

        public bool Load(SimplestsQuery query)
        {
            this.query = query;
            InitQuery(this.query);
            return Query.Load();
        }

        override protected esDynamicQuery GetDynamicQuery()
        {
            if (this.query == null)
            {
                this.query = new SimplestsQuery();
                this.InitQuery(query);
            }
            return this.query;
        }

        protected void InitQuery(SimplestsQuery query)
        {
            query.OnLoadDelegate = this.OnQueryLoaded;
			
            if (!query.es2.HasConnection)
            {
                query.es2.Connection = ((IEntityCollection)this).Connection;
            }			
        }

        protected override void HookupQuery(esDynamicQuery query)
        {
            this.InitQuery((SimplestsQuery)query);
        }

        #endregion
		
        private SimplestsQuery query;
	}



	[Serializable]
	abstract public class esSimplestsQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return SimplestsMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, SimplestsMetadata.ColumnNames.Id, esSystemType.Int64);
			}
		} 
		
		public esQueryItem Value
		{
			get
			{
				return new esQueryItem(this, SimplestsMetadata.ColumnNames.Value, esSystemType.Int64);
			}
		} 
		
	}


	
	public partial class Simplests : esSimplests
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
	public partial class SimplestsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SimplestsMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SimplestsMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SimplestsMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 19;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SimplestsMetadata.ColumnNames.Value, 1, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SimplestsMetadata.PropertyNames.Value;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SimplestsMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
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
			lock (typeof(SimplestsMetadata))
			{
				if(SimplestsMetadata.mapDelegates == null)
				{
					SimplestsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SimplestsMetadata.meta == null)
				{
					SimplestsMetadata.meta = new SimplestsMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();
				

				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("Value", new esTypeMap("bigint", "System.Int64"));			
				
				
				
				meta.Source = "Simplests";
				meta.Destination = "Simplests";
				
				meta.spInsert = "proc_SimplestsInsert";				
				meta.spUpdate = "proc_SimplestsUpdate";		
				meta.spDelete = "proc_SimplestsDelete";
				meta.spLoadAll = "proc_SimplestsLoadAll";
				meta.spLoadByPrimaryKey = "proc_SimplestsLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SimplestsMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
