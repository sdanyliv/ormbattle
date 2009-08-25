using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace LightSpeedModel.Northwind
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Categories", IdColumnName="CategoryID")]
  [System.ComponentModel.DataObject]
  public partial class Category : Entity<int>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateLength(0, 15)]
    private string _categoryName;
    [ValidateLength(0, 1073741823)]
    private string _description;
    private byte[] _picture;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the CategoryName entity attribute.</summary>
    public const string CategoryNameField = "CategoryName";
    /// <summary>Identifies the Description entity attribute.</summary>
    public const string DescriptionField = "Description";
    /// <summary>Identifies the Picture entity attribute.</summary>
    public const string PictureField = "Picture";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Category")]
    private readonly EntityCollection<Product> _products = new EntityCollection<Product>();


    #endregion
    
    #region Properties

    public EntityCollection<Product> Products
    {
      get { return Get(_products); }
    }


    public string CategoryName
    {
      get { return Get(ref _categoryName, "CategoryName"); }
      set { Set(ref _categoryName, value, "CategoryName"); }
    }

    public string Description
    {
      get { return Get(ref _description, "Description"); }
      set { Set(ref _description, value, "Description"); }
    }

    public byte[] Picture
    {
      get { return Get(ref _picture, "Picture"); }
      set { Set(ref _picture, value, "Picture"); }
    }

    #endregion
  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Customers", IdColumnName="CustomerID")]
  [System.ComponentModel.DataObject]
  public partial class Customer : Entity<string>
  {
    #region Fields
  
    [ValidateLength(0, 60)]
    private string _address;
    [ValidateLength(0, 15)]
    private string _city;
    [ValidatePresence]
    [ValidateLength(0, 40)]
    private string _companyName;
    [ValidateLength(0, 30)]
    private string _contactName;
    [ValidateLength(0, 30)]
    private string _contactTitle;
    [ValidateLength(0, 15)]
    private string _country;
    [ValidateLength(0, 24)]
    private string _fax;
    [ValidateLength(0, 24)]
    private string _phone;
    [ValidateLength(0, 10)]
    private string _postalCode;
    [ValidateLength(0, 15)]
    private string _region;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Address entity attribute.</summary>
    public const string AddressField = "Address";
    /// <summary>Identifies the City entity attribute.</summary>
    public const string CityField = "City";
    /// <summary>Identifies the CompanyName entity attribute.</summary>
    public const string CompanyNameField = "CompanyName";
    /// <summary>Identifies the ContactName entity attribute.</summary>
    public const string ContactNameField = "ContactName";
    /// <summary>Identifies the ContactTitle entity attribute.</summary>
    public const string ContactTitleField = "ContactTitle";
    /// <summary>Identifies the Country entity attribute.</summary>
    public const string CountryField = "Country";
    /// <summary>Identifies the Fax entity attribute.</summary>
    public const string FaxField = "Fax";
    /// <summary>Identifies the Phone entity attribute.</summary>
    public const string PhoneField = "Phone";
    /// <summary>Identifies the PostalCode entity attribute.</summary>
    public const string PostalCodeField = "PostalCode";
    /// <summary>Identifies the Region entity attribute.</summary>
    public const string RegionField = "Region";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Customer")]
    private readonly EntityCollection<Order> _orders = new EntityCollection<Order>();


    #endregion
    
    #region Properties

    public EntityCollection<Order> Orders
    {
      get { return Get(_orders); }
    }


    public string Address
    {
      get { return Get(ref _address, "Address"); }
      set { Set(ref _address, value, "Address"); }
    }

    public string City
    {
      get { return Get(ref _city, "City"); }
      set { Set(ref _city, value, "City"); }
    }

    public string CompanyName
    {
      get { return Get(ref _companyName, "CompanyName"); }
      set { Set(ref _companyName, value, "CompanyName"); }
    }

    public string ContactName
    {
      get { return Get(ref _contactName, "ContactName"); }
      set { Set(ref _contactName, value, "ContactName"); }
    }

    public string ContactTitle
    {
      get { return Get(ref _contactTitle, "ContactTitle"); }
      set { Set(ref _contactTitle, value, "ContactTitle"); }
    }

    public string Country
    {
      get { return Get(ref _country, "Country"); }
      set { Set(ref _country, value, "Country"); }
    }

    public string Fax
    {
      get { return Get(ref _fax, "Fax"); }
      set { Set(ref _fax, value, "Fax"); }
    }

    public string Phone
    {
      get { return Get(ref _phone, "Phone"); }
      set { Set(ref _phone, value, "Phone"); }
    }

    public string PostalCode
    {
      get { return Get(ref _postalCode, "PostalCode"); }
      set { Set(ref _postalCode, value, "PostalCode"); }
    }

    public string Region
    {
      get { return Get(ref _region, "Region"); }
      set { Set(ref _region, value, "Region"); }
    }

    #endregion
  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Employees", IdColumnName="EmployeeID")]
  [System.ComponentModel.DataObject]
  public partial class Employee : Entity<int>
  {
    #region Fields
  
    [ValidateLength(0, 60)]
    private string _address;
    private System.Nullable<System.DateTime> _birthDate;
    [ValidateLength(0, 15)]
    private string _city;
    [ValidateLength(0, 15)]
    private string _country;
    [ValidateLength(0, 4)]
    private string _extension;
    [ValidatePresence]
    [ValidateLength(0, 10)]
    private string _firstName;
    private System.Nullable<System.DateTime> _hireDate;
    [ValidateLength(0, 24)]
    private string _homePhone;
    [ValidatePresence]
    [ValidateLength(0, 20)]
    private string _lastName;
    [ValidateLength(0, 1073741823)]
    private string _notes;
    private byte[] _photo;
    [ValidateLength(0, 255)]
    private string _photoPath;
    [ValidateLength(0, 10)]
    private string _postalCode;
    [ValidateLength(0, 15)]
    private string _region;
    [ValidateLength(0, 30)]
    private string _title;
    [ValidateLength(0, 25)]
    private string _titleOfCourtesy;
    [Column("ReportsTo")]
    private System.Nullable<int> _reportsToId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Address entity attribute.</summary>
    public const string AddressField = "Address";
    /// <summary>Identifies the BirthDate entity attribute.</summary>
    public const string BirthDateField = "BirthDate";
    /// <summary>Identifies the City entity attribute.</summary>
    public const string CityField = "City";
    /// <summary>Identifies the Country entity attribute.</summary>
    public const string CountryField = "Country";
    /// <summary>Identifies the Extension entity attribute.</summary>
    public const string ExtensionField = "Extension";
    /// <summary>Identifies the FirstName entity attribute.</summary>
    public const string FirstNameField = "FirstName";
    /// <summary>Identifies the HireDate entity attribute.</summary>
    public const string HireDateField = "HireDate";
    /// <summary>Identifies the HomePhone entity attribute.</summary>
    public const string HomePhoneField = "HomePhone";
    /// <summary>Identifies the LastName entity attribute.</summary>
    public const string LastNameField = "LastName";
    /// <summary>Identifies the Notes entity attribute.</summary>
    public const string NotesField = "Notes";
    /// <summary>Identifies the Photo entity attribute.</summary>
    public const string PhotoField = "Photo";
    /// <summary>Identifies the PhotoPath entity attribute.</summary>
    public const string PhotoPathField = "PhotoPath";
    /// <summary>Identifies the PostalCode entity attribute.</summary>
    public const string PostalCodeField = "PostalCode";
    /// <summary>Identifies the Region entity attribute.</summary>
    public const string RegionField = "Region";
    /// <summary>Identifies the Title entity attribute.</summary>
    public const string TitleField = "Title";
    /// <summary>Identifies the TitleOfCourtesy entity attribute.</summary>
    public const string TitleOfCourtesyField = "TitleOfCourtesy";
    /// <summary>Identifies the ReportsToId entity attribute.</summary>
    public const string ReportsToIdField = "ReportsToId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("ReportsTo")]
    private readonly EntityCollection<Employee> _employees = new EntityCollection<Employee>();
    [ReverseAssociation("Employee")]
    private readonly EntityCollection<Order> _orders = new EntityCollection<Order>();
    [ReverseAssociation("Employees")]
    private readonly EntityHolder<Employee> _reportsTo = new EntityHolder<Employee>();


    #endregion
    
    #region Properties

    public EntityCollection<Employee> Employees
    {
      get { return Get(_employees); }
    }

    public EntityCollection<Order> Orders
    {
      get { return Get(_orders); }
    }

    public Employee ReportsTo
    {
      get { return Get(_reportsTo); }
      set { Set(_reportsTo, value); }
    }


    public string Address
    {
      get { return Get(ref _address, "Address"); }
      set { Set(ref _address, value, "Address"); }
    }

    public System.Nullable<System.DateTime> BirthDate
    {
      get { return Get(ref _birthDate, "BirthDate"); }
      set { Set(ref _birthDate, value, "BirthDate"); }
    }

    public string City
    {
      get { return Get(ref _city, "City"); }
      set { Set(ref _city, value, "City"); }
    }

    public string Country
    {
      get { return Get(ref _country, "Country"); }
      set { Set(ref _country, value, "Country"); }
    }

    public string Extension
    {
      get { return Get(ref _extension, "Extension"); }
      set { Set(ref _extension, value, "Extension"); }
    }

    public string FirstName
    {
      get { return Get(ref _firstName, "FirstName"); }
      set { Set(ref _firstName, value, "FirstName"); }
    }

    public System.Nullable<System.DateTime> HireDate
    {
      get { return Get(ref _hireDate, "HireDate"); }
      set { Set(ref _hireDate, value, "HireDate"); }
    }

    public string HomePhone
    {
      get { return Get(ref _homePhone, "HomePhone"); }
      set { Set(ref _homePhone, value, "HomePhone"); }
    }

    public string LastName
    {
      get { return Get(ref _lastName, "LastName"); }
      set { Set(ref _lastName, value, "LastName"); }
    }

    public string Notes
    {
      get { return Get(ref _notes, "Notes"); }
      set { Set(ref _notes, value, "Notes"); }
    }

    public byte[] Photo
    {
      get { return Get(ref _photo, "Photo"); }
      set { Set(ref _photo, value, "Photo"); }
    }

    public string PhotoPath
    {
      get { return Get(ref _photoPath, "PhotoPath"); }
      set { Set(ref _photoPath, value, "PhotoPath"); }
    }

    public string PostalCode
    {
      get { return Get(ref _postalCode, "PostalCode"); }
      set { Set(ref _postalCode, value, "PostalCode"); }
    }

    public string Region
    {
      get { return Get(ref _region, "Region"); }
      set { Set(ref _region, value, "Region"); }
    }

    public string Title
    {
      get { return Get(ref _title, "Title"); }
      set { Set(ref _title, value, "Title"); }
    }

    public string TitleOfCourtesy
    {
      get { return Get(ref _titleOfCourtesy, "TitleOfCourtesy"); }
      set { Set(ref _titleOfCourtesy, value, "TitleOfCourtesy"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="ReportsTo" /> property.</summary>
    public System.Nullable<int> ReportsToId
    {
      get { return Get(ref _reportsToId, "ReportsToId"); }
      set { Set(ref _reportsToId, value, "ReportsToId"); }
    }

    #endregion
  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Order Details", IdColumnName="OrderID")]
  [System.ComponentModel.DataObject]
  public partial class OrderDetail : Entity<int>
  {
    #region Fields
  
    private float _discount;
    private short _quantity;
    private decimal _unitPrice;
    private int _orderId;
    private int _productId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Discount entity attribute.</summary>
    public const string DiscountField = "Discount";
    /// <summary>Identifies the Quantity entity attribute.</summary>
    public const string QuantityField = "Quantity";
    /// <summary>Identifies the UnitPrice entity attribute.</summary>
    public const string UnitPriceField = "UnitPrice";
    /// <summary>Identifies the OrderId entity attribute.</summary>
    public const string OrderIdField = "OrderId";
    /// <summary>Identifies the ProductId entity attribute.</summary>
    public const string ProductIdField = "ProductId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("OrderDetails")]
    private readonly EntityHolder<Order> _order = new EntityHolder<Order>();
    [ReverseAssociation("OrderDetails")]
    private readonly EntityHolder<Product> _product = new EntityHolder<Product>();


    #endregion
    
    #region Properties

    public Order Order
    {
      get { return Get(_order); }
      set { Set(_order, value); }
    }

    public Product Product
    {
      get { return Get(_product); }
      set { Set(_product, value); }
    }


    public float Discount
    {
      get { return Get(ref _discount, "Discount"); }
      set { Set(ref _discount, value, "Discount"); }
    }

    public short Quantity
    {
      get { return Get(ref _quantity, "Quantity"); }
      set { Set(ref _quantity, value, "Quantity"); }
    }

    public decimal UnitPrice
    {
      get { return Get(ref _unitPrice, "UnitPrice"); }
      set { Set(ref _unitPrice, value, "UnitPrice"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Order" /> property.</summary>
    public int OrderId
    {
      get { return Get(ref _orderId, "OrderId"); }
      set { Set(ref _orderId, value, "OrderId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Product" /> property.</summary>
    public int ProductId
    {
      get { return Get(ref _productId, "ProductId"); }
      set { Set(ref _productId, value, "ProductId"); }
    }

    #endregion
  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Orders", IdColumnName="OrderID")]
  [System.ComponentModel.DataObject]
  public partial class Order : Entity<int>
  {
    #region Fields
  
    private decimal _freight;
    private System.Nullable<System.DateTime> _orderDate;
    private System.Nullable<System.DateTime> _requiredDate;
    [ValidateLength(0, 60)]
    private string _shipAddress;
    [ValidateLength(0, 15)]
    private string _shipCity;
    [ValidateLength(0, 15)]
    private string _shipCountry;
    [ValidateLength(0, 40)]
    private string _shipName;
    private System.Nullable<System.DateTime> _shippedDate;
    [ValidateLength(0, 10)]
    private string _shipPostalCode;
    [ValidateLength(0, 15)]
    private string _shipRegion;
    private string _customerId;
    private System.Nullable<int> _employeeId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Freight entity attribute.</summary>
    public const string FreightField = "Freight";
    /// <summary>Identifies the OrderDate entity attribute.</summary>
    public const string OrderDateField = "OrderDate";
    /// <summary>Identifies the RequiredDate entity attribute.</summary>
    public const string RequiredDateField = "RequiredDate";
    /// <summary>Identifies the ShipAddress entity attribute.</summary>
    public const string ShipAddressField = "ShipAddress";
    /// <summary>Identifies the ShipCity entity attribute.</summary>
    public const string ShipCityField = "ShipCity";
    /// <summary>Identifies the ShipCountry entity attribute.</summary>
    public const string ShipCountryField = "ShipCountry";
    /// <summary>Identifies the ShipName entity attribute.</summary>
    public const string ShipNameField = "ShipName";
    /// <summary>Identifies the ShippedDate entity attribute.</summary>
    public const string ShippedDateField = "ShippedDate";
    /// <summary>Identifies the ShipPostalCode entity attribute.</summary>
    public const string ShipPostalCodeField = "ShipPostalCode";
    /// <summary>Identifies the ShipRegion entity attribute.</summary>
    public const string ShipRegionField = "ShipRegion";
    /// <summary>Identifies the CustomerId entity attribute.</summary>
    public const string CustomerIdField = "CustomerId";
    /// <summary>Identifies the EmployeeId entity attribute.</summary>
    public const string EmployeeIdField = "EmployeeId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Order")]
    private readonly EntityCollection<OrderDetail> _orderDetails = new EntityCollection<OrderDetail>();
    [ReverseAssociation("Orders")]
    private readonly EntityHolder<Customer> _customer = new EntityHolder<Customer>();
    [ReverseAssociation("Orders")]
    private readonly EntityHolder<Employee> _employee = new EntityHolder<Employee>();


    #endregion
    
    #region Properties

    public EntityCollection<OrderDetail> OrderDetails
    {
      get { return Get(_orderDetails); }
    }

    public Customer Customer
    {
      get { return Get(_customer); }
      set { Set(_customer, value); }
    }

    public Employee Employee
    {
      get { return Get(_employee); }
      set { Set(_employee, value); }
    }


    public decimal Freight
    {
      get { return Get(ref _freight, "Freight"); }
      set { Set(ref _freight, value, "Freight"); }
    }

    public System.Nullable<System.DateTime> OrderDate
    {
      get { return Get(ref _orderDate, "OrderDate"); }
      set { Set(ref _orderDate, value, "OrderDate"); }
    }

    public System.Nullable<System.DateTime> RequiredDate
    {
      get { return Get(ref _requiredDate, "RequiredDate"); }
      set { Set(ref _requiredDate, value, "RequiredDate"); }
    }

    public string ShipAddress
    {
      get { return Get(ref _shipAddress, "ShipAddress"); }
      set { Set(ref _shipAddress, value, "ShipAddress"); }
    }

    public string ShipCity
    {
      get { return Get(ref _shipCity, "ShipCity"); }
      set { Set(ref _shipCity, value, "ShipCity"); }
    }

    public string ShipCountry
    {
      get { return Get(ref _shipCountry, "ShipCountry"); }
      set { Set(ref _shipCountry, value, "ShipCountry"); }
    }

    public string ShipName
    {
      get { return Get(ref _shipName, "ShipName"); }
      set { Set(ref _shipName, value, "ShipName"); }
    }

    public System.Nullable<System.DateTime> ShippedDate
    {
      get { return Get(ref _shippedDate, "ShippedDate"); }
      set { Set(ref _shippedDate, value, "ShippedDate"); }
    }

    public string ShipPostalCode
    {
      get { return Get(ref _shipPostalCode, "ShipPostalCode"); }
      set { Set(ref _shipPostalCode, value, "ShipPostalCode"); }
    }

    public string ShipRegion
    {
      get { return Get(ref _shipRegion, "ShipRegion"); }
      set { Set(ref _shipRegion, value, "ShipRegion"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Customer" /> property.</summary>
    public string CustomerId
    {
      get { return Get(ref _customerId, "CustomerId"); }
      set { Set(ref _customerId, value, "CustomerId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Employee" /> property.</summary>
    public System.Nullable<int> EmployeeId
    {
      get { return Get(ref _employeeId, "EmployeeId"); }
      set { Set(ref _employeeId, value, "EmployeeId"); }
    }

    #endregion
  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Products", IdColumnName="ProductID")]
  [System.ComponentModel.DataObject]
  public partial class Product : Entity<int>
  {
    #region Fields
  
    private bool _discontinued;
    [ValidatePresence]
    [ValidateLength(0, 40)]
    private string _productName;
    [ValidateLength(0, 20)]
    private string _quantityPerUnit;
    private System.Nullable<short> _reorderLevel;
    private System.Nullable<decimal> _unitPrice;
    private System.Nullable<short> _unitsInStock;
    private System.Nullable<short> _unitsOnOrder;
    private System.Nullable<int> _categoryId;
    private System.Nullable<int> _supplierId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Discontinued entity attribute.</summary>
    public const string DiscontinuedField = "Discontinued";
    /// <summary>Identifies the ProductName entity attribute.</summary>
    public const string ProductNameField = "ProductName";
    /// <summary>Identifies the QuantityPerUnit entity attribute.</summary>
    public const string QuantityPerUnitField = "QuantityPerUnit";
    /// <summary>Identifies the ReorderLevel entity attribute.</summary>
    public const string ReorderLevelField = "ReorderLevel";
    /// <summary>Identifies the UnitPrice entity attribute.</summary>
    public const string UnitPriceField = "UnitPrice";
    /// <summary>Identifies the UnitsInStock entity attribute.</summary>
    public const string UnitsInStockField = "UnitsInStock";
    /// <summary>Identifies the UnitsOnOrder entity attribute.</summary>
    public const string UnitsOnOrderField = "UnitsOnOrder";
    /// <summary>Identifies the CategoryId entity attribute.</summary>
    public const string CategoryIdField = "CategoryId";
    /// <summary>Identifies the SupplierId entity attribute.</summary>
    public const string SupplierIdField = "SupplierId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Product")]
    private readonly EntityCollection<OrderDetail> _orderDetails = new EntityCollection<OrderDetail>();
    [ReverseAssociation("Products")]
    private readonly EntityHolder<Category> _category = new EntityHolder<Category>();
    [ReverseAssociation("Products")]
    private readonly EntityHolder<Supplier> _supplier = new EntityHolder<Supplier>();


    #endregion
    
    #region Properties

    public EntityCollection<OrderDetail> OrderDetails
    {
      get { return Get(_orderDetails); }
    }

    public Category Category
    {
      get { return Get(_category); }
      set { Set(_category, value); }
    }

    public Supplier Supplier
    {
      get { return Get(_supplier); }
      set { Set(_supplier, value); }
    }


    public bool Discontinued
    {
      get { return Get(ref _discontinued, "Discontinued"); }
      set { Set(ref _discontinued, value, "Discontinued"); }
    }

    public string ProductName
    {
      get { return Get(ref _productName, "ProductName"); }
      set { Set(ref _productName, value, "ProductName"); }
    }

    public string QuantityPerUnit
    {
      get { return Get(ref _quantityPerUnit, "QuantityPerUnit"); }
      set { Set(ref _quantityPerUnit, value, "QuantityPerUnit"); }
    }

    public System.Nullable<short> ReorderLevel
    {
      get { return Get(ref _reorderLevel, "ReorderLevel"); }
      set { Set(ref _reorderLevel, value, "ReorderLevel"); }
    }

    public System.Nullable<decimal> UnitPrice
    {
      get { return Get(ref _unitPrice, "UnitPrice"); }
      set { Set(ref _unitPrice, value, "UnitPrice"); }
    }

    public System.Nullable<short> UnitsInStock
    {
      get { return Get(ref _unitsInStock, "UnitsInStock"); }
      set { Set(ref _unitsInStock, value, "UnitsInStock"); }
    }

    public System.Nullable<short> UnitsOnOrder
    {
      get { return Get(ref _unitsOnOrder, "UnitsOnOrder"); }
      set { Set(ref _unitsOnOrder, value, "UnitsOnOrder"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Category" /> property.</summary>
    public System.Nullable<int> CategoryId
    {
      get { return Get(ref _categoryId, "CategoryId"); }
      set { Set(ref _categoryId, value, "CategoryId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Supplier" /> property.</summary>
    public System.Nullable<int> SupplierId
    {
      get { return Get(ref _supplierId, "SupplierId"); }
      set { Set(ref _supplierId, value, "SupplierId"); }
    }

    #endregion
  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Discriminator(Attribute="Discontinued", Value=true)]
  [System.ComponentModel.DataObject]
  public partial class DiscontinuedProduct : Product
  {
  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Suppliers", IdColumnName="SupplierID")]
  [System.ComponentModel.DataObject]
  public partial class Supplier : Entity<int>
  {
    #region Fields
  
    [ValidateLength(0, 60)]
    private string _address;
    [ValidateLength(0, 15)]
    private string _city;
    [ValidatePresence]
    [ValidateLength(0, 40)]
    private string _companyName;
    [ValidateLength(0, 30)]
    private string _contactName;
    [ValidateLength(0, 30)]
    private string _contactTitle;
    [ValidateLength(0, 15)]
    private string _country;
    [ValidateLength(0, 24)]
    private string _fax;
    [ValidateLength(0, 1073741823)]
    private string _homePage;
    [ValidateLength(0, 24)]
    private string _phone;
    [ValidateLength(0, 10)]
    private string _postalCode;
    [ValidateLength(0, 15)]
    private string _region;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Address entity attribute.</summary>
    public const string AddressField = "Address";
    /// <summary>Identifies the City entity attribute.</summary>
    public const string CityField = "City";
    /// <summary>Identifies the CompanyName entity attribute.</summary>
    public const string CompanyNameField = "CompanyName";
    /// <summary>Identifies the ContactName entity attribute.</summary>
    public const string ContactNameField = "ContactName";
    /// <summary>Identifies the ContactTitle entity attribute.</summary>
    public const string ContactTitleField = "ContactTitle";
    /// <summary>Identifies the Country entity attribute.</summary>
    public const string CountryField = "Country";
    /// <summary>Identifies the Fax entity attribute.</summary>
    public const string FaxField = "Fax";
    /// <summary>Identifies the HomePage entity attribute.</summary>
    public const string HomePageField = "HomePage";
    /// <summary>Identifies the Phone entity attribute.</summary>
    public const string PhoneField = "Phone";
    /// <summary>Identifies the PostalCode entity attribute.</summary>
    public const string PostalCodeField = "PostalCode";
    /// <summary>Identifies the Region entity attribute.</summary>
    public const string RegionField = "Region";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Supplier")]
    private readonly EntityCollection<Product> _products = new EntityCollection<Product>();


    #endregion
    
    #region Properties

    public EntityCollection<Product> Products
    {
      get { return Get(_products); }
    }


    public string Address
    {
      get { return Get(ref _address, "Address"); }
      set { Set(ref _address, value, "Address"); }
    }

    public string City
    {
      get { return Get(ref _city, "City"); }
      set { Set(ref _city, value, "City"); }
    }

    public string CompanyName
    {
      get { return Get(ref _companyName, "CompanyName"); }
      set { Set(ref _companyName, value, "CompanyName"); }
    }

    public string ContactName
    {
      get { return Get(ref _contactName, "ContactName"); }
      set { Set(ref _contactName, value, "ContactName"); }
    }

    public string ContactTitle
    {
      get { return Get(ref _contactTitle, "ContactTitle"); }
      set { Set(ref _contactTitle, value, "ContactTitle"); }
    }

    public string Country
    {
      get { return Get(ref _country, "Country"); }
      set { Set(ref _country, value, "Country"); }
    }

    public string Fax
    {
      get { return Get(ref _fax, "Fax"); }
      set { Set(ref _fax, value, "Fax"); }
    }

    public string HomePage
    {
      get { return Get(ref _homePage, "HomePage"); }
      set { Set(ref _homePage, value, "HomePage"); }
    }

    public string Phone
    {
      get { return Get(ref _phone, "Phone"); }
      set { Set(ref _phone, value, "Phone"); }
    }

    public string PostalCode
    {
      get { return Get(ref _postalCode, "PostalCode"); }
      set { Set(ref _postalCode, value, "PostalCode"); }
    }

    public string Region
    {
      get { return Get(ref _region, "Region"); }
      set { Set(ref _region, value, "Region"); }
    }

    #endregion
  }


  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class NorthwindUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public NorthwindUnitOfWork()
    {
    }
    

    public System.Linq.IQueryable<Category> Categories
    {
      get { return this.Query<Category>(); }
    }
    
    public System.Linq.IQueryable<Customer> Customers
    {
      get { return this.Query<Customer>(); }
    }
    
    public System.Linq.IQueryable<Employee> Employees
    {
      get { return this.Query<Employee>(); }
    }
    
    public System.Linq.IQueryable<OrderDetail> OrderDetails
    {
      get { return this.Query<OrderDetail>(); }
    }
    
    public System.Linq.IQueryable<Order> Orders
    {
      get { return this.Query<Order>(); }
    }
    
    public System.Linq.IQueryable<Product> Products
    {
      get { return this.Query<Product>(); }
    }
    
    public System.Linq.IQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get { return this.Query<DiscontinuedProduct>(); }
    }
    
    public System.Linq.IQueryable<Supplier> Suppliers
    {
      get { return this.Query<Supplier>(); }
    }
    
  }

}
