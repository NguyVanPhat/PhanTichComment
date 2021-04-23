﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhanTichComment.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PhanTichComment")]
	public partial class KetQuaPhanTichDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKetQuaPhanTich(KetQuaPhanTich instance);
    partial void UpdateKetQuaPhanTich(KetQuaPhanTich instance);
    partial void DeleteKetQuaPhanTich(KetQuaPhanTich instance);
    #endregion
		
		public KetQuaPhanTichDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["PhanTichCommentConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public KetQuaPhanTichDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public KetQuaPhanTichDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public KetQuaPhanTichDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public KetQuaPhanTichDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<KetQuaPhanTich> KetQuaPhanTiches
		{
			get
			{
				return this.GetTable<KetQuaPhanTich>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KetQuaPhanTich")]
	public partial class KetQuaPhanTich : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _NoiDung;
		
		private string _KetQua;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNoiDungChanging(string value);
    partial void OnNoiDungChanged();
    partial void OnKetQuaChanging(string value);
    partial void OnKetQuaChanged();
    #endregion
		
		public KetQuaPhanTich()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoiDung", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string NoiDung
		{
			get
			{
				return this._NoiDung;
			}
			set
			{
				if ((this._NoiDung != value))
				{
					this.OnNoiDungChanging(value);
					this.SendPropertyChanging();
					this._NoiDung = value;
					this.SendPropertyChanged("NoiDung");
					this.OnNoiDungChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KetQua", DbType="NVarChar(100)")]
		public string KetQua
		{
			get
			{
				return this._KetQua;
			}
			set
			{
				if ((this._KetQua != value))
				{
					this.OnKetQuaChanging(value);
					this.SendPropertyChanging();
					this._KetQua = value;
					this.SendPropertyChanged("KetQua");
					this.OnKetQuaChanged();
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
}
#pragma warning restore 1591