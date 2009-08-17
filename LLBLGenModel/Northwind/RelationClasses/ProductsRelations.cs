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
	/// <summary>Implements the static Relations variant for the entity: Products. </summary>
	public partial class ProductsRelations : IRelationFactory
	{
		/// <summary>CTor</summary>
		public ProductsRelations()
		{
		}

		/// <summary>Gets all relations of the ProductsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrderDetailsEntityUsingProductId);

			toReturn.Add(this.CategoriesEntityUsingCategoryId);
			toReturn.Add(this.SuppliersEntityUsingSupplierId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProductsEntity and OrderDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Products.Id - OrderDetails.ProductId
		/// </summary>
		public virtual IEntityRelation OrderDetailsEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(ProductsFields.Id, OrderDetailsFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ProductsEntity and CategoriesEntity over the m:1 relation they have, using the relation between the fields:
		/// Products.CategoryId - Categories.Id
		/// </summary>
		public virtual IEntityRelation CategoriesEntityUsingCategoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Category", false);
				relation.AddEntityFieldPair(CategoriesFields.Id, ProductsFields.CategoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CategoriesEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProductsEntity and SuppliersEntity over the m:1 relation they have, using the relation between the fields:
		/// Products.SupplierId - Suppliers.Id
		/// </summary>
		public virtual IEntityRelation SuppliersEntityUsingSupplierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Supplier", false);
				relation.AddEntityFieldPair(SuppliersFields.Id, ProductsFields.SupplierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuppliersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductsEntity", true);
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
