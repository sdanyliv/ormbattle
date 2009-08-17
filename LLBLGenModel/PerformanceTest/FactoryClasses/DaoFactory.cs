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

using OrmBattle.LLBLGenModel.PerformanceTest.DaoClasses;
using OrmBattle.LLBLGenModel.PerformanceTest.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.PerformanceTest.FactoryClasses
{
	/// <summary>
	/// Generic factory for DAO objects. 
	/// </summary>
	public partial class DAOFactory
	{
		/// <summary>
		/// Private CTor, no instantiation possible.
		/// </summary>
		private DAOFactory()
		{
		}

		/// <summary>Creates a new SimplestDAO object</summary>
		/// <returns>the new DAO object ready to use for Simplest Entities</returns>
		public static SimplestDAO CreateSimplestDAO()
		{
			return new SimplestDAO();
		}

		/// <summary>Creates a new TypedListDAO object</summary>
		/// <returns>The new DAO object ready to use for Typed Lists</returns>
		public static TypedListDAO CreateTypedListDAO()
		{
			return new TypedListDAO();
		}

		#region Included Code

		#endregion
	}
}
