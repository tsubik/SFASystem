using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SFASystem.Core.Common;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace SFASystem.Core.DataAccess
{
    public class TerritoryDB
    {
        public static Territory InsertTerritory(Territory territory)
        {
            string sqlQuery = "INSERT INTO Territory(ParentTerritoryID,FullDescription,Name) " +
                " VALUES(@ParentTerritoryID,@FullDescription,@Name);SELECT @@Identity";

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "ParentTerritoryID", DbType.Int32, territory.ParentTerritoryID);
            db.AddInParameter(dbCommand, "FullDescription", DbType.String, territory.FullDescription);
            db.AddInParameter(dbCommand, "Name", DbType.String, territory.Name);

            territory.TerritoryID = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return territory;
        }

        public static void UpdateTerritory(Territory territory)
        {
            string sqlQuery = "UPDATE Territory SET ParentTerritoryID=@ParentTerritoryID, FullDescription=@FullDescription, Name=@Name WHERE TerritoryID=" + territory.TerritoryID;

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "ParentTerritoryID", DbType.Int32, territory.ParentTerritoryID);
            db.AddInParameter(dbCommand, "FullDescription", DbType.String, territory.FullDescription);
            db.AddInParameter(dbCommand, "Name", DbType.String, territory.Name);

            db.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteTerritory(int territoryID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE TerritoryID = " + territoryID.ToString();
        //    Database db = new SqlDatabase(DBHelper.GetConnectionString());
        //    DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
        //    if (db.ExecuteNonQuery(dbCommand) > 0)
        //        return true;
        //    else
        //        return false;
        //}

        public static IList<Territory> GetTerritories()
        {
            string sqlQuery = "SELECT * FROM Territory";
            return GetTerritoryListFromQuery(sqlQuery);
        }


        public static Territory GetTerritoryByID(int territoryID)
        {
            Territory territory = null;
            if (territoryID == 0)
                return territory;
            string sqlQuery = "SELECT * FROM Territory WHERE TerritoryID=" + territoryID.ToString();
            return GetTerritoryFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Territory> GetTerritoryListFromQuery(string sqlQuery)
        {
            IList<Territory> listTerritory = new List<Territory>();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listTerritory.Add(GetTerritoryFromReader(dataReader));
                }
            }
            return listTerritory;
        }

        private static Territory GetTerritoryFromQuery(string sqlQuery)
        {
            Territory territory = null;
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    territory = GetTerritoryFromReader(dataReader);
                }
            }
            return territory;
        }

        private static Territory GetTerritoryFromReader(IDataReader dataReader)
        {
            Territory territory = new Territory();
            territory.TerritoryID = DBHelper.GetInt(dataReader, "TerritoryID");
            territory.ParentTerritoryID = DBHelper.GetInt(dataReader, "ParentTerritoryID");
            territory.Name = DBHelper.GetString(dataReader, "Name");
            territory.FullDescription = DBHelper.GetString(dataReader, "FullDescription");
            return territory;
        }

        #endregion
    }
}
