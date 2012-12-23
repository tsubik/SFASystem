using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Image object for NHibernate mapped table 'Image'.
    /// </summary>
    [Serializable]
    public class Image : IEntity
    {
        public Image()
        {

        }
        public virtual Guid ImageID { get; set; }
        public virtual byte[] ImageFile { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Image castObj = (Image)obj;
            return (castObj != null) &&
            this.ImageID == castObj.ImageID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ImageID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
