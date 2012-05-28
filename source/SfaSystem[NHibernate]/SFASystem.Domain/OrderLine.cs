/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// OrderLine object for NHibernate mapped table 'OrderLine'.
	/// </summary>
	[Serializable]
	public class OrderLine
	{
		#region Member Variables
		protected OrderLineId id;
		protected int quantity;
		protected decimal itemprice;
		protected decimal itempricediscount;
        protected decimal tax;
		protected decimal total;
		protected Order order;
		protected Product product;
		#endregion
		#region Constructors
			
		public OrderLine() {
            //this.id = null;
            //this.quantity = 0;
            //this.itemprice = 0;
            //this.itempricediscount = 0;
            //this.total = 0;
            //this.order = null;
            //this.product = null;
        }
					
		public OrderLine(OrderLineId id, int quantity, decimal itemprice, decimal itempricediscount, decimal total, Order order, Product product) 
		{
			this.id= id;
			this.quantity= quantity;
			this.itemprice= itemprice;
			this.itempricediscount= itempricediscount;
			this.total= total;
			this.order= order;
			this.product= product;
		}

		#endregion
		#region Public Properties
		public  virtual OrderLineId Id
		{
			get { return id; }
			set {id= value; }
		}
		public  virtual int Quantity
		{
			get { return quantity; }
			set {quantity= value; }
		}
		public  virtual decimal ItemPrice
		{
			get { return itemprice; }
			set {itemprice= value; }
		}
		public  virtual decimal ItemPriceDiscount
		{
			get { return itempricediscount; }
			set {itempricediscount= value; }
		}
        public virtual decimal Tax
        {
            get { return tax; }
            set { tax = value; }
        }
		public  virtual decimal Total
		{
			get { return total; }
			set {total= value; }
		}
		public  virtual Order Order
		{
			get { return id.Order; }
			//set {order= value; }
		}
		public  virtual Product Product
		{
			get { return id.Product; }
			//set {product= value; }
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
			OrderLine castObj = (OrderLine)obj;
			return ( castObj != null ) &&
			this.id.Equals( castObj.Id);
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * id.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
