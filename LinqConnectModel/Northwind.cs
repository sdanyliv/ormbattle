// This file is intended to be edited manually
using Devart.Data.Linq;
using System.Linq;

namespace OrmBattle.LinqConnectModel
{
    partial class NorthwindDataContext
    {
        // Place your implementation of partial extension methods here
        
        public Table<ActiveProduct> ActiveProducts { get { return GetTable<ActiveProduct>(); } }
        public Table<DiscontinuedProduct> DiscontinuedProducts { get { return GetTable<DiscontinuedProduct>(); } }
        /*public IQueryable<DiscontinuedProduct> DiscontinuedProducts { 
          get { 
            return 
              from p in Products
              where p is DiscontinuedProduct
              select (DiscontinuedProduct)p; 
          } 
        }*/
    }
}