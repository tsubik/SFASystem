using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.Core.Common
{
    public class Role
    {
        #region Ctor

        public Role()
        {

        }

        #endregion

        #region Properties

        public int RoleID { get; set; }
        public string Name { get; set; }

        #endregion

        #region Custom Properties

        #endregion

        //#region object overrides
        public override bool Equals(object obj)
        {
            
            if (obj is Role)
            {
                Role compareTo = (Role)obj;
                return compareTo.RoleID == this.RoleID;
            }
            else
            {
                return base.Equals(obj);
            }
        }

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
