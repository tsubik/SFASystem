using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Core.BusinessLogic;

namespace SFASystem.Core.Common
{
    public class Employee
    {
        #region Ctor

        public Employee()
        {

        }

        #endregion

        #region Properties

        public int EmployeeID { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Active { get; set; }
        public int? TerritoryID { get; set; }
        public int? AddressID { get; set; }
        public int? ManagerID { get; set; }
        public int? ContactID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastActivityDate { get; set; }

        #endregion

        #region Custom Properties

        //private  _address = null;
        //public Address Address
        //{
        //    get
        //    {
        //        if (_address == null)
        //        {

        //            if (AddressID.HasValue)
        //                _address = AddressManager.GetAddressByID(AddressID.Value);
        //        }
        //        return _address;
        //    }
        //}

        private Address _address = null;
        public Address Address
        {
            get
            {
                if (_address == null)
                {
            
                    if(AddressID.HasValue)
                        _address = AddressManager.GetAddressByID(AddressID.Value);
                }
                return _address;
            }
        }

        private Employee _manager = null;
        public Employee Manager
        {
            get
            {
                if (_manager == null)
                {
                    if (ManagerID.HasValue)
                        _manager = EmployeeManager.GetEmployeeByID(ManagerID.Value);
                }
                return _manager;
            }
        }

        private Contact _contact = null;
        public Contact Contact
        {
            get
            {
                if (_contact == null)
                {
                    if (ContactID.HasValue)
                        _contact = ContactManager.GetContactByID(ContactID.Value);
                }
                return _contact;
            }
        }


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
        ////public override int GetHashCode()
        ////{
        ////    throw new NotImplementedException();
        ////    //return this.ID.GetHashCode();
        ////}
        //#endregion
    }
}
