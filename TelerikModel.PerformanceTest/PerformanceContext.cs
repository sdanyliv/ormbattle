using Telerik.OpenAccess;

namespace OrmBattle.TelerikModel.PerformanceTest
{
  public partial class PerformanceTest
  {
    public new IObjectScope GetScope()
    {
      return base.GetScope();
    }
  }
}