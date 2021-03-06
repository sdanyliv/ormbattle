#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;


namespace OrmBattle.TelerikModel.Northwind	
{
	public partial class Product
	{
		private int productID;
		public virtual int Id 
		{ 
		    get
		    {
		        return this.productID;
		    }
		    set
		    {
		        this.productID = value;
		    }
		}
		
		private string productName;
		public virtual string ProductName 
		{ 
		    get
		    {
		        return this.productName;
		    }
		    set
		    {
		        this.productName = value;
		    }
		}
		
		private int? supplierID;
		public virtual int? SupplierID 
		{ 
		    get
		    {
		        return this.supplierID;
		    }
		    set
		    {
		        this.supplierID = value;
		    }
		}
		
		private int? categoryID;
		public virtual int? CategoryID 
		{ 
		    get
		    {
		        return this.categoryID;
		    }
		    set
		    {
		        this.categoryID = value;
		    }
		}
		
		private string quantityPerUnit;
		public virtual string QuantityPerUnit 
		{ 
		    get
		    {
		        return this.quantityPerUnit;
		    }
		    set
		    {
		        this.quantityPerUnit = value;
		    }
		}
		
		private decimal? unitPrice;
		public virtual decimal? UnitPrice 
		{ 
		    get
		    {
		        return this.unitPrice;
		    }
		    set
		    {
		        this.unitPrice = value;
		    }
		}
		
		private short? unitsInStock;
		public virtual short? UnitsInStock 
		{ 
		    get
		    {
		        return this.unitsInStock;
		    }
		    set
		    {
		        this.unitsInStock = value;
		    }
		}
		
		private short? unitsOnOrder;
		public virtual short? UnitsOnOrder 
		{ 
		    get
		    {
		        return this.unitsOnOrder;
		    }
		    set
		    {
		        this.unitsOnOrder = value;
		    }
		}
		
		private short? reorderLevel;
		public virtual short? ReorderLevel 
		{ 
		    get
		    {
		        return this.reorderLevel;
		    }
		    set
		    {
		        this.reorderLevel = value;
		    }
		}
		
		private bool discontinued;
		public virtual bool Discontinued 
		{ 
		    get
		    {
		        return this.discontinued;
		    }
		    set
		    {
		        this.discontinued = value;
		    }
		}
		
		private Category category;
		public virtual Category Category 
		{ 
		    get
		    {
		        return this.category;
		    }
		    set
		    {
		        this.category = value;
		    }
		}
		
		private Supplier supplier;
		public virtual Supplier Supplier 
		{ 
		    get
		    {
		        return this.supplier;
		    }
		    set
		    {
		        this.supplier = value;
		    }
		}
		
		private IList<OrderDetail> orderDetails = new List<OrderDetail>();
		public virtual IList<OrderDetail> OrderDetails 
		{ 
		    get
		    {
		        return this.orderDetails;
		    }
		}
		
	}
}
