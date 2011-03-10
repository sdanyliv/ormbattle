using System.Linq;
using Telerik.OpenAccess;

namespace OrmBattle.TelerikModel.Northwind
{
  public partial class NorthwindContext
  {
    public IObjectScope Scope
    {
      get
      {
        return this.GetScope();
      }
    }

    public IQueryable<ActiveProduct> ActiveProducts
    {
      get
      {
        return this.GetAll<ActiveProduct>();
      }
    }

    public IQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get
      {
        return this.GetAll<DiscontinuedProduct>();
      }
    }
  }
}