/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
	/// <summary>
	/// ImageType object for NHibernate mapped table 'ImageType'.
	/// </summary>
	[Serializable]
	public class ImageType
	{
		#region Member Variables
		protected Guid imagetypeid;
		protected int width;
		protected string name;
		protected int height;
		#endregion
		#region Constructors
			
		public ImageType() {
            //this.imagetypeid = Guid.NewGuid();
            //this.width = 0;
            //this.height = 0;
            //this.name = string.Empty;
                
        }
					
		public ImageType(Guid imagetypeid, int width, string name, int height) 
		{
			this.imagetypeid= imagetypeid;
			this.width= width;
			this.name= name;
			this.height= height;
		}

		#endregion
		#region Public Properties
		public  virtual Guid ImageTypeid
		{
			get { return imagetypeid; }
			set {imagetypeid= value; }
		}
		public  virtual int Width
		{
			get { return width; }
			set {width= value; }
		}
		public  virtual string Name
		{
			get { return name; }
			set {name= value; }
		}
		public  virtual int Height
		{
			get { return height; }
			set {height= value; }
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
			ImageType castObj = (ImageType)obj;
			return ( castObj != null ) &&
			this.imagetypeid == castObj.ImageTypeid;
		}
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 57;
			hash = 27 * hash * imagetypeid.GetHashCode();
			return hash;
		}
		#endregion
		
	}
}
