/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// Contact object for NHibernate mapped table 'Contact'.
	/// </summary>
	[Serializable]
	public class Contact
	{
		#region Member Variables
		protected Guid contactid;
		protected string firstname;
		protected string lastname;
		protected string email;
		protected string phone;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public Contact() {
            //this.contactid = new Guid();
            //this.firstname = string.Empty;
            //this.lastname = string.Empty;
            //this.email = string.Empty;
            //this.phone = string.Empty;
        }
					
		public Contact(Guid contactid, string firstname, string lastname, string email, string phone) 
		{
			this.contactid= contactid;
			this.firstname= firstname;
			this.lastname= lastname;
			this.email= email;
			this.phone= phone;
		}

		#endregion
		#region Public Properties
		public  virtual Guid ContactID
		{
			get { return contactid; }
			set {contactid= value; }
		}
		public  virtual string FirstName
		{
			get { return firstname; }
			set {firstname= value; }
		}
		public  virtual string LastName
		{
			get { return lastname; }
			set {lastname= value; }
		}
		public  virtual string Email
		{
			get { return email; }
			set {email= value; }
		}
		public  virtual string Phone
		{
			get { return phone; }
			set {phone= value; }
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
            //if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
            if( ( obj == null )) return false;
			Contact castObj = (Contact)obj;
			return ( castObj != null ) &&
			this.contactid == castObj.ContactID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * contactid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
