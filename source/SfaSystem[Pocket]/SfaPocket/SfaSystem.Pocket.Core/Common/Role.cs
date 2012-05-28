/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// Role object for NHibernate mapped table 'Role'.
	/// </summary>
	[Serializable]
	public class Role
	{
		#region Member Variables
		protected Guid roleid;
		protected string name;
		protected IList<Employee> employees;
		#endregion
		#region Constructors
			
		public Role() {
            //this.roleid = Guid.NewGuid();
            //this.name = string.Empty;
        }
					
		public Role(Guid roleid, string name) 
		{
			this.roleid= roleid;
			this.name= name;
		}

		#endregion
		#region Public Properties
		public  virtual Guid RoleID
		{
			get { return roleid; }
			set {roleid= value; }
		}
		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
		}
		public  virtual IList<Employee> Employees
		{
			get { return employees; }
			set {employees= value; }
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
			Role castObj = (Role)obj;
			return ( castObj != null ) &&
			this.roleid == castObj.RoleID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * roleid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
