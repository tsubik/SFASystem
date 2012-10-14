using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Pocket.Core.Common;
using System.Data.Common;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class TerritoryDB
    {
        public static Territory InsertTerritory(Territory territory)
        {
            string sqlQuery = "INSERT INTO Territory(TerritoryID,ParentTerritoryID,FullDescription,Name) " +
                " VALUES(@TerritoryID,@ParentTerritoryID,@FullDescription,@Name);SELECT @@Identity";
            if (territory.TerritoryID == Guid.Empty)
                territory.TerritoryID = Guid.NewGuid();
            else
                return null;
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "TerritoryID", DbType.Guid, territory.TerritoryID);
            DBHelper.AddInParameter(dbCommand, "ParentTerritoryID", DbType.Guid, territory.ParentTerritoryID);
            DBHelper.AddInParameter(dbCommand, "FullDescription", DbType.String, territory.FullDescription);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, territory.Name);

            return territory;
        }

        public static void UpdateTerritory(Territory territory)
        {
            string sqlQuery = "UPDATE Territory SET ParentTerritoryID=@ParentTerritoryID, FullDescription=@FullDescription, Name=@Name WHERE TerritoryID='" + territory.TerritoryID+"'";

            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "ParentTerritoryID", DbType.Guid, territory.ParentTerritoryID);
            DBHelper.AddInParameter(dbCommand, "FullDescription", DbType.String, territory.FullDescription);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, territory.Name);

            DBHelper.ExecuteNonQuery(dbCommand);
        }

        //public static bool DeleteTerritory(int territoryID)
        //{
        //    string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE TerritoryID = " + territoryID.ToString();
        //    
        //    DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
        //    if (DBHelper.ExecuteNonQuery(dbCommand) > 0)
        //        return true;
        //    else
        //        return false;
        //}

        public static IList<Territory> GetTerritories()
        {
            string sqlQuery = "SELECT * FROM Territory";
            return GetTerritoryListFromQuery(sqlQuery);
        }
        internal static IList<Territory> GetSubTerritories(Guid TerritoryID)
        {
            string sqlQuery = "SELECT * FROM Territory ";
            if (TerritoryID == Guid.Empty)
                sqlQuery += " WHERE ParentTerritoryID IS NULL";
            else
                sqlQuery += " WHERE ParentTerritoryID = '" + TerritoryID + "'";

            return GetTerritoryListFromQuery(sqlQuery);
        }

        public static Territory GetTerritoryByID(Guid territoryID)
        {
            Territory territory = null;
            if (territoryID == Guid.Empty)
                return territory;
            string sqlQuery = "SELECT * FROM Territory WHERE TerritoryID='" + territoryID.ToString()+"'";
            return GetTerritoryFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Territory> GetTerritoryListFromQuery(string sqlQuery)
        {
            IList<Territory> listTerritory = new List<Territory>();
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            territory.TerritoryID = DBHelper.GetGuid(dataReader, "TerritoryID");
            territory.ParentTerritoryID = DBHelper.GetGuid(dataReader, "ParentTerritoryID");
            territory.Name = DBHelper.GetString(dataReader, "Name");
            territory.FullDescription = DBHelper.GetString(dataReader, "FullDescription");
            return territory;
        }

        #endregion

        
    }
}
