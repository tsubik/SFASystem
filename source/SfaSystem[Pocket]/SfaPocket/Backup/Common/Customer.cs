/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;
using SFASystem.Pocket.Core.BusinessLogic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// Customer object for NHibernate mapped table 'Customer'.
	/// </summary>
	[Serializable]
	public class Customer
	{
		#region Member Variables
		protected Guid customerid;
        protected Guid contactid;
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
            //this.customerid = Guid.NewGuid();
            //this.isdeleted = false;
            //this.fulldescription = string.Empty;
            //this.customerto = DateTime.MinValue;
            //this.customersince = DateTime.MinValue;
        }
					
		public Customer(Guid customerid, bool isdeleted, string fulldescription, DateTime? customersince, DateTime? customerto) 
		{
			this.customerid= customerid;
			this.isdeleted= isdeleted;
			this.fulldescription= fulldescription;
			this.customersince= customersince;
			this.customerto= customerto;
		}

		public Customer(Guid customerid, bool isdeleted, string fulldescription)
		{
			this.customerid= customerid;
			this.isdeleted= isdeleted;
			this.fulldescription= fulldescription;
		}
		
		#endregion
		#region Public Properties
		
        public  virtual Guid CustomerID
		{
			get { return customerid; }
			set {customerid= value; }
		}
        public virtual Guid ContactID
        {
            get { return contactid; }
            set { contactid = value; }
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
		public  virtual string FullDescription
		{
			get { return fulldescription; }
			set {fulldescription= value; }
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
			get {
                if (customerfacility == null)
                    customerfacility = CustomerManager.GetCustomerFacilities(this.CustomerID, Guid.Empty);
                return customerfacility; }
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
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			Customer castObj = (Customer)obj;
			return ( castObj != null ) &&
			this.customerid == castObj.CustomerID;
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
