/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// Territory object for NHibernate mapped table 'Territory'.
	/// </summary>
	[Serializable]
	public class Territory
	{
		#region Member Variables
		protected Guid territoryid;
		protected Territory parentterritory;
		protected string fulldescription;
		protected string name;
        protected IList<Territory> subTerritories;
		protected IList<CustomerFacility> customerfacilities;
		protected IList<Employee> employees;
		protected IList<Order> orders;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public Territory() {
            //this.territoryid = Guid.NewGuid();
            //this.fulldescription = string.Empty;
            //this.name = string.Empty;
        }
					
		public Territory(Guid territoryid, string fulldescription, string name) 
		{
			this.territoryid= territoryid;
			this.fulldescription= fulldescription;
			this.name= name;
		}

		public Territory(Guid territoryid, string name)
		{
			this.territoryid= territoryid;
			this.name= name;
		}
		
		#endregion
		#region Public Properties
		public  virtual Guid Territoryid
		{
			get { return territoryid; }
			set {territoryid= value; }
		}
		public  virtual Territory ParentTerritory
		{
			get { return parentterritory; }
			set {parentterritory= value; }
		}
        public virtual IList<Territory> SubTerritories
        {
            get { return subTerritories; }
            set { subTerritories = value; }
        }

		public  virtual string FullDescription
		{
			get { return fulldescription; }
			set {fulldescription= value; }
		}
		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
		}
		public  virtual IList<CustomerFacility> CustomerFacilities
		{
			get { return customerfacilities; }
			set {customerfacilities= value; }
		}
		public  virtual IList<Employee> Employees
		{
			get { return employees; }
			set {employees= value; }
		}
		public  virtual IList<Order> Orders
		{
			get { return orders; }
			set {orders= value; }
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
			Territory castObj = (Territory)obj;
			return ( castObj != null ) &&
			this.territoryid == castObj.Territoryid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * territoryid.GetHashCode();
			return hash;
		}
		#endregion
        public override string ToString()
        {
            return this.name;
        }
	}
}
