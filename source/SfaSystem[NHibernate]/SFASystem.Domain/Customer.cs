using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Customer object for NHibernate mapped table 'Customer'.
    /// </summary>
    [Serializable]
    public class Customer : IEntity
    {
        public Customer()
        {

        }
        public virtual Guid CustomerID { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string NIP { get; set; }
        public virtual string REGON { get; set; }
        public virtual string KRS { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string FullDescription { get; set; }
        public virtual DateTime? CustomerSince { get; set; }
        public virtual DateTime? CustomerTo { get; set; }
        public virtual IList<CustomerFacility> CustomerFacility { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null)) return false;
            Customer castObj = (Customer)obj;
            return (castObj != null) &&
            this.CustomerID == castObj.CustomerID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * CustomerID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
