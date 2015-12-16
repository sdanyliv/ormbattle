using System;
using System.Collections.Generic;

namespace OrmBattle.EF7Model
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerID { get; set; }
        public string CustomerTypeID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
