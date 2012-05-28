using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using System.Data.Common;
using SFASystem.Pocket.Core.DataAccess;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{
    internal class DictionaryDB
    {
        public static IList<Dictionary> GetDictionarys()
        {
            string sqlQuery = "SELECT * FROM Dictionary";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetDictionaryListFromQuery(sqlQuery);
        }

        public static Dictionary GetDictionaryByID(Guid dictionaryID)
        {
            Dictionary Dictionary = null;
            if (dictionaryID == Guid.Empty)
                return Dictionary;

            string sqlQuery = "SELECT * FROM Dictionary WHERE DictionaryID='" + dictionaryID + "'";
            return GetDictionaryFromQuery(sqlQuery);
        }

        public static Dictionary GetDictionaryByNumber(int dictNumber, string typeName)
        {
            string sqlQuery = "SELECT * FROM Dictionary dict JOIN DictionaryType type on dict.DictionaryTypeID=type.DictionaryTypeID WHERE DictionaryNumber=" 
                + dictNumber.ToString()+ " AND type.Name='"+typeName+"'";
            return GetDictionaryFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Dictionary> GetDictionaryListFromQuery(string sqlQuery)
        {
            IList<Dictionary> listDictionary = new List<Dictionary>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listDictionary.Add(GetDictionaryFromReader(dataReader));
                }
            }
            return listDictionary;
        }

        private static Dictionary GetDictionaryFromQuery(string sqlQuery)
        {
            Dictionary Dictionary = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Dictionary = GetDictionaryFromReader(dataReader);
                }
            }
            return Dictionary;
        }

        private static Dictionary GetDictionaryFromReader(IDataReader dataReader)
        {
            Dictionary dictionary = new Dictionary();
            dictionary.DictionaryID = DBHelper.GetGuid(dataReader, "DictionaryID");
            dictionary.DictionaryTypeID = DBHelper.GetGuid(dataReader, "DictionaryTypeID");
            dictionary.Value = DBHelper.GetString(dataReader, "Value");
            dictionary.DictionaryNumber = DBHelper.GetByte(dataReader, "DictionaryNumber");
            return dictionary;
        }

        #endregion

        internal static IList<Dictionary> GetDictionariesByType(string typeName)
        {
            if (typeName == string.Empty)
                return null;
            string sqlQuery = "SELECT * FROM Dictionary dict JOIN DictionaryType type on dict.DictionaryTypeID=type.DictionaryTypeID WHERE type.Name='" + typeName + "'";
            return GetDictionaryListFromQuery(sqlQuery);
        }
    }
}
