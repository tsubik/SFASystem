using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using SFASystem.DataAccess.SqlServerNH;

namespace SFASystem.Services
{
    public static class CountryService
    {
        public static IList<Country> GetAllCountries()
        {
            Repository<Country, Guid> rep = new Repository<Country, Guid>();
            return rep.GetAll();
        }
    }
}
