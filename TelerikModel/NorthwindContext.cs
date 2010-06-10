//Copyright (c) Telerik.  All rights reserved.
//
// usage example:
//
// // Get ObjectScope from ObjectScopeProvider
// IObjectScope scope = NorthwindContext.ObjectScope();
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
using Telerik.OpenAccess.Util;
using Telerik.OpenAccess.Query;

namespace OrmBattle.TelerikModel.Northwind
{
	/// <summary>
	/// This class provides an object context for connected database access.
	/// </summary>
	/// <remarks>
	/// This class can be used to obtain an IObjectScope instance required for a connected database
	/// access.
	/// </remarks>
	public class NorthwindContext : IObjectScopeProvider
	{
		private Database myDatabase;
		private IObjectScope myScope;

		static private NorthwindContext theNorthwindContext;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks></remarks>
		public NorthwindContext()
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
            if( theNorthwindContext == null )
                theNorthwindContext = new NorthwindContext();

            if( theNorthwindContext.myDatabase == null )
            {
                string assumedInitialConfiguration =
                           "<openaccess>" +
                               "<references>" +
                                   "<reference assemblyname='PLACEHOLDER' configrequired='True'/>" +
                               "</references>" +
                           "</openaccess>";
                System.Reflection.Assembly dll = theNorthwindContext.GetType().Assembly;
                assumedInitialConfiguration = assumedInitialConfiguration.Replace(
                                                    "PLACEHOLDER", dll.GetName().Name);
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(assumedInitialConfiguration);
                Database db = Telerik.OpenAccess.Database.Get("NorthwindConnection", 
                                            xmlDoc.DocumentElement,
                                            new System.Reflection.Assembly[] { dll } );

                theNorthwindContext.myDatabase = db;
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
			if( theNorthwindContext == null )
				theNorthwindContext = new NorthwindContext();

			if( theNorthwindContext.myDatabase == null )
				theNorthwindContext.myDatabase = Telerik.OpenAccess.Database.Get( "NorthwindConnection" );

			return theNorthwindContext.myDatabase;
		}

		/// <summary>
		/// Returns the instance of ObjectScope for the application.
		/// </summary>
		/// <returns>Instance of IObjectScope.</returns>
		/// <remarks></remarks>
		static public IObjectScope ObjectScope()
		{
			Database();

//			if( theNorthwindContext.myScope == null )
		  theNorthwindContext.myScope = GetNewObjectScope();

			return theNorthwindContext.myScope;
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

    public static NorthwindContext CurrentContext
    {
      get { return theNorthwindContext; }
    }

    public IOrderedQueryable<Category> Categories
    {
      get { return myScope.Extent<Category>(); }
    }

    public IOrderedQueryable<Customer> Customers
    {
      get { return myScope.Extent<Customer>(); }
    }

    public IOrderedQueryable<Employee> Employees
    {
      get { return myScope.Extent<Employee>(); }
    }

    public IOrderedQueryable<Order> Orders
    {
      get { return myScope.Extent<Order>(); }
    }

    public IOrderedQueryable<OrderDetail> OrderDetails
    {
      get { return myScope.Extent<OrderDetail>(); }
    }

    public IOrderedQueryable<Product> Products
    {
      get { return myScope.Extent<Product>(); }
    }

    public IOrderedQueryable<ActiveProduct> ActiveProducts
    {
      get { return myScope.Extent<ActiveProduct>(); }
    }

    public IOrderedQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get { return myScope.Extent<DiscontinuedProduct>(); }
    }

    public IOrderedQueryable<Region> Regions
    {
      get { return myScope.Extent<Region>(); }
    }

    public IOrderedQueryable<Shipper> Shippers
    {
      get { return myScope.Extent<Shipper>(); }
    }

    public IOrderedQueryable<Supplier> Suppliers
    {
      get { return myScope.Extent<Supplier>(); }
    }

    public IOrderedQueryable<Territory> Territories
    {
      get { return myScope.Extent<Territory>(); }
    }
	}
}
