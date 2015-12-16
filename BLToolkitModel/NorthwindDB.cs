using System;
using System.Diagnostics;

using BLToolkit.Data;
using BLToolkit.Data.Linq;

namespace OrmBattle.BLToolkitModel
{
	public class NorthwindDB : DbManager
	{
		public NorthwindDB()
			: base("Northwind")
		{
		}

		public Table<Category>            Categories           { get { return GetTable<Category>();            } }
		public Table<Customer>            Customers            { get { return GetTable<Customer>();            } }
		public Table<Employee>            Employees            { get { return GetTable<Employee>();            } }
		public Table<EmployeeTerritory>   EmployeeTerritories  { get { return GetTable<EmployeeTerritory>();   } }
		public Table<OrderDetail>         OrderDetails         { get { return GetTable<OrderDetail>();         } }
		public Table<Order>               Orders               { get { return GetTable<Order>();               } }
		public Table<Product>             Products             { get { return GetTable<Product>();             } }
		public Table<ActiveProduct>       ActiveProducts       { get { return GetTable<ActiveProduct>();       } }
		public Table<DiscontinuedProduct> DiscontinuedProducts { get { return GetTable<DiscontinuedProduct>(); } }
		public Table<Region>              Region               { get { return GetTable<Region>();              } }
		public Table<Shipper>             Shipper              { get { return GetTable<Shipper>();             } }
		public Table<Supplier>            Suppliers            { get { return GetTable<Supplier>();            } }
		public Table<Territory>           Territories          { get { return GetTable<Territory>();           } }
	}
}
