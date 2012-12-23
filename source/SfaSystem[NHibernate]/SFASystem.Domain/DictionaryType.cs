using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// DictionaryType object for NHibernate mapped table 'DictionaryType'.
    /// </summary>
    [Serializable]
    public class DictionaryType : IEntity
    {
        public virtual Guid DictionaryTypeID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Dictionary> Dictionaries { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            DictionaryType castObj = (DictionaryType)obj;
            return (castObj != null) &&
            this.DictionaryTypeID == castObj.DictionaryTypeID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * DictionaryTypeID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
