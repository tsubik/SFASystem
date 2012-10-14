/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// Country object for NHibernate mapped table 'Country'.
	/// </summary>
	[Serializable]
	public class Country
	{
		#region Member Variables
		protected Guid countryid;
		protected string name;
		#endregion
		#region Constructors
			
		public Country() {
            //this.countryid = Guid.NewGuid();
            //this.name = string.Empty;
        }
					
		public Country(Guid countryid, string name) 
		{
			this.countryid= countryid;
			this.name= name;
		}

		#endregion
		#region Public Properties
		public  virtual Guid CountryID
		{
			get { return countryid; }
			set {countryid= value; }
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
			Country castObj = (Country)obj;
			return ( castObj != null ) &&
			this.countryid == castObj.CountryID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * countryid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
