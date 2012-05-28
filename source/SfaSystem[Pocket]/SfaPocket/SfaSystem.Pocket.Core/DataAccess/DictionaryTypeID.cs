using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;
using System.Data;
using System.Data.Common;

namespace SFASystem.Pocket.Core.DataAccess
{
    internal class DictionaryTypeTypeID
    {
        public static IList<DictionaryType> GetDictionaryTypes()
        {
            string sqlQuery = "SELECT * FROM DictionaryType";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetDictionaryTypeListFromQuery(sqlQuery);
        }

        public static DictionaryType GetDictionaryTypeByID(Guid dictionaryTypeID)
        {
            DictionaryType DictionaryType = null;
            if (dictionaryTypeID == Guid.Empty)
                return DictionaryType;

            string sqlQuery = "SELECT * FROM DictionaryType WHERE DictionaryTypeID='" + dictionaryTypeID + "'";
            return GetDictionaryTypeFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<DictionaryType> GetDictionaryTypeListFromQuery(string sqlQuery)
        {
            IList<DictionaryType> listDictionaryType = new List<DictionaryType>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listDictionaryType.Add(GetDictionaryTypeFromReader(dataReader));
                }
            }
            return listDictionaryType;
        }

        private static DictionaryType GetDictionaryTypeFromQuery(string sqlQuery)
        {
            DictionaryType DictionaryType = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DictionaryType = GetDictionaryTypeFromReader(dataReader);
                }
            }
            return DictionaryType;
        }

        private static DictionaryType GetDictionaryTypeFromReader(IDataReader dataReader)
        {
            DictionaryType dictionaryType = new DictionaryType();
            dictionaryType.DictionaryTypeID = DBHelper.GetGuid(dataReader, "DictionaryTypeID");
            dictionaryType.Name = DBHelper.GetString(dataReader, "Name");
            return dictionaryType;
        }

        #endregion
    }
}
