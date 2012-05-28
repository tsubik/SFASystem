/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Order object for NHibernate mapped table 'Order'.
	/// </summary>
	[Serializable]
	public class Order
	{
		#region Member Variables
		protected Guid orderid;
		protected CustomerFacility customerfacility;
		protected Territory territory;
		protected Employee employee;
		protected Dictionary orderstatus;
		protected string identifier;
		protected DateTime orderdate;
		protected DateTime? datemodified;
		protected decimal subtotal;
		protected decimal taxamount;
		protected decimal total;
		protected string comment;
		protected IList<OrderLine> orderlines;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public Order() {
            //this.orderid = Guid.NewGuid() ;
            //this.customerfacility = null ;
            //this.territory = null;
            //this.employee = null;
            //this.orderstatus = null;
            //this.identifier = string.Empty;
            //this.orderdate = DateTime.MinValue;
            //this.datemodified = DateTime.MinValue;
            //this.subtotal = 0;
            //this.taxamount = 0;
            //this.total = 0;
            //this.comment = string.Empty;
        }
					
		public Order(Guid orderid, CustomerFacility customerfacility, Territory territory, Employee employee, Dictionary orderstatus, string identifier, DateTime orderdate, DateTime? datemodified, decimal subtotal, decimal taxamount, decimal total, string comment) 
		{
			this.orderid= orderid;
			this.customerfacility= customerfacility;
			this.territory= territory;
			this.employee= employee;
			this.orderstatus= orderstatus;
			this.identifier= identifier;
			this.orderdate= orderdate;
			this.datemodified= datemodified;
			this.subtotal= subtotal;
			this.taxamount= taxamount;
			this.total= total;
			this.comment= comment;
		}

		public Order(Guid orderid, CustomerFacility customerfacility, Territory territory, Employee employee, Dictionary orderstatus, string identifier, DateTime orderdate, decimal subtotal, decimal taxamount, decimal total)
		{
			this.orderid= orderid;
			this.customerfacility= customerfacility;
			this.territory= territory;
			this.employee= employee;
			this.orderstatus= orderstatus;
			this.identifier= identifier;
			this.orderdate= orderdate;
			this.subtotal= subtotal;
			this.taxamount= taxamount;
			this.total= total;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid Orderid
		{
			get { return orderid; }
			set {orderid= value; }
		}
		public  virtual CustomerFacility CustomerFacility
		{
			get { return customerfacility; }
			set {customerfacility= value; }
		}
		public  virtual Territory Territory
		{
			get { return territory; }
			set {territory= value; }
		}
		public  virtual Employee Employee
		{
			get { return employee; }
			set {employee= value; }
		}
		public  virtual Dictionary OrderStatus
		{
			get { return orderstatus; }
			set {orderstatus= value; }
		}
		public  virtual string Identifier
		{
			get { return identifier; }
			set {identifier= value; }
		}
		public  virtual DateTime OrderDate
		{
			get { return orderdate; }
			set {orderdate= value; }
		}
		public  virtual DateTime? DateModified
		{
			get { return datemodified; }
			set {datemodified= value; }
		}
		public  virtual decimal SubTotal
		{
			get { return subtotal; }
			set {subtotal= value; }
		}
		public  virtual decimal TaxAmount
		{
			get { return taxamount; }
			set {taxamount= value; }
		}
		public  virtual decimal Total
		{
			get { return total; }
			set {total= value; }
		}
		public  virtual string Comment
		{
			get { return comment; }
			set {comment= value; }
		}
		public  virtual IList<OrderLine> OrderLines
		{
			get { return orderlines; }
			set {orderlines= value; }
		}
        public virtual bool IsDeleted
        {
            get { return isdeleted; }
            set { isdeleted = value; }
        }
		#endregion
		
		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			Order castObj = (Order)obj;
			return ( castObj != null ) &&
			this.orderid == castObj.Orderid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * orderid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
