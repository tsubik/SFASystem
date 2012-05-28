/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// DictionaryType object for NHibernate mapped table 'DictionaryType'.
	/// </summary>
	[Serializable]
	public class DictionaryType
	{
		#region Member Variables
		protected Guid dictionarytypeid;
		protected string name;

        protected IList<Dictionary> dictionaryList;

		#endregion
		#region Constructors
			
		public DictionaryType() {
            //this.dictionarytypeid = Guid.NewGuid();
            //this.name = string.Empty;
        }
					
		public DictionaryType(Guid dictionarytypeid, string name) 
		{
			this.dictionarytypeid= dictionarytypeid;
			this.name= name;
		}

		#endregion
		#region Public Properties
		public  virtual Guid DictionaryTypeID
		{
			get { return dictionarytypeid; }
			set {dictionarytypeid= value; }
		}
		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
		}
        public virtual IList<Dictionary> Dictionaries
        {
            get { return dictionaryList; }
            set { dictionaryList = value; }
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
			DictionaryType castObj = (DictionaryType)obj;
			return ( castObj != null ) &&
			this.dictionarytypeid == castObj.DictionaryTypeID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * dictionarytypeid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
