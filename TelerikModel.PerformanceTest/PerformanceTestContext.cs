//Copyright (c) Telerik.  All rights reserved.
//
// usage example:
//
// // Get ObjectScope from ObjectScopeProvider
// IObjectScope scope = PerformanceTestContext.ObjectScope();
// // start transaction
// scope.Transaction.Begin();
// // create new persistent object person and add to scope
// Person p = new Person();
// scope.Add(p);
// // commit transction
// scope.Transaction.Commit();
//

using System.Linq;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Query;
using Telerik.OpenAccess.Util;

namespace OrmBattle.TelerikModel.PerformanceTest
{
	/// <summary>
	/// This class provides an object context for connected database access.
	/// </summary>
	/// <remarks>
	/// This class can be used to obtain an IObjectScope instance required for a connected database
	/// access.
	/// </remarks>
	public class PerformanceTestContext : IObjectScopeProvider
	{
		private Database myDatabase;
		private IObjectScope myScope;

		static private PerformanceTestContext thePerformanceTestContext;


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks></remarks>
		public PerformanceTestContext()
		{
		}

        /// <summary>
		/// Adjusts for dynamic loading when no entry assembly is available/configurable.
		/// </summary>
		/// <remarks>
        /// When dynamic loading is used, the configuration path from the
        /// applications entry assembly to the connection setting might be broken.
        /// This method makes up the necessary configuration entries.
        /// </remarks>
        static public void AdjustForDynamicLoad()
        {
            if( thePerformanceTestContext == null )
                thePerformanceTestContext = new PerformanceTestContext();

            if( thePerformanceTestContext.myDatabase == null )
            {
                string assumedInitialConfiguration =
                           "<openaccess>" +
                               "<references>" +
                                   "<reference assemblyname='PLACEHOLDER' configrequired='True'/>" +
                               "</references>" +
                           "</openaccess>";
                System.Reflection.Assembly dll = thePerformanceTestContext.GetType().Assembly;
                assumedInitialConfiguration = assumedInitialConfiguration.Replace(
                                                    "PLACEHOLDER", dll.GetName().Name);
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(assumedInitialConfiguration);
                Database db = Telerik.OpenAccess.Database.Get("PerformanceTest", 
                                            xmlDoc.DocumentElement,
                                            new System.Reflection.Assembly[] { dll } );

                thePerformanceTestContext.myDatabase = db;
            }
        }

		/// <summary>
		/// Returns the instance of Database for the connectionId 
		/// specified in the Enable Project Wizard.
		/// </summary>
		/// <returns>Instance of Database.</returns>
		/// <remarks></remarks>
		static public Database Database()
		{
			if( thePerformanceTestContext == null )
				thePerformanceTestContext = new PerformanceTestContext();

			if( thePerformanceTestContext.myDatabase == null )
				thePerformanceTestContext.myDatabase = Telerik.OpenAccess.Database.Get( "PerformanceTest" );

			return thePerformanceTestContext.myDatabase;
		}

		/// <summary>
		/// Returns the instance of ObjectScope for the application.
		/// </summary>
		/// <returns>Instance of IObjectScope.</returns>
		/// <remarks></remarks>
		static public IObjectScope ObjectScope()
		{
			Database();

//			if( thePerformanceTestContext.myScope == null )
		  thePerformanceTestContext.myScope = GetNewObjectScope();

			return thePerformanceTestContext.myScope;
		}

		/// <summary>
		/// Returns the new instance of ObjectScope for the application.
		/// </summary>
		/// <returns>Instance of IObjectScope.</returns>
		/// <remarks></remarks>
		static public IObjectScope GetNewObjectScope()
		{
			Database db = Database();

			IObjectScope newScope = db.GetObjectScope();
			return newScope;
		}

	  public static PerformanceTestContext CurrentContext
	  {
	    get { return thePerformanceTestContext; }
	  }

	  public IOrderedQueryable<Simplest> Simplests
    {
      get { return myScope.Extent<Simplest>(); }
    }
	}
}
