﻿#pragma warning disable 1591
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
using OrmBattle.TelerikModel.Northwind;
using Telerik.OpenAccess.Metadata;


namespace OrmBattle.TelerikModel.Northwind	
{	
	public partial class NorthwindContext : OpenAccessContext
	{
		private static string connectionStringName = "NorthwindContext";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
		
			
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntityDiagrams.rlinq");
	
		public NorthwindContext()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public NorthwindContext(string connection)
			:base(connection, backend, metadataSource)
		{ }
	
		public NorthwindContext(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public NorthwindContext(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public NorthwindContext(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Category> Categories 
		{
	    	get
	    	{
	        	return this.GetAll<Category>();
	    	}
		}
		
		public IQueryable<Customer> Customers 
		{
	    	get
	    	{
	        	return this.GetAll<Customer>();
	    	}
		}
		
		public IQueryable<Employee> Employees 
		{
	    	get
	    	{
	        	return this.GetAll<Employee>();
	    	}
		}
		
		public IQueryable<OrderDetail> OrderDetails 
		{
	    	get
	    	{
	        	return this.GetAll<OrderDetail>();
	    	}
		}
		
		public IQueryable<Order> Orders 
		{
	    	get
	    	{
	        	return this.GetAll<Order>();
	    	}
		}
		
		public IQueryable<Product> Products 
		{
	    	get
	    	{
	        	return this.GetAll<Product>();
	    	}
		}
		
		public IQueryable<Region> Regions 
		{
	    	get
	    	{
	        	return this.GetAll<Region>();
	    	}
		}
		
		public IQueryable<Shipper> Shippers 
		{
	    	get
	    	{
	        	return this.GetAll<Shipper>();
	    	}
		}
		
		public IQueryable<Supplier> Suppliers 
		{
	    	get
	    	{
	        	return this.GetAll<Supplier>();
	    	}
		}
		
		public IQueryable<Territory> Territories 
		{
	    	get
	    	{
	        	return this.GetAll<Territory>();
	    	}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "mssql";
			return backend;
		}
	}
}
#pragma warning restore 1591
