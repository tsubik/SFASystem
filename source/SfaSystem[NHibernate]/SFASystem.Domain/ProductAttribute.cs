using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// ProductAttribute object for NHibernate mapped table 'ProductAttribute'.
    /// </summary>
    [Serializable]
    public class ProductAttribute : IEntity
    {
        public virtual Guid ProductAttributeID { get; set; }
        public virtual string Name { get; set; }
        public virtual string FullDescription { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            ProductAttribute castObj = (ProductAttribute)obj;
            return (castObj != null) &&
            this.ProductAttributeID == castObj.ProductAttributeID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ProductAttributeID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
