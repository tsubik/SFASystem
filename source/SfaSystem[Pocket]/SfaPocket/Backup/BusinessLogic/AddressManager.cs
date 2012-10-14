using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class AddressManager
    {
        public static Address InsertAddress(Address address)
        {
            return AddressDB.InsertAddress(address);
        }

        public static void UpdateAddress(Address address)
        {
            AddressDB.UpdateAddress(address);
        }

        public static Address GetAddressByID(Guid addressID)
        {
            return AddressDB.GetAddressByID(addressID);
        }

        public static City GetCityByID(Guid cityID)
        {
            return CityDB.GetCityByID(cityID);
        }
        public static IList<City> GetCities()
        {
            return CityDB.GetCities();
        }
        public static Country GetCountryByID(Guid countryID)
        {
            return CountryDB.GetCountryByID(countryID);
        }
        public static IList<Country> GetCountries()
        {
            return CountryDB.GetCountries();
        }
        public static Country InsertCountry(Country country)
        {
            return CountryDB.InsertCountry(country);
        }
        public static City InsertCity(City city)
        {
            return CityDB.InsertCity(city);
        }
        public static void UpdateCountry(Country country)
        {
            CountryDB.UpdateCountry(country);
        }
        public static IList<City> GetCitiesLikeName(string prefName)
        {
            return CityDB.GetCitiesLikeName(prefName);
        }
    }
}
