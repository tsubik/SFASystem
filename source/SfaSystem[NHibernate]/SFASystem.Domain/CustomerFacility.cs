using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// CustomerFacility object for NHibernate mapped table 'CustomerFacility'.
    /// </summary>
    [Serializable]
    public class CustomerFacility : IEntity
    {
        public CustomerFacility()
        {

        }
        public virtual Guid CustomerFacilityID { get; set; }
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
        public virtual Territory Territory { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IList<Contact> Contacts { get; set; }
        public virtual IList<FieldCall> FieldCalls { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual bool IsDeleted { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            CustomerFacility castObj = (CustomerFacility)obj;
            return (castObj != null) &&
            this.CustomerFacilityID == castObj.CustomerFacilityID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * CustomerFacilityID.GetHashCode();
            return hash;
        }
        #endregion

        public override string ToString()
        {
            return this.Name;
        }

    }
}
