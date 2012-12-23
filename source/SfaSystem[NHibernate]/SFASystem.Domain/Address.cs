using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Address object for NHibernate mapped table 'Address'.
	/// </summary>
	[Serializable]
	public class Address : IEntity
	{
		public Address() {
        }
						
        public virtual Guid AddressID { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual string Street { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string HouseNr { get; set; }
        public virtual string ApartmentNr { get; set; }
        public virtual bool IsDeleted { get; set; }
		
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
			this.AddressID == castObj.AddressID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
            hash = 27 * hash * AddressID.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
