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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace OrmBattle.EntitySpacesModel
{

    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("SimplestsCollection")]
	public partial class SimplestsCollection : esSimplestsCollection, IEnumerable<Simplests>
	{
		public SimplestsCollection()
		{

		}
		
		public static implicit operator List<Simplests>(SimplestsCollection coll)
		{
			List<Simplests> list = new List<Simplests>();
			
			foreach (Simplests emp in coll)
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
				return  SimplestsMetadata.Meta();
			}
		}
		
		
		override protected string GetConnectionName()
		{
			return "PerformanceTest";
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
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Simplests(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Simplests();
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
		
		public Simplests AddNew()
		{
			Simplests entity = base.AddNewEntity() as Simplests;
			
			return entity;
		}

		public Simplests FindByPrimaryKey(System.Int64 id)
		{
			return base.FindByPrimaryKey(id) as Simplests;
		}


		#region IEnumerable<Simplests> Members

		IEnumerator<Simplests> IEnumerable<Simplests>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Simplests;
			}
		}

		#endregion
		
		private SimplestsQuery query;
	}

}
