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
	/// <summary>Implements the static Relations variant for the entity: Customers. </summary>
	public partial class CustomersRelations
	{
		/// <summary>CTor</summary>
		public CustomersRelations()
		{
		}

		/// <summary>Gets all relations of the CustomersEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrdersEntityUsingCustomerId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomersEntity and OrdersEntity over the 1:n relation they have, using the relation between the fields:
		/// Customers.Id - Orders.CustomerId
		/// </summary>
		public virtual IEntityRelation OrdersEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Orders" , true);
				relation.AddEntityFieldPair(CustomersFields.Id, OrdersFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrdersEntity", false);
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
