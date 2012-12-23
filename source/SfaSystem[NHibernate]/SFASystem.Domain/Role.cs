using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Role object for NHibernate mapped table 'Role'.
    /// </summary>
    [Serializable]
    public class Role : IEntity
    {
        public Role()
        {

        }
        public virtual Guid RoleID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Employee> Employees { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Role castObj = (Role)obj;
            return (castObj != null) &&
            this.RoleID == castObj.RoleID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * RoleID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
