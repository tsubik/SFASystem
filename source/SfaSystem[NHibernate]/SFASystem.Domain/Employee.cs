using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Employee object for NHibernate mapped table 'Employee'.
    /// </summary>
    [Serializable]
    public class Employee : IEntity
    {
        public Employee()
        {
            Roles = new List<Role>();
        }
        public virtual Guid EmployeeID { get; set; }
        public virtual Territory Territory { get; set; }
        public virtual Address Address { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual string Login { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual DateTime? LastActivityDate { get; set; }
        public virtual IList<Role> Roles { get; set; }
        public virtual IList<FieldCall> FieldCalls { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual IList<Task> AssignedToTasks { get; set; }
        public virtual IList<Task> GivenByTasks { get; set; }
        public virtual IList<Task> ApprovedByTasks { get; set; }
        public virtual IList<Task> CreatedByTask { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string FriendlyName
        {
            get
            {
                if (this.Contact != null)
                    return this.Contact.FirstName + " " + this.Contact.LastName;
                else
                    return this.Login;
            }
        }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null)) return false;
            Employee castObj = (Employee)obj;
            return (castObj != null) &&
            this.EmployeeID == castObj.EmployeeID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * EmployeeID.GetHashCode();
            return hash;
        }
        public override string ToString()
        {
            return this.FriendlyName;
        }

        #endregion

    }
}
