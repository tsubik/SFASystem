/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Customer object for NHibernate mapped table 'Customer'.
	/// </summary>
	[Serializable]
	public class Customer
	{
		#region Member Variables
		protected Guid customerid;
		protected Contact contact;
		protected bool isdeleted;
        protected string name;
        protected string code;
        protected string nip;
        protected string regon;
        protected string krs;
		protected string fulldescription;
        protected string email;
        protected string phone;
		protected DateTime? customersince;
		protected DateTime? customerto;
		protected IList<CustomerFacility> customerfacility;
		#endregion
		#region Constructors
			
		public Customer() {
           
        }
						
		#endregion

		#region Public Properties
		public  virtual Guid Customerid
		{
			get { return customerid; }
			set {customerid= value; }
		}
		public  virtual Contact Contact
		{
			get { return contact; }
			set {contact= value; }
		}
		public  virtual bool IsDeleted
		{
			get { return isdeleted; }
			set {isdeleted= value; }
		}
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }
        public virtual string NIP
        {
            get { return nip; }
            set { nip = value; }
        }
        public virtual string REGON
        {
            get { return regon; }
            set { regon = value; }
        }
        public virtual string KRS
        {
            get { return krs; }
            set { krs = value; }
        }
        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }
        public virtual string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
		public  virtual string FullDescription
		{
			get { return fulldescription; }
			set {fulldescription= value; }
		}
		public  virtual DateTime? CustomerSince
		{
			get { return customersince; }
			set {customersince= value; }
		}
		public  virtual DateTime? CustomerTo
		{
			get { return customerto; }
			set {customerto= value; }
		}
		public  virtual IList<CustomerFacility> CustomerFacility
		{
			get { return customerfacility; }
			set {customerfacility= value; }
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
			Customer castObj = (Customer)obj;
			return ( castObj != null ) &&
			this.customerid == castObj.Customerid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * customerid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
