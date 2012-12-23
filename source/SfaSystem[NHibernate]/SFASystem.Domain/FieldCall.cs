using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// FieldCall object for NHibernate mapped table 'FieldCall'.
    /// </summary>
    [Serializable]
    public class FieldCall : IEntity
    {
        public FieldCall()
        {

        }
        public virtual Guid FieldCallID { get; set; }
        public virtual Dictionary FieldCallStatus { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual CustomerFacility CustomerFacility { get; set; }
        public virtual string FullDescription { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual DateTime? StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }
        public virtual bool IsDeleted { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            FieldCall castObj = (FieldCall)obj;
            return (castObj != null) &&
            this.FieldCallID == castObj.FieldCallID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * FieldCallID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
