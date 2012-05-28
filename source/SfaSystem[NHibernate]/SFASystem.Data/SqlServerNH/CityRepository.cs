using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class CityRepository : BaseRepository<City, Guid>
    {
        public IList<City> GetCitiesStartsWith(string name)
        {
            ISession session = HBManager.Instance.GetSession();

            var query = from city in GetQueryable()
                        where city.Name.StartsWith(name)
                        orderby city.Name ascending
                        select city;
            return query.ToList();
        }
        public IList<City> GetCitiesStartsWith(string name, int max)
        {
            ISession session = HBManager.Instance.GetSession();

            var query = from city in GetQueryable()
                        where city.Name.StartsWith(name)
                        orderby city.Name ascending
                        select city;
            return query.Take(max).ToList();
        }
    }
}
