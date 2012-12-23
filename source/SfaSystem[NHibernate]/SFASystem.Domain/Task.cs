using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Task object for NHibernate mapped table 'Task'.
    /// </summary>
    [Serializable]
    public class Task : IEntity
    {
        public Task()
        {
            
        }
        public virtual Guid TaskID { get; set; }
        public virtual string Name { get; set; }
        public virtual Employee CreatedBy { get; set; }
        public virtual Employee AssignedTo { get; set; }
        public virtual Employee GivenBy { get; set; }
        public virtual Employee ApprovedBy { get; set; }
        public virtual string FullDescription { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual DateTime? DateExecuted { get; set; }
        public virtual DateTime? DateToEndTask { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual Dictionary TaskStatus { get; set; }
        public virtual bool IsDeleted { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Task castObj = (Task)obj;
            return (castObj != null) &&
            this.TaskID == castObj.TaskID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * TaskID.GetHashCode();
            return hash;
        }
        #endregion
    }
}
