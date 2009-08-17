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
using System.Collections;
using System.Collections.Generic;
using OrmBattle.LLBLGenModel.Northwind;
using OrmBattle.LLBLGenModel.Northwind.FactoryClasses;
using OrmBattle.LLBLGenModel.Northwind.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.Northwind.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: Categories. </summary>
	public partial class CategoriesRelations
	{
		/// <summary>CTor</summary>
		public CategoriesRelations()
		{
		}

		/// <summary>Gets all relations of the CategoriesEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ProductsEntityUsingCategoryId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CategoriesEntity and ProductsEntity over the 1:n relation they have, using the relation between the fields:
		/// Categories.Id - Products.CategoryId
		/// </summary>
		public virtual IEntityRelation ProductsEntityUsingCategoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Products" , true);
				relation.AddEntityFieldPair(CategoriesFields.Id, ProductsFields.CategoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CategoriesEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductsEntity", false);
				return relation;
			}
		}



		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
