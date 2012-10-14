using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class CityDB
    {
        public static City InsertCity(City city)
        {
            string sqlQuery = "INSERT INTO City(CityID,Name) " +
                " VALUES(@CityID,@Name)";
            if (city.CityID == Guid.Empty)
                city.CityID = Guid.NewGuid();
            else
                return null;
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "CityID", DbType.Guid, city.CityID);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, city.Name);
            
            return city;
        }

        public static void UpdateCity(City city)
        {
            string sqlQuery = "UPDATE City SET Name=@Name WHERE CityID='" + city.CityID+"'";

            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, city);

            DBHelper.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteCity(int cityID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE CityID = " + cityID.ToString();
        //    
        //    DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
        //    if (DBHelper.ExecuteNonQuery(dbCommand) > 0)
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

        public static City GetCityByID(Guid cityID)
        {
            City city = null;
            if (cityID == Guid.Empty)
                return city;
            string sqlQuery = "SELECT * FROM City WHERE CityID='" + cityID.ToString()+"'";
            return GetCityFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<City> GetCityListFromQuery(string sqlQuery)
        {
            IList<City> listCity = new List<City>();
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            city.CityID = DBHelper.GetGuid(dataReader, "CityID");
            city.Name = DBHelper.GetString(dataReader, "Name");

            return city;
        }      

        #endregion

    }
}
