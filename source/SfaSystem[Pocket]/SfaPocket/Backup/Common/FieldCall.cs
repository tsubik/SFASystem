/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// FieldCall object for NHibernate mapped table 'FieldCall'.
	/// </summary>
	[Serializable]
	public class FieldCall
	{
		#region Member Variables
		protected Guid fieldcallid;
		protected Dictionary fieldcallstatus;
		protected Employee employee;
		protected Contact contact;
		protected CustomerFacility customerfacility;
		protected string fulldescription;
		protected DateTime? date;
		protected DateTime? starttime;
		protected DateTime? endtime;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public FieldCall() {
            //this.fieldcallid = Guid.NewGuid();
            //this.fieldcallstatus = null;
            //this.fulldescription = string.Empty;
            //this.contact = null;
            //this.customerfacility = null;
            //this.date = DateTime.MinValue;
            //this.starttime = DateTime.MinValue;
            //this.endtime = DateTime.MinValue;
        }
					
		public FieldCall(Guid fieldcallid, Dictionary fieldcallstatus, Employee employee, Contact contact, CustomerFacility customerfacility, string fulldescription, DateTime? date, DateTime? starttime, DateTime? endtime) 
		{
			this.fieldcallid= fieldcallid;
			this.fieldcallstatus= fieldcallstatus;
			this.employee= employee;
			this.contact= contact;
			this.customerfacility= customerfacility;
			this.fulldescription= fulldescription;
			this.date= date;
			this.starttime= starttime;
			this.endtime= endtime;
		}

		public FieldCall(Guid fieldcallid, Dictionary fieldcallstatus, Employee employee, Contact contact, CustomerFacility customerfacility)
		{
			this.fieldcallid= fieldcallid;
			this.fieldcallstatus= fieldcallstatus;
			this.employee= employee;
			this.contact= contact;
			this.customerfacility= customerfacility;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid FieldCallid
		{
			get { return fieldcallid; }
			set {fieldcallid= value; }
		}
		public  virtual Dictionary FieldCallStatus
		{
			get { return fieldcallstatus; }
			set {fieldcallstatus= value; }
		}
		public  virtual Employee Employee
		{
			get { return employee; }
			set {employee= value; }
		}
		public  virtual Contact Contact
		{
			get { return contact; }
			set {contact= value; }
		}
		public  virtual CustomerFacility CustomerFacility
		{
			get { return customerfacility; }
			set {customerfacility= value; }
		}
		public  virtual string FullDescription
		{
			get { return fulldescription; }
			set {fulldescription= value; }
		}
		public  virtual DateTime? Date
		{
			get { return date; }
			set {date= value; }
		}
		public  virtual DateTime? StartTime
		{
			get { return starttime; }
			set {starttime= value; }
		}
		public  virtual DateTime? EndTime
		{
			get { return endtime; }
			set {endtime= value; }
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
			FieldCall castObj = (FieldCall)obj;
			return ( castObj != null ) &&
			this.fieldcallid == castObj.FieldCallid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * fieldcallid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
