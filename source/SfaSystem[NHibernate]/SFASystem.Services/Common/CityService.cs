using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using SFASystem.DataAccess.SqlServerNH;

namespace SFASystem.Services
{
    public static class CityService
    {
        private static CityRepository cityRepository;

        static CityService()
        {
            cityRepository = new CityRepository();
        }

        public static City GetCityOrCreateNew(string cityName)
        {
            IList<City> cities = CityService.GetCitiesLikeName(cityName);
            City city = null;
            if (cities.Count == 0)
            {
                city = new City();
                city.Name = cityName;
            }
            else
                city = cities[0];

            return city;
        }

        public static IList<City> GetCitiesLikeName(string name)
        {
            return cityRepository.GetCitiesStartsWith(name);
        }
        public static IList<City> GetCitiesLikeName(string name, int max)
        {
            return cityRepository.GetCitiesStartsWith(name, max);
        }
    }
}
