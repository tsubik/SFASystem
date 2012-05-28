/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Product object for NHibernate mapped table 'Product'.
	/// </summary>
	[Serializable]
	public class Product
	{
		#region Member Variables
		protected Guid productid;
		protected string shortdescription;
		protected string fulldescription;
		protected decimal price;
		protected bool isdeleted;
        protected string code;
        protected string name;
        protected Manufacturer manufacturer;
        protected ProductGroup productGroup;
        protected Dictionary tax;
        //protected IList<ProductAttributeMapping> productattributemapping;
		protected IList<Image> images;
		#endregion
		#region Constructors
			
		public Product() {
            //this.productid = Guid.NewGuid();
            //this.shortdescription = string.Empty ;
            //this.fulldescription = string.Empty;
            //this.price = 0;
            //this.isdeleted = false;
            //this.name = string.Empty;
            //this.code = string.Empty;
        }
					
		public Product(Guid productid, string code, string name, string shortdescription, string fulldescription, decimal price, bool isdeleted) 
		{
			this.productid= productid;
			this.code = code;
            this.name = name;
            this.shortdescription= shortdescription;
			this.fulldescription= fulldescription;
			this.price= price;
			this.isdeleted= isdeleted;
		}

		public Product(Guid productid,string code, string name, string shortdescription, decimal price, bool isdeleted)
		{
			this.productid= productid;
            this.code = code;
            this.name = name;
			this.shortdescription= shortdescription;
			this.price= price;
			this.isdeleted= isdeleted;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid Productid
		{
			get { return productid; }
			set {productid= value; }
		} 
        public virtual ProductGroup ProductGroup
        {
            get { return productGroup; }
            set { productGroup = value; }
        }

        public virtual Manufacturer Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
		public  virtual string ShortDescription
		{
			get { return shortdescription; }
			set {shortdescription= value; }
		}
		public  virtual string FullDescription
		{
			get { return fulldescription; }
			set {fulldescription= value; }
		}
		public  virtual decimal Price
		{
			get { return price; }
			set {price= value; }
		}
		public  virtual bool IsDeleted
		{
			get { return isdeleted; }
			set {isdeleted= value; }
		}
        public virtual Dictionary Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        //public  virtual IList<ProductAttributeMapping> ProductAttributeMapping
        //{
        //    get { return productattributemapping; }
        //    set {productattributemapping= value; }
        //}
		public  virtual IList<Image> Images
		{
			get { return images; }
			set {images= value; }
		}
		#endregion
		
		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) ) return false;
			Product castObj = (Product)obj;
			return ( castObj != null ) &&
			this.productid == castObj.Productid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * productid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
