/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// City object for NHibernate mapped table 'City'.
	/// </summary>
	[Serializable]
	public class City
	{
		#region Member Variables
		protected Guid cityid;
		protected string name;
		#endregion
		#region Constructors
			
		public City() {
            //this.cityid = Guid.NewGuid();
            //this.name = string.Empty;
        }
					
		public City(Guid cityid, string name) 
		{
			this.cityid= cityid;
			this.name= name;
		}

		#endregion
		#region Public Properties
		public  virtual Guid Cityid
		{
			get { return cityid; }
			set {cityid= value; }
		}
		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
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
			City castObj = (City)obj;
			return ( castObj != null ) &&
			this.cityid == castObj.Cityid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * cityid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
