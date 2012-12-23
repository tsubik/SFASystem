using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Territory object for NHibernate mapped table 'Territory'.
    /// </summary>
    [Serializable]
    public class Territory : IEntity
    {
        public Territory()
        {

        }
        public virtual Guid TerritoryID { get; set; }
        public virtual Territory ParentTerritory { get; set; }
        public virtual IList<Territory> SubTerritories { get; set; }

        public virtual string FullDescription { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<CustomerFacility> CustomerFacilities { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual bool IsDeleted { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Territory castObj = (Territory)obj;
            return (castObj != null) &&
            this.TerritoryID == castObj.TerritoryID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * TerritoryID.GetHashCode();
            return hash;
        }
        #endregion
        public override string ToString()
        {
            return this.Name;
        }
    }
}
