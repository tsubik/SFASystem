/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Contact object for NHibernate mapped table 'Contact'.
    /// </summary>
    [Serializable]
    public class Contact : ICloneable, IEntity
    {
        public Contact()
        {

        }

        public virtual Guid ContactID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
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
            //if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
            if ((obj == null)) return false;
            Contact castObj = (Contact)obj;
            return (castObj != null) &&
            this.ContactID == castObj.ContactID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ContactID.GetHashCode();
            return hash;
        }
        #endregion


        #region ICloneable Members

        protected virtual Contact Clone()
        {
            return (Contact)((ICloneable)this).Clone();
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
