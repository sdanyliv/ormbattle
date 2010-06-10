﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4016
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Linq2SqlModel
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="PerformanceTest")]
	public partial class PerformanceTestDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSimplest(Simplest instance);
    partial void UpdateSimplest(Simplest instance);
    partial void DeleteSimplest(Simplest instance);
    #endregion
		
		public PerformanceTestDataContext() : 
				base(global::Linq2SqlModel.Properties.Settings.Default.PerformanceTestConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PerformanceTestDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PerformanceTestDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PerformanceTestDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PerformanceTestDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Simplest> Simplests
		{
			get
			{
				return this.GetTable<Simplest>();
			}
		}
		
		public System.Data.Linq.Table<KeyTable> KeyTables
		{
			get
			{
				return this.GetTable<KeyTable>();
			}
		}
	}
	
	[Table(Name="dbo.Simplests")]
	public partial class Simplest : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private long _Value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnValueChanging(long value);
    partial void OnValueChanged();
    #endregion
		
		public Simplest()
		{
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_Value", DbType="BigInt NOT NULL")]
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.KeyTable")]
	public partial class KeyTable
	{
		
		private int _NextId;
		
		public KeyTable()
		{
		}
		
		[Column(Storage="_NextId", DbType="Int NOT NULL")]
		public int NextId
		{
			get
			{
				return this._NextId;
			}
			set
			{
				if ((this._NextId != value))
				{
					this._NextId = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
