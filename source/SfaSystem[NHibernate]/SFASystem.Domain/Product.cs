using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Product object for NHibernate mapped table 'Product'.
    /// </summary>
    [Serializable]
    public class Product : IEntity
    {
        public virtual Guid ProductID { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string FullDescription { get; set; }
        public virtual decimal Price { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual Dictionary Tax { get; set; }
        public virtual IList<Image> Images { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null)) return false;
            Product castObj = (Product)obj;
            return (castObj != null) &&
            this.ProductID == castObj.ProductID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ProductID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
