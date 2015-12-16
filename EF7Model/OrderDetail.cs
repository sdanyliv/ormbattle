using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrmBattle.EF7Model
{
    [Table("Order Details")]
    public partial class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float Discount { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
