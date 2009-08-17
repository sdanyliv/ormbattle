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
	/// <summary>Implements the static Relations variant for the entity: DiscontinuedProducts. </summary>
	public partial class DiscontinuedProductsRelations : ProductsRelations
	{
		/// <summary>CTor</summary>
		public DiscontinuedProductsRelations()
		{
		}

		/// <summary>Gets all relations of the DiscontinuedProductsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = base.GetAllRelations();



			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between DiscontinuedProductsEntity and OrderDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// DiscontinuedProducts.Id - OrderDetails.ProductId
		/// </summary>
		public override IEntityRelation OrderDetailsEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(DiscontinuedProductsFields.Id, OrderDetailsFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DiscontinuedProductsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between DiscontinuedProductsEntity and CategoriesEntity over the m:1 relation they have, using the relation between the fields:
		/// DiscontinuedProducts.CategoryId - Categories.Id
		/// </summary>
		public override IEntityRelation CategoriesEntityUsingCategoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Category", false);
				relation.AddEntityFieldPair(CategoriesFields.Id, DiscontinuedProductsFields.CategoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CategoriesEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DiscontinuedProductsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DiscontinuedProductsEntity and SuppliersEntity over the m:1 relation they have, using the relation between the fields:
		/// DiscontinuedProducts.SupplierId - Suppliers.Id
		/// </summary>
		public override IEntityRelation SuppliersEntityUsingSupplierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Supplier", false);
				relation.AddEntityFieldPair(SuppliersFields.Id, DiscontinuedProductsFields.SupplierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuppliersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DiscontinuedProductsEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public override IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public override IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
