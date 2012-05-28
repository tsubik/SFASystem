/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// ProductAttributeMappingId object for NHibernate mapped table 'ProductAttributeMapping'.
	/// </summary>
	[Serializable]
	public class ProductAttributeMappingId
	{
		#region Member Variables
		protected Product product;
		protected ProductAttribute productattribute;
		#endregion
		#region Constructors
			
		public ProductAttributeMappingId() {}
					
		public ProductAttributeMappingId(Product product, ProductAttribute productattribute) 
		{
			this.product= product;
			this.productattribute= productattribute;
		}

		#endregion
		#region Public Properties
		public  virtual Product Product
		{
			get { return product; }
			set {product= value; }
		}
		public  virtual ProductAttribute ProductAttribute
		{
			get { return productattribute; }
			set {productattribute= value; }
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
			ProductAttributeMappingId castObj = (ProductAttributeMappingId)obj;
			return ( castObj != null ) &&
			this.product.Equals( castObj.Product) &&
			this.productattribute.Equals( castObj.ProductAttribute);
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * product.GetHashCode();
			hash = 27 * hash * productattribute.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
