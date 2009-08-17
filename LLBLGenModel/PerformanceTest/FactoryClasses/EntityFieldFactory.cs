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
using System.Data;
using OrmBattle.LLBLGenModel.PerformanceTest;
using OrmBattle.LLBLGenModel.PerformanceTest.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.PerformanceTest.FactoryClasses
{
	/// <summary>
	/// Factory class for IEntityField instances, used in IEntityFields instances.
	/// </summary>
	public partial class EntityFieldFactory
	{
		/// <summary>
		/// Private CTor, no instantiation possible.
		/// </summary>
		private EntityFieldFactory()
		{
		}

		/// <summary>Creates a new IEntityField instance for usage in the EntityFields object for the SimplestEntity.  Which EntityField is created is specified by fieldIndex</summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(SimplestFieldIndex fieldIndex)
		{
			IFieldInfo info = FieldInfoProviderSingleton.GetInstance().GetFieldInfo("SimplestEntity", (int)fieldIndex);
			return new EntityField(info, PersistenceInfoProviderSingleton.GetInstance().GetFieldPersistenceInfo(info.ContainingObjectName, info.Name));
		}


		/// <summary>Creates a new IEntityField instance, which represents the field objectName.fieldName</summary>
		/// <param name="objectName">the name of the object the field belongs to, like CustomerEntity or OrdersTypedView</param>
		/// <param name="fieldName">the name of the field to create</param>
		public static IEntityField Create(string objectName, string fieldName)
        {
			return new EntityField(FieldInfoProviderSingleton.GetInstance().GetFieldInfo(objectName, fieldName), PersistenceInfoProviderSingleton.GetInstance().GetFieldPersistenceInfo(objectName, fieldName));
        }

		#region Included Code

		#endregion
	}
}
