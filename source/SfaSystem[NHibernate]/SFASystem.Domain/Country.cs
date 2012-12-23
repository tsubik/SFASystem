using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Country object for NHibernate mapped table 'Country'.
    /// </summary>
    [Serializable]
    public class Country : IEntity
    {
        public Country()
        {

        }
        public virtual Guid CountryID { get; set; }
        public virtual string Name { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Country castObj = (Country)obj;
            return (castObj != null) &&
            this.CountryID == castObj.CountryID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * CountryID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
