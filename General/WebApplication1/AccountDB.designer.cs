﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Account")]
	public partial class AccountDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void Insertt_Account_100(t_Account_100 instance);
    partial void Updatet_Account_100(t_Account_100 instance);
    partial void Deletet_Account_100(t_Account_100 instance);
    partial void Insertt_Orders_100(t_Orders_100 instance);
    partial void Updatet_Orders_100(t_Orders_100 instance);
    partial void Deletet_Orders_100(t_Orders_100 instance);
    #endregion
		
		public AccountDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["AccountConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AccountDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AccountDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AccountDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AccountDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<t_Account_100> t_Account_100
		{
			get
			{
				return this.GetTable<t_Account_100>();
			}
		}
		
		public System.Data.Linq.Table<t_Account_Log> t_Account_Log
		{
			get
			{
				return this.GetTable<t_Account_Log>();
			}
		}
		
		public System.Data.Linq.Table<t_Orders_100> t_Orders_100
		{
			get
			{
				return this.GetTable<t_Orders_100>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_Account_100")]
	public partial class t_Account_100 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ItemID;
		
		private int _UserID;
		
		private long _Point;
		
		private long _Score;
		
		private long _svPoint;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnItemIDChanging(long value);
    partial void OnItemIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnPointChanging(long value);
    partial void OnPointChanged();
    partial void OnScoreChanging(long value);
    partial void OnScoreChanged();
    partial void OnsvPointChanging(long value);
    partial void OnsvPointChanged();
    #endregion
		
		public t_Account_100()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemID", AutoSync=AutoSync.Always, DbType="BigInt NOT NULL IDENTITY", IsDbGenerated=true)]
		public long ItemID
		{
			get
			{
				return this._ItemID;
			}
			set
			{
				if ((this._ItemID != value))
				{
					this.OnItemIDChanging(value);
					this.SendPropertyChanging();
					this._ItemID = value;
					this.SendPropertyChanged("ItemID");
					this.OnItemIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Point", DbType="BigInt NOT NULL")]
		public long Point
		{
			get
			{
				return this._Point;
			}
			set
			{
				if ((this._Point != value))
				{
					this.OnPointChanging(value);
					this.SendPropertyChanging();
					this._Point = value;
					this.SendPropertyChanged("Point");
					this.OnPointChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Score", DbType="BigInt NOT NULL")]
		public long Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				if ((this._Score != value))
				{
					this.OnScoreChanging(value);
					this.SendPropertyChanging();
					this._Score = value;
					this.SendPropertyChanged("Score");
					this.OnScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_svPoint", DbType="BigInt NOT NULL")]
		public long svPoint
		{
			get
			{
				return this._svPoint;
			}
			set
			{
				if ((this._svPoint != value))
				{
					this.OnsvPointChanging(value);
					this.SendPropertyChanging();
					this._svPoint = value;
					this.SendPropertyChanged("svPoint");
					this.OnsvPointChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_Account_Log")]
	public partial class t_Account_Log
	{
		
		private int _ItemID;
		
		private long _UserID;
		
		private long _Point;
		
		private string _Caption;
		
		private System.DateTime _CreateDate;
		
		public t_Account_Log()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ItemID
		{
			get
			{
				return this._ItemID;
			}
			set
			{
				if ((this._ItemID != value))
				{
					this._ItemID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this._UserID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Point", DbType="BigInt NOT NULL")]
		public long Point
		{
			get
			{
				return this._Point;
			}
			set
			{
				if ((this._Point != value))
				{
					this._Point = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caption", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Caption
		{
			get
			{
				return this._Caption;
			}
			set
			{
				if ((this._Caption != value))
				{
					this._Caption = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this._CreateDate = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_Orders_100")]
	public partial class t_Orders_100 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _orderid;
		
		private int _userId;
		
		private int _payType;
		
		private int _payAmount;
		
		private int _payAmountPublic;
		
		private int _payMoney;
		
		private string _payTypeName;
		
		private int _expireDays;
		
		private int _status;
		
		private System.DateTime _createTime;
		
		private System.Nullable<System.DateTime> _payTime;
		
		private string _Bank;
		
		private int _roomid;
		
		private int _stageid;
		
		private int _destuserid;
		
		private int _cardid;
		
		private int _number;
		
		private int _parterid;
		
		private int _cardtype;
		
		private System.Nullable<int> _sourceid;
		
		private System.Nullable<int> _moneymum;
		
		private System.Nullable<int> _moneytype;
		
		private string _qq;
		
		private string _phoneNo;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnorderidChanging(long value);
    partial void OnorderidChanged();
    partial void OnuserIdChanging(int value);
    partial void OnuserIdChanged();
    partial void OnpayTypeChanging(int value);
    partial void OnpayTypeChanged();
    partial void OnpayAmountChanging(int value);
    partial void OnpayAmountChanged();
    partial void OnpayAmountPublicChanging(int value);
    partial void OnpayAmountPublicChanged();
    partial void OnpayMoneyChanging(int value);
    partial void OnpayMoneyChanged();
    partial void OnpayTypeNameChanging(string value);
    partial void OnpayTypeNameChanged();
    partial void OnexpireDaysChanging(int value);
    partial void OnexpireDaysChanged();
    partial void OnstatusChanging(int value);
    partial void OnstatusChanged();
    partial void OncreateTimeChanging(System.DateTime value);
    partial void OncreateTimeChanged();
    partial void OnpayTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnpayTimeChanged();
    partial void OnBankChanging(string value);
    partial void OnBankChanged();
    partial void OnroomidChanging(int value);
    partial void OnroomidChanged();
    partial void OnstageidChanging(int value);
    partial void OnstageidChanged();
    partial void OndestuseridChanging(int value);
    partial void OndestuseridChanged();
    partial void OncardidChanging(int value);
    partial void OncardidChanged();
    partial void OnnumberChanging(int value);
    partial void OnnumberChanged();
    partial void OnparteridChanging(int value);
    partial void OnparteridChanged();
    partial void OncardtypeChanging(int value);
    partial void OncardtypeChanged();
    partial void OnsourceidChanging(System.Nullable<int> value);
    partial void OnsourceidChanged();
    partial void OnmoneymumChanging(System.Nullable<int> value);
    partial void OnmoneymumChanged();
    partial void OnmoneytypeChanging(System.Nullable<int> value);
    partial void OnmoneytypeChanged();
    partial void OnqqChanging(string value);
    partial void OnqqChanged();
    partial void OnphoneNoChanging(string value);
    partial void OnphoneNoChanged();
    #endregion
		
		public t_Orders_100()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_orderid", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long orderid
		{
			get
			{
				return this._orderid;
			}
			set
			{
				if ((this._orderid != value))
				{
					this.OnorderidChanging(value);
					this.SendPropertyChanging();
					this._orderid = value;
					this.SendPropertyChanged("orderid");
					this.OnorderidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userId", DbType="Int NOT NULL")]
		public int userId
		{
			get
			{
				return this._userId;
			}
			set
			{
				if ((this._userId != value))
				{
					this.OnuserIdChanging(value);
					this.SendPropertyChanging();
					this._userId = value;
					this.SendPropertyChanged("userId");
					this.OnuserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_payType", DbType="Int NOT NULL")]
		public int payType
		{
			get
			{
				return this._payType;
			}
			set
			{
				if ((this._payType != value))
				{
					this.OnpayTypeChanging(value);
					this.SendPropertyChanging();
					this._payType = value;
					this.SendPropertyChanged("payType");
					this.OnpayTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_payAmount", DbType="Int NOT NULL")]
		public int payAmount
		{
			get
			{
				return this._payAmount;
			}
			set
			{
				if ((this._payAmount != value))
				{
					this.OnpayAmountChanging(value);
					this.SendPropertyChanging();
					this._payAmount = value;
					this.SendPropertyChanged("payAmount");
					this.OnpayAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_payAmountPublic", DbType="Int NOT NULL")]
		public int payAmountPublic
		{
			get
			{
				return this._payAmountPublic;
			}
			set
			{
				if ((this._payAmountPublic != value))
				{
					this.OnpayAmountPublicChanging(value);
					this.SendPropertyChanging();
					this._payAmountPublic = value;
					this.SendPropertyChanged("payAmountPublic");
					this.OnpayAmountPublicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_payMoney", DbType="Int NOT NULL")]
		public int payMoney
		{
			get
			{
				return this._payMoney;
			}
			set
			{
				if ((this._payMoney != value))
				{
					this.OnpayMoneyChanging(value);
					this.SendPropertyChanging();
					this._payMoney = value;
					this.SendPropertyChanged("payMoney");
					this.OnpayMoneyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_payTypeName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string payTypeName
		{
			get
			{
				return this._payTypeName;
			}
			set
			{
				if ((this._payTypeName != value))
				{
					this.OnpayTypeNameChanging(value);
					this.SendPropertyChanging();
					this._payTypeName = value;
					this.SendPropertyChanged("payTypeName");
					this.OnpayTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_expireDays", DbType="Int NOT NULL")]
		public int expireDays
		{
			get
			{
				return this._expireDays;
			}
			set
			{
				if ((this._expireDays != value))
				{
					this.OnexpireDaysChanging(value);
					this.SendPropertyChanging();
					this._expireDays = value;
					this.SendPropertyChanged("expireDays");
					this.OnexpireDaysChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Int NOT NULL")]
		public int status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createTime", DbType="DateTime NOT NULL")]
		public System.DateTime createTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				if ((this._createTime != value))
				{
					this.OncreateTimeChanging(value);
					this.SendPropertyChanging();
					this._createTime = value;
					this.SendPropertyChanged("createTime");
					this.OncreateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_payTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> payTime
		{
			get
			{
				return this._payTime;
			}
			set
			{
				if ((this._payTime != value))
				{
					this.OnpayTimeChanging(value);
					this.SendPropertyChanging();
					this._payTime = value;
					this.SendPropertyChanged("payTime");
					this.OnpayTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bank", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Bank
		{
			get
			{
				return this._Bank;
			}
			set
			{
				if ((this._Bank != value))
				{
					this.OnBankChanging(value);
					this.SendPropertyChanging();
					this._Bank = value;
					this.SendPropertyChanged("Bank");
					this.OnBankChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_roomid", DbType="Int NOT NULL")]
		public int roomid
		{
			get
			{
				return this._roomid;
			}
			set
			{
				if ((this._roomid != value))
				{
					this.OnroomidChanging(value);
					this.SendPropertyChanging();
					this._roomid = value;
					this.SendPropertyChanged("roomid");
					this.OnroomidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stageid", DbType="Int NOT NULL")]
		public int stageid
		{
			get
			{
				return this._stageid;
			}
			set
			{
				if ((this._stageid != value))
				{
					this.OnstageidChanging(value);
					this.SendPropertyChanging();
					this._stageid = value;
					this.SendPropertyChanged("stageid");
					this.OnstageidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_destuserid", DbType="Int NOT NULL")]
		public int destuserid
		{
			get
			{
				return this._destuserid;
			}
			set
			{
				if ((this._destuserid != value))
				{
					this.OndestuseridChanging(value);
					this.SendPropertyChanging();
					this._destuserid = value;
					this.SendPropertyChanged("destuserid");
					this.OndestuseridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cardid", DbType="Int NOT NULL")]
		public int cardid
		{
			get
			{
				return this._cardid;
			}
			set
			{
				if ((this._cardid != value))
				{
					this.OncardidChanging(value);
					this.SendPropertyChanging();
					this._cardid = value;
					this.SendPropertyChanged("cardid");
					this.OncardidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_number", DbType="Int NOT NULL")]
		public int number
		{
			get
			{
				return this._number;
			}
			set
			{
				if ((this._number != value))
				{
					this.OnnumberChanging(value);
					this.SendPropertyChanging();
					this._number = value;
					this.SendPropertyChanged("number");
					this.OnnumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parterid", DbType="Int NOT NULL")]
		public int parterid
		{
			get
			{
				return this._parterid;
			}
			set
			{
				if ((this._parterid != value))
				{
					this.OnparteridChanging(value);
					this.SendPropertyChanging();
					this._parterid = value;
					this.SendPropertyChanged("parterid");
					this.OnparteridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cardtype", DbType="Int NOT NULL")]
		public int cardtype
		{
			get
			{
				return this._cardtype;
			}
			set
			{
				if ((this._cardtype != value))
				{
					this.OncardtypeChanging(value);
					this.SendPropertyChanging();
					this._cardtype = value;
					this.SendPropertyChanged("cardtype");
					this.OncardtypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sourceid", DbType="Int")]
		public System.Nullable<int> sourceid
		{
			get
			{
				return this._sourceid;
			}
			set
			{
				if ((this._sourceid != value))
				{
					this.OnsourceidChanging(value);
					this.SendPropertyChanging();
					this._sourceid = value;
					this.SendPropertyChanged("sourceid");
					this.OnsourceidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_moneymum", DbType="Int")]
		public System.Nullable<int> moneymum
		{
			get
			{
				return this._moneymum;
			}
			set
			{
				if ((this._moneymum != value))
				{
					this.OnmoneymumChanging(value);
					this.SendPropertyChanging();
					this._moneymum = value;
					this.SendPropertyChanged("moneymum");
					this.OnmoneymumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_moneytype", DbType="Int")]
		public System.Nullable<int> moneytype
		{
			get
			{
				return this._moneytype;
			}
			set
			{
				if ((this._moneytype != value))
				{
					this.OnmoneytypeChanging(value);
					this.SendPropertyChanging();
					this._moneytype = value;
					this.SendPropertyChanged("moneytype");
					this.OnmoneytypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_qq", DbType="VarChar(50)")]
		public string qq
		{
			get
			{
				return this._qq;
			}
			set
			{
				if ((this._qq != value))
				{
					this.OnqqChanging(value);
					this.SendPropertyChanging();
					this._qq = value;
					this.SendPropertyChanged("qq");
					this.OnqqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phoneNo", DbType="VarChar(50)")]
		public string phoneNo
		{
			get
			{
				return this._phoneNo;
			}
			set
			{
				if ((this._phoneNo != value))
				{
					this.OnphoneNoChanging(value);
					this.SendPropertyChanging();
					this._phoneNo = value;
					this.SendPropertyChanged("phoneNo");
					this.OnphoneNoChanged();
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
