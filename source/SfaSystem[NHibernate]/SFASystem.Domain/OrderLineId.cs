/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// OrderLineId object for NHibernate mapped table 'OrderLine'.
	/// </summary>
	[Serializable]
	public class OrderLineId
	{
		#region Member Variables
		protected Order order;
		protected Product product;
		#endregion
		#region Constructors
			
		public OrderLineId() {}
					
		public OrderLineId(Order order, Product product) 
		{
			this.order= order;
			this.product= product;
		}

		#endregion
		#region Public Properties
		public  virtual Order Order
		{
			get { return order; }
			set {order= value; }
		}
		public  virtual Product Product
		{
			get { return product; }
			set {product= value; }
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
			OrderLineId castObj = (OrderLineId)obj;
			return ( castObj != null ) &&
			this.order.Equals( castObj.Order) &&
			this.product.Equals( castObj.Product);
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * order.GetHashCode();
			hash = 27 * hash * product.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
