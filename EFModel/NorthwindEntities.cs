using System.Collections.Generic;
using System.Data.Entity;

namespace OrmBattle.EFModel
{
    public partial class NorthwindEntities
    {

        public virtual List<Product> DiscontinuedProducts { get; set; }
    }
}