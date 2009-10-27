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


using EntitySpaces.Interfaces;

namespace OrmBattle.EntitySpacesModel
{

    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class SimplestsQuery : esSimplestsQuery
	{
		public SimplestsQuery()
		{

		}		
		
		public SimplestsQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "SimplestsQuery";
        }
		
		
		override protected string GetConnectionName()
		{
			return "PerformanceTest";
		}	
	}
}
