using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Dictionary object for NHibernate mapped table 'Dictionary'.
    /// </summary>
    [Serializable]
    public class Dictionary : IEntity
    {
        public Dictionary()
        {

        }
        public virtual Guid DictionaryID { get; set; }
        public virtual DictionaryType DictionaryType { get; set; }
        public virtual string Value { get; set; }
        public virtual byte DictionaryNumber { get; set; }
        public virtual bool IsDeleted { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Dictionary castObj = (Dictionary)obj;
            return (castObj != null) &&
            this.DictionaryID == castObj.DictionaryID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * DictionaryID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
