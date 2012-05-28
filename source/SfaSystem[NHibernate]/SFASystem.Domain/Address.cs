/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Address object for NHibernate mapped table 'Address'.
	/// </summary>
	[Serializable]
	public class Address
	{
		#region Member Variables
		protected Guid addressid;
		protected Country country;
		protected City city;
		protected string street;
		protected string zipcode;
		protected string housenr;
		protected string apartmentnr;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public Address() {
            //this.addressid = Guid.NewGuid();
            //this.country = null;
            //this.city = null;
            //this.street = string.Empty;
            //this.zipcode = string.Empty;
            //this.housenr = string.Empty;
            //this.apartmentnr = string.Empty;
        }
					
		public Address(Guid addressid, Country country, City city, string street, string zipcode, string housenr, string apartmentnr) 
		{
			this.addressid= addressid;
			this.country= country;
			this.city= city;
			this.street= street;
			this.zipcode= zipcode;
			this.housenr= housenr;
			this.apartmentnr= apartmentnr;
		}

		public Address(Guid addressid, Country country, City city, string street, string zipcode, string housenr)
		{
			this.addressid= addressid;
			this.country= country;
			this.city= city;
			this.street= street;
			this.zipcode= zipcode;
			this.housenr= housenr;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid Addressid
		{
			get { return addressid; }
			set {addressid= value; }
		}
		public  virtual Country Country
		{
			get { return country; }
			set {country= value; }
		}
		public  virtual City City
		{
			get { return city; }
			set {city= value; }
		}
		public  virtual string Street
		{
			get { return street; }
			set {street= value; }
		}
		public  virtual string ZipCode
		{
			get { return zipcode; }
			set {zipcode= value; }
		}
		public  virtual string HouseNr
		{
			get { return housenr; }
			set {housenr= value; }
		}
		public  virtual string ApartmentNr
		{
			get { return apartmentnr; }
			set {apartmentnr= value; }
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
			Address castObj = (Address)obj;
			return ( castObj != null ) &&
			this.addressid == castObj.Addressid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * addressid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
