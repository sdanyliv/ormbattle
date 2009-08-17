///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 31 июля 2009 г. 13:36:48
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OrmBattle.LLBLGenModel.PerformanceTest.HelperClasses
{
	/// <summary>
	/// Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal sealed class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			base.InitClass((1 + 0));
			InitSimplestEntityMappings();

		}


		/// <summary>Inits SimplestEntity's mappings</summary>
		private void InitSimplestEntityMappings()
		{
			base.AddElementMapping( "SimplestEntity", "PerformanceTest", @"dbo", "Simplest", 2 );
			base.AddElementFieldMapping( "SimplestEntity", "Id", "Id", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SimplestEntity", "Value", "Value", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
		}

	}
}