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
	/// <summary>Implements the static Relations variant for the entity: Orders. </summary>
	public partial class OrdersRelations
	{
		/// <summary>CTor</summary>
		public OrdersRelations()
		{
		}

		/// <summary>Gets all relations of the OrdersEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrderDetailsEntityUsingOrderId);

			toReturn.Add(this.CustomersEntityUsingCustomerId);
			toReturn.Add(this.EmployeesEntityUsingEmployeeId);
			toReturn.Add(this.ShippersEntityUsingShipVia);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrdersEntity and OrderDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Orders.Id - OrderDetails.OrderId
		/// </summary>
		public virtual IEntityRelation OrderDetailsEntityUsingOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrderDetails" , true);
				relation.AddEntityFieldPair(OrdersFields.Id, OrderDetailsFields.OrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrdersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OrdersEntity and CustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// Orders.CustomerId - Customers.Id
		/// </summary>
		public virtual IEntityRelation CustomersEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Customer", false);
				relation.AddEntityFieldPair(CustomersFields.Id, OrdersFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrdersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrdersEntity and EmployeesEntity over the m:1 relation they have, using the relation between the fields:
		/// Orders.EmployeeId - Employees.Id
		/// </summary>
		public virtual IEntityRelation EmployeesEntityUsingEmployeeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Employee", false);
				relation.AddEntityFieldPair(EmployeesFields.Id, OrdersFields.EmployeeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeesEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrdersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrdersEntity and ShippersEntity over the m:1 relation they have, using the relation between the fields:
		/// Orders.ShipVia - Shippers.Id
		/// </summary>
		public virtual IEntityRelation ShippersEntityUsingShipVia
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Shipper", false);
				relation.AddEntityFieldPair(ShippersFields.Id, OrdersFields.ShipVia);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrdersEntity", true);
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
