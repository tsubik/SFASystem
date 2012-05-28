using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.Domain
{
    /// <summary>
    /// Manufacturer object for NHibernate mapped table 'Manufacturer'.
    /// </summary>
    [Serializable]
    public class Manufacturer
    {
        #region Member Variables
        protected Guid manufacturerid;
        protected Address address;
        protected bool isdeleted;
        protected string name;
        protected string description;
        protected string email;
        protected string phone;
        #endregion
        #region Constructors

        public Manufacturer()
        {
            
        }

        #endregion
        #region Public Properties
        public virtual Guid ManufacturerID
        {
            get { return manufacturerid; }
            set { manufacturerid = value; }
        }
        public virtual Address Address
        {
            get { return address; }
            set { address = value; }
        }
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual string Description
        {
            get { return description; }
            set { description = value; }
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
       
        #endregion

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Manufacturer castObj = (Manufacturer)obj;
            return (castObj != null) &&
            this.manufacturerid == castObj.ManufacturerID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * manufacturerid.GetHashCode();
            return hash;
        }
        #endregion

    }
}
