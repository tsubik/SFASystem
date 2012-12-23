using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// City object for NHibernate mapped table 'City'.
	/// </summary>
	[Serializable]
	public class City : IEntity
	{
		public City() {

        }

        public virtual Guid CityID { get; set; }
        public virtual string Name { get; set; }
		
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
			this.CityID == castObj.CityID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * CityID.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
