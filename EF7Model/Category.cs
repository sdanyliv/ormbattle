using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrmBattle.EF7Model
{
    [Table("Categories")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Column("CategoryID")]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
