/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1012.0
EntitySpaces Driver  : SQL
Date Generated       : 27.10.2009 17:17:13
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace OrmBattle.EntitySpacesModel
{

	[Serializable]
	public partial class SimplestsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SimplestsMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SimplestsMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SimplestsMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(SimplestsMetadata.ColumnNames.Value, 1, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SimplestsMetadata.PropertyNames.Value;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
		}
		#endregion	
	
		static public SimplestsMetadata Meta()
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
			if(!_providerMetadataMaps.ContainsKey(mapName))
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
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SimplestsMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
