using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.Core.Common
{
    public class Task
    {
        #region Ctor

        public Task()
        {
        }

        #endregion

        #region Properties

        public int TaskID { get; set; }
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public int GivenBy { get; set; }
        public int ApprovedBy { get; set; }
        public string FullDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateToEndTask { get; set; }
        public DateTime DateExecuted { get; set; }
        public bool IsApproved { get; set; }
        public TaskStatus TaskStatus { get; set; }

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

    public enum TaskStatus
    {
        New = 0,
        Open = 1,
        Executed = 2,
        Canceled =3
    }
}
