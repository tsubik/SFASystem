using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using SFASystem.Core.Common;

namespace SFASystem.Core.DataAccess
{
    public class CountryDB
    {
        public static Country InsertCountry(Country country)
        {
            string sqlQuery = "INSERT INTO Country(Name) " +
                " VALUES(@Name);SELECT @@Identity";

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "Name", DbType.String, country.Name);
            country.CountryID = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return country;
        }

        public static void UpdateCountry(Country country)
        {
            string sqlQuery = "UPDATE Country SET Name=@Name WHERE CountryID=" + country.CountryID;

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "Name", DbType.String, country.Name);

            db.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteCountry(int countryID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE CountryID = " + countryID.ToString();
        //    Database db = new SqlDatabase(DBHelper.GetConnectionString());
        //    DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
        //    if (db.ExecuteNonQuery(dbCommand) > 0)
        //        return true;
        //    else
        //        return false;
        //}

        public static IList<Country> GetCountries()
        {
            string sqlQuery = "SELECT * FROM Country";
            return GetCountryListFromQuery(sqlQuery);
        }


        public static Country GetCountryByID(int countryID)
        {
            Country country = null;
            if (countryID == 0)
                return country;
            string sqlQuery = "SELECT * FROM Country WHERE CountryID=" + countryID.ToString();
            return GetCountryFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Country> GetCountryListFromQuery(string sqlQuery)
        {
            IList<Country> listCountry = new List<Country>();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
            country.CountryID = DBHelper.GetInt(dataReader, "CountryID");
            country.Name = DBHelper.GetString(dataReader, "Name");

            return country;
        }

        #endregion
    }
}
