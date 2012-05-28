using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Core.BusinessLogic;

namespace SFASystem.Core.Common
{
    public class Address
    {
        #region Ctor

        public Address()
        {

        }

        #endregion

        #region Properties

        public int AddressID { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        //public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string HouseNr { get; set; }
        public string ApartmentNr { get; set; }

        #endregion

        #region Custom Properties

        private Country _country = null;
        public Country Country
        {
            get
            {
                if (_country == null)
                    _country = AddressManager.GetCountryByID(CountryID);
                return _country;
            }
        }

        private City _city = null;
        public City City
        {
            get
            {
                if (_city == null)
                    _city = AddressManager.GetCityByID(CityID);
                return _city;
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
        //public override int GetHashCode()
        //{
        //    throw new NotImplementedException();
        //    //return this.ID.GetHashCode();
        //}
        //#endregion
    }
}
