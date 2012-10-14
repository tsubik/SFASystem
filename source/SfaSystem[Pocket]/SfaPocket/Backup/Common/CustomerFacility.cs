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
	/// CustomerFacility object for NHibernate mapped table 'CustomerFacility'.
	/// </summary>
	[Serializable]
	public class CustomerFacility
	{
		#region Member Variables
		protected Guid customerfacilityid;
        protected string name;
        protected string email;
        protected string phone;
        protected Guid addressid;
        protected Guid territoryid;
        protected Guid customerid;
		protected Address address;
		protected Territory territory;
		protected Customer customer;
		protected IList<Contact> contact;
		protected IList<FieldCall> fieldcall;
		protected IList<Order> order;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public CustomerFacility() {
            //this.customerfacilityid = Guid.NewGuid();
            //this.address = null;
            //this.territory = null;
            //this.customer = null;
        }   
					
		public CustomerFacility(Guid customerfacilityid, Address address, Territory territory, Customer customer) 
		{
			this.customerfacilityid= customerfacilityid;
			this.address= address;
			this.territory= territory;
			this.customer= customer;
		}

		#endregion
		#region Public Properties
		public  virtual Guid CustomerFacilityID
		{
			get { return customerfacilityid; }
			set {customerfacilityid= value; }
		}
        public virtual Guid AddressID
        {
            get { return addressid; }
            set { addressid = value; }
        }
        public virtual Guid TerritoryID
        {
            get { return territoryid; }
            set { territoryid = value; }
        }

        public virtual Guid CustomerID
        {
            get { return customerid; }
            set { customerid = value; }
        }
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
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

		public  virtual Address Address
		{
			get {
                if (this.address == null)
                    address = AddressManager.GetAddressByID(this.AddressID);
                return address; }
			set {address= value; }
		}
		public  virtual Territory Territory
		{
			get {
                if (this.territory == null)
                    territory = TerritoryManager.GetTerritoryByID(this.TerritoryID);
                return territory; }
			set {territory= value; }
		}
		public  virtual Customer Customer
		{
			get {
                if (customer == null)
                    customer = CustomerManager.GetCustomerByID(this.CustomerID);
                return customer; }
			set {customer= value; }
		}
		public  virtual IList<Contact> Contact
		{
			get { return contact; }
			set {contact= value; }
		}
		public  virtual IList<FieldCall> FieldCall
		{
			get { return fieldcall; }
			set {fieldcall= value; }
		}
		public  virtual IList<Order> Order
		{
			get { return order; }
			set {order= value; }
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
			CustomerFacility castObj = (CustomerFacility)obj;
			return ( castObj != null ) &&
			this.customerfacilityid == castObj.CustomerFacilityID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * customerfacilityid.GetHashCode();
			return hash;
		}
		#endregion

        public override string ToString()
        {
            return this.Name;
        }

	}
}
