using Microsoft.EntityFrameworkCore;

namespace OrmBattle.EFCoreModel
{
    public partial class NorthwindContext
    {
        public virtual DbSet<DiscontinuedProduct> DiscontinuedProducts { get; set; }
    }
}