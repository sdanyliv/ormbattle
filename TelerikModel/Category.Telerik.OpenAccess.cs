

using System;
using System.Collections.Generic;

namespace OrmBattle.TelerikModel.Northwind
{
  // Generated by Telerik OpenAccess
  // Used template: c:\program files\telerik\openaccess orm\sdk\IDEIntegrations\templates\PCClassGeneration\cs\templates\classgen\class\partialdesignerdefault.vm
  [Telerik.OpenAccess.Persistent(IdentityField = "id")]
  public partial class Category
  {
    private int id; // pk 

    private string categoryName;

    private string description;

    private byte[] picture;

    private IList<Product> products = new List<Product>();  // inverse Product.category





  }
}

#region main class file contents
/*


using System;
using System.Collections.Generic;

namespace OrmBattle.TelerikModel.Northwind 
{
    //Generated by Telerik OpenAccess
    public partial class Category 
    {
        //The 'no-args' constructor required by OpenAccess. 
        public Category() 
        {
        }
    
        [Telerik.OpenAccess.FieldAlias("id")]
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
 
        [Telerik.OpenAccess.FieldAlias("categoryName")]
        public string CategoryName
        {
            get { return categoryName; }
            set { this.categoryName = value; }
        }
 
        [Telerik.OpenAccess.FieldAlias("description")]
        public string Description
        {
            get { return description; }
            set { this.description = value; }
        }
 
        [Telerik.OpenAccess.FieldAlias("picture")]
        public byte[] Picture
        {
            get { return picture; }
            set { this.picture = value; }
        }
 
        [Telerik.OpenAccess.FieldAlias("products")]
        public IList<Product> Products
        {
            get { return products; }
        }
 

    }
}
*/
#endregion //main class file contents
