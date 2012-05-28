/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Task object for NHibernate mapped table 'Task'.
	/// </summary>
	[Serializable]
	public class Task
	{
		#region Member Variables
		protected Guid taskid;
		protected string name;
		protected Employee createdby;
		protected Employee assignedto;
		protected Employee givenby;
		protected Employee approvedby;
		protected string fulldescription;
		protected DateTime datecreated;
		protected DateTime? datemodified;
		protected DateTime? dateexecuted;
		protected DateTime? datetoendtask;
		protected bool isapproved;
		protected Dictionary taskstatus;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public Task() {
            //this.taskid = Guid.NewGuid();
            //this.name = string.Empty;
            //this.createdby = null;
            //this.fulldescription = string.Empty;
            //this.datecreated = DateTime.MinValue;
            //this.datemodified = DateTime.MinValue;
            //this.dateexecuted = DateTime.MinValue;
            //this.datetoendtask = DateTime.MinValue;
            //this.isapproved = false;
            //this.taskstatus = null;
        }
					
		public Task(Guid taskid, string name, Employee createdby, string fulldescription, DateTime datecreated, DateTime? datemodified, DateTime? dateexecuted, DateTime? datetoendtask, bool isapproved, Dictionary taskstatus) 
		{
			this.taskid= taskid;
			this.name= name;
			this.createdby= createdby;
			this.fulldescription= fulldescription;
			this.datecreated= datecreated;
			this.datemodified= datemodified;
			this.dateexecuted= dateexecuted;
			this.datetoendtask= datetoendtask;
			this.isapproved= isapproved;
			this.taskstatus= taskstatus;
		}

		public Task(Guid taskid, string name, Employee createdby, DateTime datecreated, bool isapproved, Dictionary taskstatus)
		{
			this.taskid= taskid;
			this.name= name;
			this.createdby= createdby;
			this.datecreated= datecreated;
			this.isapproved= isapproved;
			this.taskstatus= taskstatus;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid Taskid
		{
			get { return taskid; }
			set {taskid= value; }
		}
		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
		}
		public  virtual Employee CreatedBy
		{
			get { return createdby; }
			set {createdby= value; }
		}
		public  virtual Employee AssignedTo
		{
			get { return assignedto; }
			set {assignedto= value; }
		}
		public  virtual Employee GivenBy
		{
			get { return givenby; }
			set {givenby= value; }
		}
		public  virtual Employee ApprovedBy
		{
			get { return approvedby; }
			set {approvedby= value; }
		}
		public  virtual string FullDescription
		{
			get { return fulldescription; }
			set {fulldescription= value; }
		}
		public  virtual DateTime DateCreated
		{
			get { return datecreated; }
			set {datecreated= value; }
		}
		public  virtual DateTime? DateModified
		{
			get { return datemodified; }
			set {datemodified= value; }
		}
		public  virtual DateTime? DateExecuted
		{
			get { return dateexecuted; }
			set {dateexecuted= value; }
		}
		public  virtual DateTime? DateToEndTask
		{
			get { return datetoendtask; }
			set {datetoendtask= value; }
		}
		public  virtual bool IsApproved
		{
			get { return isapproved; }
			set {isapproved= value; }
		}
		public  virtual Dictionary TaskStatus
		{
			get { return taskstatus; }
			set {taskstatus= value; }
		}
        public virtual bool IsDeleted
        {
            get { return isdeleted; }
            set { isdeleted = value; }
        }
		#endregion
		
		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			Task castObj = (Task)obj;
			return ( castObj != null ) &&
			this.taskid == castObj.Taskid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * taskid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
