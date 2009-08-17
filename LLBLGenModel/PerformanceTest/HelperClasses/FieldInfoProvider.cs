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
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.PerformanceTest.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	
	/// <summary>
	/// Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal sealed class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private FieldInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			base.InitClass( (1 + 0));
			InitSimplestEntityInfos();

			base.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits SimplestEntity's FieldInfo objects</summary>
		private void InitSimplestEntityInfos()
		{
			base.AddElementFieldInfo("SimplestEntity", "Id", typeof(System.Int64), true, false, false, false,  (int)SimplestFieldIndex.Id, 0, 0, 19);
			base.AddElementFieldInfo("SimplestEntity", "Value", typeof(System.Int64), false, false, false, false,  (int)SimplestFieldIndex.Value, 0, 0, 19);
		}
		
	}
}




