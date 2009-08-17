///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 31 июля 2009 г. 13:36:48
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using OrmBattle.LLBLGenModel.PerformanceTest;
using OrmBattle.LLBLGenModel.PerformanceTest.FactoryClasses;
using OrmBattle.LLBLGenModel.PerformanceTest.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.PerformanceTest.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: Simplest. </summary>
	public partial class SimplestRelations
	{
		/// <summary>CTor</summary>
		public SimplestRelations()
		{
		}

		/// <summary>Gets all relations of the SimplestEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();



			return toReturn;
		}

		#region Class Property Declarations




		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
