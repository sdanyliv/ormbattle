/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1012.0
EntitySpaces Driver  : SQL
Date Generated       : 27.10.2009 17:17:12
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


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace OrmBattle.EntitySpacesModel
{

	[Serializable]
	abstract public class esSimplestsCollection : esEntityCollection
	{
		public esSimplestsCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "SimplestsCollection";
		}

		#region Query Logic
		protected void InitQuery(esSimplestsQuery query)
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
			this.InitQuery(query as esSimplestsQuery);
		}
		#endregion
		
		virtual public Simplests DetachEntity(Simplests entity)
		{
			return base.DetachEntity(entity) as Simplests;
		}
		
		virtual public Simplests AttachEntity(Simplests entity)
		{
			return base.AttachEntity(entity) as Simplests;
		}
		
		virtual public void Combine(SimplestsCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Simplests this[int index]
		{
			get
			{
				return base[index] as Simplests;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Simplests);
		}
	}

}
