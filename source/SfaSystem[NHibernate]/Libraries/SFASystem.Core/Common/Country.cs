using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.Core.Common
{
    public class Country
    {
        #region Ctor

        public Country()
        {
        }

        #endregion

        #region Properties

        public int CountryID { get; set; }
        public string Name { get; set; }

        #endregion

        #region Custom Properties

        #endregion

        //#region object overrides
        //public override bool Equals(object obj)
        //{
        //    throw new NotImplementedException();
        //    //if (obj is Category)
        //    //{
        //    //    Category compareTo = (Category)obj;
        //    //    return compareTo.ID == this.ID;
        //    //}
        //    //else
        //    //{
        //    //    return base.Equals(obj);
        //    //}
        //}

        //public override string ToString()
        //{
        //    throw new NotImplementedException();
        //    //return this.Name;
        //}
        //public override int GetHashCode()
        //{
        //    throw new NotImplementedException();
        //    //return this.ID.GetHashCode();
        //}
        //#endregion
    }
}
