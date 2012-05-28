using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class CountryDB
    {
        public static Country InsertCountry(Country country)
        {
            string sqlQuery = "INSERT INTO Country(CountryID,Name) " +
                " VALUES(@CountryID,@Name)";

            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "CountryID", DbType.Guid, country.CountryID);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, country.Name);

            return country;
        }

        public static void UpdateCountry(Country country)
        {
            string sqlQuery = "UPDATE Country SET Name=@Name WHERE CountryID='" + country.CountryID+"'";

            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, country.Name);

            DBHelper.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteCountry(int countryID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE CountryID = " + countryID.ToString();
        //    
        //    DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
        //    if (DBHelper.ExecuteNonQuery(dbCommand) > 0)
        //        return true;
        //    else
        //        return false;
        //}

        public static IList<Country> GetCountries()
        {
            string sqlQuery = "SELECT * FROM Country";
            return GetCountryListFromQuery(sqlQuery);
        }


        public static Country GetCountryByID(Guid countryID)
        {
            Country country = null;
            if (countryID == Guid.Empty)
                return country;
            string sqlQuery = "SELECT * FROM Country WHERE CountryID='" + countryID.ToString()+"'";
            return GetCountryFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Country> GetCountryListFromQuery(string sqlQuery)
        {
            IList<Country> listCountry = new List<Country>();
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listCountry.Add(GetCountryFromReader(dataReader));
                }
            }
            return listCountry;
        }

        private static Country GetCountryFromQuery(string sqlQuery)
        {
            Country country = null;
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    country = GetCountryFromReader(dataReader);
                }
            }
            return country;
        }

        private static Country GetCountryFromReader(IDataReader dataReader)
        {
            Country country = new Country();
            country.CountryID = DBHelper.GetGuid(dataReader, "CountryID");
            country.Name = DBHelper.GetString(dataReader, "Name");

            return country;
        }

        #endregion
    }
}
