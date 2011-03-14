using System.Linq;
using Telerik.OpenAccess;

namespace OrmBattle.TelerikModel.Northwind
{
  public partial class NorthwindContext
  {
    public new IObjectScope GetScope()
    {
      return base.GetScope();
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