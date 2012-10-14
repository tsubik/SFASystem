/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// Dictionary object for NHibernate mapped table 'Dictionary'.
	/// </summary>
	[Serializable]
	public class Dictionary
	{
		#region Member Variables
		protected Guid dictionaryid;
        protected Guid dictionarytypeid;
		protected DictionaryType dictionarytype;
		protected string _value;
		protected byte dictionarynumber;
        protected bool isdeleted;
		#endregion
		#region Constructors
			
		public Dictionary() {
            //this.dictionaryid = Guid.NewGuid();
            //this.dictionarytype = null;
            //this.value = string.Empty;
            //this.dictionarynumber = 0;
        }
					
		public Dictionary(Guid dictionaryid, DictionaryType dictionarytype, string value, byte dictionarynumber) 
		{
			this.dictionaryid= dictionaryid;
			this.dictionarytype= dictionarytype;
			this._value= value;
			this.dictionarynumber= dictionarynumber;
		}

		#endregion
		#region Public Properties
		public  virtual Guid DictionaryID
		{
			get { return dictionaryid; }
			set {dictionaryid= value; }
		}
        public virtual Guid DictionaryTypeID
        {
            get { return dictionarytypeid; }
            set { dictionarytypeid = value; }
        }
		public  virtual DictionaryType DictionaryType
		{
			get { return dictionarytype; }
			set {dictionarytype= value; }
		}
		public  virtual string Value
		{
			get { return _value; }
			set { _value = value; }
		}
		public  virtual byte DictionaryNumber
		{
			get { return dictionarynumber; }
			set {dictionarynumber= value; }
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
			Dictionary castObj = (Dictionary)obj;
			return ( castObj != null ) &&
			this.dictionaryid == castObj.DictionaryID;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * dictionaryid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
