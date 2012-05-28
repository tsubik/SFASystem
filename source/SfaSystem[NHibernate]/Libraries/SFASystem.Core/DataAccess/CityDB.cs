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
    public class CityDB
    {
        public static City InsertCity(City city)
        {
            string sqlQuery = "INSERT INTO City(Name) " +
                " VALUES(@Name);SELECT @@Identity";

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "Name", DbType.String, city.Name);
            city.CityID = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return city;
        }

        public static void UpdateCity(City city)
        {
            string sqlQuery = "UPDATE City SET Name=@Name WHERE CityID=" + city.CityID;

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "Name", DbType.String, city);

            db.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteCity(int cityID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE CityID = " + cityID.ToString();
        //    Database db = new SqlDatabase(DBHelper.GetConnectionString());
        //    DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
        //    if (db.ExecuteNonQuery(dbCommand) > 0)
        //        return true;
        //    else
        //        return false;
        //}

        public static IList<City> GetCities()
        {
            string sqlQuery = "SELECT * FROM City";
            return GetCityListFromQuery(sqlQuery);
        }

        public static IList<City> GetCitiesLikeName(string prefName)
        {
            string sqlQuery = "SELECT * FROM City WHERE Name Like '"+prefName+"%'";
            return GetCityListFromQuery(sqlQuery);
        }

        public static City GetCityByID(int cityID)
        {
            City city = null;
            if (cityID == 0)
                return city;
            string sqlQuery = "SELECT * FROM City WHERE CityID=" + cityID.ToString();
            return GetCityFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<City> GetCityListFromQuery(string sqlQuery)
        {
            IList<City> listCity = new List<City>();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listCity.Add(GetCityFromReader(dataReader));
                }
            }
            return listCity;
        }

        private static City GetCityFromQuery(string sqlQuery)
        {
            City city = null;
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    city = GetCityFromReader(dataReader);
                }
            }
            return city;
        }

        private static City GetCityFromReader(IDataReader dataReader)
        {
            City city = new City();
            city.CityID = DBHelper.GetInt(dataReader, "CityID");
            city.Name = DBHelper.GetString(dataReader, "Name");

            return city;
        }      

        #endregion

    }
}
