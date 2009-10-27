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

}
