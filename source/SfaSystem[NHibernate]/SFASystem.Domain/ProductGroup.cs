/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// ProductGroup object for NHibernate mapped table 'ProductGroup'.
	/// </summary>
	[Serializable]
	public class ProductGroup
	{
		#region Member Variables
		protected Guid productgroupid;
		protected ProductGroup productgroupmember;
        protected IList<ProductGroup> childProductGroups;
		protected string name;
		protected string description;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public ProductGroup() {
            //this.productgroupid = Guid.NewGuid();
            //this.name = string.Empty;
            //this.description = string.Empty;
        }
					
		public ProductGroup(Guid productgroupid, string name, string description) 
		{
			this.productgroupid= productgroupid;
			this.name= name;
			this.description= description;
		}

		public ProductGroup(Guid productgroupid, string name)
		{
			this.productgroupid= productgroupid;
			this.name= name;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid ProductGroupid
		{
			get { return productgroupid; }
			set {productgroupid= value; }
		}
		public  virtual ProductGroup ProductGroupMember
		{
			get { return productgroupmember; }
			set {productgroupmember= value; }
		}

        public virtual IList<ProductGroup> ChildProductGroups
        {
            get { return childProductGroups; }
            set { childProductGroups = value; }
        }

		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
		}
		public  virtual string Description
		{
			get { return description; }
			set {description= value; }
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
			ProductGroup castObj = (ProductGroup)obj;
			return ( castObj != null ) &&
			this.productgroupid == castObj.ProductGroupid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * productgroupid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
