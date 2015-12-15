using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF7Model
{
    [Table("Products")]
    public partial class Product
    {
        public Product()
        {
            Order_Details = new HashSet<OrderDetail>();
        }

        [Column("ProductID")]
        public int Id { get; set; }
        public int? CategoryID { get; set; }
        public bool Discontinued { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? ReorderLevel { get; set; }
        public int? SupplierID { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }

        public virtual ICollection<OrderDetail> Order_Details { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
