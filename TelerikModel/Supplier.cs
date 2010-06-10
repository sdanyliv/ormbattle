using System;
using System.Collections.Generic;

namespace OrmBattle.TelerikModel.Northwind
{
  // Generated by Telerik OpenAccess
  // Used template: c:\program files\telerik\openaccess orm\sdk\IDEIntegrations\templates\PCClassGeneration\cs\templates\classgen\class\partialuserdefault.vm
  // NOTE: Field declarations and 'Object ID' class implementation are added to the 'designer' file.
  //       Changes made to the 'designer' file will be overwritten by the wizard.  	
  public partial class Supplier
  {
    //The 'no-args' constructor required by OpenAccess. 
    public Supplier()
    {
    }

    [Telerik.OpenAccess.FieldAlias("id")]
    public int Id
    {
      get { return id; }
      set { this.id = value; }
    }

    [Telerik.OpenAccess.FieldAlias("address")]
    public string Address
    {
      get { return address; }
      set { this.address = value; }
    }

    [Telerik.OpenAccess.FieldAlias("city")]
    public string City
    {
      get { return city; }
      set { this.city = value; }
    }

    [Telerik.OpenAccess.FieldAlias("companyName")]
    public string CompanyName
    {
      get { return companyName; }
      set { this.companyName = value; }
    }

    [Telerik.OpenAccess.FieldAlias("contactName")]
    public string ContactName
    {
      get { return contactName; }
      set { this.contactName = value; }
    }

    [Telerik.OpenAccess.FieldAlias("contactTitle")]
    public string ContactTitle
    {
      get { return contactTitle; }
      set { this.contactTitle = value; }
    }

    [Telerik.OpenAccess.FieldAlias("country")]
    public string Country
    {
      get { return country; }
      set { this.country = value; }
    }

    [Telerik.OpenAccess.FieldAlias("fax")]
    public string Fax
    {
      get { return fax; }
      set { this.fax = value; }
    }

    [Telerik.OpenAccess.FieldAlias("homePage")]
    public string HomePage
    {
      get { return homePage; }
      set { this.homePage = value; }
    }

    [Telerik.OpenAccess.FieldAlias("phone")]
    public string Phone
    {
      get { return phone; }
      set { this.phone = value; }
    }

    [Telerik.OpenAccess.FieldAlias("postalCode")]
    public string PostalCode
    {
      get { return postalCode; }
      set { this.postalCode = value; }
    }

    [Telerik.OpenAccess.FieldAlias("region")]
    public string Region
    {
      get { return region; }
      set { this.region = value; }
    }

    [Telerik.OpenAccess.FieldAlias("products")]
    public IList<Product> Products
    {
      get { return products; }
    }


  }
}
