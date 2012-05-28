/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// ProductAttribute object for NHibernate mapped table 'ProductAttribute'.
	/// </summary>
	[Serializable]
	public class ProductAttribute
	{
		#region Member Variables
		protected Guid productattributeid;
		protected string name;
		protected string fulldescription;
		#endregion
		#region Constructors
			
		public ProductAttribute() {
            //this.productattributeid = Guid.NewGuid();
            //this.name = string.Empty;
            //this.fulldescription = string.Empty;
        }
					
		public ProductAttribute(Guid productattributeid, string name, string fulldescription) 
		{
			this.productattributeid= productattributeid;
			this.name= name;
			this.fulldescription= fulldescription;
		}

		public ProductAttribute(Guid productattributeid, string name)
		{
			this.productattributeid= productattributeid;
			this.name= name;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid ProductAttributeid
		{
			get { return productattributeid; }
			set {productattributeid= value; }
		}
		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
		}
		public  virtual string FullDescription
		{
			get { return fulldescription; }
			set {fulldescription= value; }
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
			ProductAttribute castObj = (ProductAttribute)obj;
			return ( castObj != null ) &&
			this.productattributeid == castObj.ProductAttributeid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * productattributeid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
