using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// ProductGroup object for NHibernate mapped table 'ProductGroup'.
    /// </summary>
    [Serializable]
    public class ProductGroup : IEntity
    {
        public ProductGroup()
        {
            ChildProductGroups = new List<ProductGroup>();
        }
        public virtual Guid ProductGroupID { get; set; }
        public virtual ProductGroup ProductGroupParent { get; set; }
        public virtual IList<ProductGroup> ChildProductGroups { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsDeleted { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            ProductGroup castObj = (ProductGroup)obj;
            return (castObj != null) &&
            this.ProductGroupID == castObj.ProductGroupID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ProductGroupID.GetHashCode();
            return hash;
        }
        #endregion
    }
}
