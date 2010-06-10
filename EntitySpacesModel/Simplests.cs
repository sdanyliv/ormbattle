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
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

using EntitySpaces.Interfaces;

namespace OrmBattle.EntitySpacesModel
{
	/// <summary>
	/// Encapsulates the 'Simplests' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Simplests ({Id})")]
	[Serializable]
	[Table(Name="Simplests")]
	public partial class Simplests : esSimplests
	{
		public Simplests()
		{

		}
	
		public Simplests(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SimplestsMetadata.Meta();
			}
		}
		
		
		override protected string GetConnectionName()
		{
			return "PerformanceTest";
		}
		
		override protected esSimplestsQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SimplestsQuery();
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
		public SimplestsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SimplestsQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(SimplestsQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private SimplestsQuery query;
	}

}
