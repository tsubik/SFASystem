/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Employee object for NHibernate mapped table 'Employee'.
	/// </summary>
	[Serializable]
	public class Employee
	{
		#region Member Variables
		protected Guid employeeid;
		protected Territory territory;
		protected Address address;
		protected Employee manager;
		protected Contact contact;
		protected string login;
		protected string passwordhash;
		protected string passwordsalt;
		protected bool active;
		protected DateTime? creationdate;
		protected DateTime? lastlogindate;
		protected DateTime? lastactivitydate;
		protected IList<Role> roles;
		protected IList<FieldCall> fieldcalls;
		protected IList<Order> orders;
		protected IList<Task> assignedtotasks;
		protected IList<Task> givenbytasks;
		protected IList<Task> approvedbytasks;
		protected IList<Task> createdbytask;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public Employee() {
            //this.employeeid = Guid.NewGuid();
            //this.login = string.Empty;
            //this.passwordhash = string.Empty;
            //this.passwordsalt = string.Empty;
            //this.active = true;
            //this.creationdate = DateTime.MinValue;
            //this.lastactivitydate = DateTime.MinValue;
            //this.lastlogindate = DateTime.MinValue;
        }
					
		public Employee(Guid employeeid, string login, string passwordhash, string passwordsalt, bool active, DateTime? creationdate, DateTime? lastlogindate, DateTime? lastactivitydate) 
		{
			this.employeeid= employeeid;
			this.login= login;
			this.passwordhash= passwordhash;
			this.passwordsalt= passwordsalt;
			this.active= active;
			this.creationdate= creationdate;
			this.lastlogindate= lastlogindate;
			this.lastactivitydate= lastactivitydate;
		}

		public Employee(Guid employeeid, string login, string passwordhash, string passwordsalt, bool active)
		{
			this.employeeid= employeeid;
			this.login= login;
			this.passwordhash= passwordhash;
			this.passwordsalt= passwordsalt;
			this.active= active;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid Employeeid
		{
			get { return employeeid; }
			set {employeeid= value; }
		}
		public  virtual Territory Territory
		{
			get { return territory; }
			set {territory= value; }
		}
		public  virtual Address Address
		{
			get { return address; }
			set {address= value; }
		}
		public  virtual Employee Manager
		{
			get { return manager; }
			set {manager= value; }
		}
		public  virtual Contact Contact
		{
			get { return contact; }
			set {contact= value; }
		}
		public  virtual string Login
		{
			get { return login; }
			set {login= value; }
		}
		public  virtual string PasswordHash
		{
			get { return passwordhash; }
			set {passwordhash= value; }
		}
		public  virtual string PasswordSalt
		{
			get { return passwordsalt; }
			set {passwordsalt= value; }
		}
		public  virtual bool Active
		{
			get { return active; }
			set {active= value; }
		}
		public  virtual DateTime? CreationDate
		{
			get { return creationdate; }
			set {creationdate= value; }
		}
		public  virtual DateTime? LastLoginDate
		{
			get { return lastlogindate; }
			set {lastlogindate= value; }
		}
		public  virtual DateTime? LastActivityDate
		{
			get { return lastactivitydate; }
			set {lastactivitydate= value; }
		}
		public  virtual IList<Role> Roles
		{
			get { return roles; }
			set {roles= value; }
		}
		public  virtual IList<FieldCall> FieldCalls
		{
			get { return fieldcalls; }
			set {fieldcalls= value; }
		}
		public  virtual IList<Order> Orders
		{
			get { return orders; }
			set {orders= value; }
		}
		public  virtual IList<Task> AssignedToTasks
		{
			get { return assignedtotasks; }
			set {assignedtotasks= value; }
		}
		public  virtual IList<Task> GivenByTasks
		{
			get { return givenbytasks; }
			set {givenbytasks= value; }
		}
		public  virtual IList<Task> ApprovedByTasks
		{
			get { return approvedbytasks; }
			set {approvedbytasks= value; }
		}
		public  virtual IList<Task> CreatedByTask
		{
			get { return createdbytask; }
			set {createdbytask= value; }
		}
        public virtual bool IsDeleted
        {
            get { return isdeleted; }
            set { isdeleted = value; }
        }
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

		#endregion
		
		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null )  ) return false;
			Employee castObj = (Employee)obj;
			return ( castObj != null ) &&
			this.employeeid == castObj.Employeeid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * employeeid.GetHashCode();
			return hash;
		}
        public override string ToString()
        {
            return this.FriendlyName;
        }

		#endregion
		
	}
}
