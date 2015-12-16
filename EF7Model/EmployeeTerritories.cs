using System;
using System.Collections.Generic;

namespace OrmBattle.EF7Model
{
    public partial class EmployeeTerritories
    {
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territories Territory { get; set; }
    }
}
