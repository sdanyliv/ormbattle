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
	/// <summary>Implements the static Relations variant for the entity: OrderDetails. </summary>
	public partial class OrderDetailsRelations
	{
		/// <summary>CTor</summary>
		public OrderDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the OrderDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.OrdersEntityUsingOrderId);
			toReturn.Add(this.ProductsEntityUsingProductId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between OrderDetailsEntity and OrdersEntity over the m:1 relation they have, using the relation between the fields:
		/// OrderDetails.OrderId - Orders.Id
		/// </summary>
		public virtual IEntityRelation OrdersEntityUsingOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Order", false);
				relation.AddEntityFieldPair(OrdersFields.Id, OrderDetailsFields.OrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrdersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrderDetailsEntity and ProductsEntity over the m:1 relation they have, using the relation between the fields:
		/// OrderDetails.ProductId - Products.Id
		/// </summary>
		public virtual IEntityRelation ProductsEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Product", false);
				relation.AddEntityFieldPair(ProductsFields.Id, OrderDetailsFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailsEntity", true);
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
