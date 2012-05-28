/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Pocket.Core.Common
{
	/// <summary>
	/// Image object for NHibernate mapped table 'Image'.
	/// </summary>
	[Serializable]
	public class Image
	{
		#region Member Variables
		protected Guid imageid;
		//protected ImageType imagetype;
		protected byte[] file;
		#endregion
		#region Constructors
			
		public Image() {
            //this.imageid = Guid.NewGuid();
            //this.imagetype = null;
            //this.file = null;
        }
					
		public Image(Guid imageid, /*ImageType imagetype,*/ byte[] file) 
		{
			this.imageid= imageid;
			//this.imagetype= imagetype;
			this.file= file;
		}

		#endregion
		#region Public Properties
		public  virtual Guid Imageid
		{
			get { return imageid; }
			set {imageid= value; }
		}
        //public  virtual ImageType ImageType
        //{
        //    get { return imagetype; }
        //    set {imagetype= value; }
        //}
		public  virtual byte[] File
		{
			get { return file; }
			set {file= value; }
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
			Image castObj = (Image)obj;
			return ( castObj != null ) &&
			this.imageid == castObj.Imageid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * imageid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
