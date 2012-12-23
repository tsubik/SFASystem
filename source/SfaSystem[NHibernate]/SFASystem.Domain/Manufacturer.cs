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
    public class Manufacturer : IEntity
    {
        public virtual Guid ManufacturerID { get; set; }
        public virtual Address Address { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }

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
            this.ManufacturerID == castObj.ManufacturerID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ManufacturerID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
