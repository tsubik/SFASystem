/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// ProductAttributeMapping object for NHibernate mapped table 'ProductAttributeMapping'.
	/// </summary>
	[Serializable]
	public class ProductAttributeMapping
	{
		#region Member Variables
		protected ProductAttributeMappingId id;
		protected string textvalue;
		protected int? intvalue;
		protected decimal? decimalvalue;
		protected Product product;
		protected ProductAttribute productattribute;
		#endregion
		#region Constructors
			
		public ProductAttributeMapping() {
        
        }
					
		public ProductAttributeMapping(ProductAttributeMappingId id, string textvalue, int? intvalue, decimal? decimalvalue, Product product, ProductAttribute productattribute) 
		{
			this.id= id;
			this.textvalue= textvalue;
			this.intvalue= intvalue;
			this.decimalvalue= decimalvalue;
			this.product= product;
			this.productattribute= productattribute;
		}

		public ProductAttributeMapping(ProductAttributeMappingId id, Product product, ProductAttribute productattribute)
		{
			this.id= id;
			this.product= product;
			this.productattribute= productattribute;
		}
		
		#endregion
		#region Public Properties
		public  virtual ProductAttributeMappingId Id
		{
			get { return id; }
			set {id= value; }
		}
		public  virtual string TextValue
		{
			get { return textvalue; }
			set {textvalue= value; }
		}
		public  virtual int? IntValue
		{
			get { return intvalue; }
			set {intvalue= value; }
		}
		public  virtual decimal? DecimalValue
		{
			get { return decimalvalue; }
			set {decimalvalue= value; }
		}
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
			ProductAttributeMapping castObj = (ProductAttributeMapping)obj;
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
