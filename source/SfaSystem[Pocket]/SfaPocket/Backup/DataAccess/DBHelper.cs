using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Data.Common;
using SFASystem.Pocket.Utils;

namespace SFASystem.Pocket.Core.DataAccess
{
    /// <summary>
    /// SqlHelper zawiera metody pomocne przy wykonywaniu zapytań dla serwera bazy danych SQL Server
    /// </summary>
    public static class DBHelper
    {
        #region Connection string bazy danych

        private static string connectionStringName = "SFASqlCeConnection";

        public static String GetConnectionString()
        {
            return Settings.DatabaseConnectionString;
        }

        #endregion

        public static DbCommand GetDBCommand()
        {
            return new SqlCeCommand();
        }
        public static DbCommand GetDBCommand(string sqlQuery)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlQuery;
            return cmd;
        }

        #region Conversion Methods

        public static bool GetBoolean(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(rdr[index]);
        }

        public static byte[] GetBytes(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }

        public static byte GetByte(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
                return 0;
            return (byte)rdr[index];
        }

        public static DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return (DateTime)rdr[index];
        }

        public static DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }

        public static decimal GetDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }

        public static double GetDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }

        public static Guid GetGuid(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }

        public static int GetInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (int)rdr[index];
        }

        public static int? GetNullableInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }

        public static string GetString(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index];
        }
        #endregion

        #region DbCommand Helpers

        public static void AddInParameter(DbCommand cmd, string paramName, DbType type, object value)
        {
            DbParameter param = cmd.CreateParameter();
            param.Value = (value == null) ? DBNull.Value : value;
            param.DbType = type;
            param.ParameterName = paramName;
            cmd.Parameters.Add(param);
        }

        #endregion

        #region Executing queries

        /// <summary>
        /// Wykonuje komende SQL nie zwracająca Zbioru danych, może zwracać skalar int
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlCeParameter[] cmdParameters)
        {
            DbCommand cmd = GetDBCommand();
            using (SqlCeConnection conn = new SqlCeConnection(DBHelper.GetConnectionString()))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(DbCommand cmd)
        {
            using(SqlCeConnection conn = new SqlCeConnection(DBHelper.GetConnectionString()))
            {
                PrepareCommand(cmd, conn, null);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Wykonuje zapytanie ktore zwraca wynik w postaci reader'a
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static DbDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlCeParameter[] cmdParams)
        {
            DbCommand cmd = GetDBCommand();
            SqlCeConnection conn = new SqlCeConnection(DBHelper.GetConnectionString());
            
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        /// <summary>
        /// Wykonuje zapytanie ktore zwraca wynik w postaci reader'a
        /// </summary>
        /// <returns></returns>
        public static DbDataReader ExecuteReader(DbCommand cmd)
        {
            SqlCeConnection conn = new SqlCeConnection(DBHelper.GetConnectionString());

            try
            {
                PrepareCommand(cmd, conn, null);
                DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// Wykonuje komende zwracajaca jeden obiekt, pierwsza kolumna w pierwszym wierszu rekordset'a
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlCeParameter[] cmdParams)
        {
            DbCommand cmd = GetDBCommand();

            using (SqlCeConnection conn = new SqlCeConnection(DBHelper.GetConnectionString()))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Wykonuje komende zwracajaca jeden obiekt, pierwsza kolumna w pierwszym wierszu rekordset'a
        /// </summary>
        /// <returns></returns>
        public static object ExecuteScalar(DbCommand cmd)
        {
            using (SqlCeConnection conn = new SqlCeConnection(DBHelper.GetConnectionString()))
            {
                PrepareCommand(cmd, conn, null);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        #endregion

        /// <summary>
        /// Przygotowywuje komende do realizacji
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        private static void PrepareCommand(DbCommand cmd, SqlCeConnection conn, SqlCeTransaction trans, CommandType cmdType, string cmdText, SqlCeParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;
            if (cmdParams != null)
            {
                foreach (SqlCeParameter parm in cmdParams)
                {
                    cmd.Parameters.Add(parm);
                }
            }

        }

        private static void PrepareCommand(DbCommand cmd, SqlCeConnection conn, SqlCeTransaction trans)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;

            if (trans != null)
                cmd.Transaction = trans;
        }


        public static string CreateSQLQuery(string query, SqlCeParameter[] sqlParams)
        {
            string resultQuery = query;

            foreach (SqlCeParameter p in sqlParams)
            {
                if (p.DbType == DbType.String || p.DbType == DbType.DateTime || p.DbType == DbType.Time)
                    resultQuery = resultQuery.Replace("@" + p.ParameterName, "'" + p.Value.ToString() + "'");
                else
                    resultQuery = resultQuery.Replace("@" + p.ParameterName, Convert.ChangeType(p.Value, ConvertType(p.DbType), null).ToString());
            }
            return resultQuery;
        }

        private static Type ConvertType(DbType dbType)
        {
            Type toReturn = typeof(DBNull);

            switch (dbType)
            {
                case DbType.String:
                    toReturn = typeof(string);
                    break;

                case DbType.UInt64:
                    toReturn = typeof(UInt64);
                    break;

                case DbType.Int64:
                    toReturn = typeof(Int64);
                    break;

                case DbType.Int32:
                    toReturn = typeof(Int32);
                    break;

                case DbType.UInt32:
                    toReturn = typeof(UInt32);
                    break;

                case DbType.Single:
                    toReturn = typeof(float);
                    break;

                case DbType.Date:
                    toReturn = typeof(DateTime);
                    break;

                case DbType.DateTime:
                    toReturn = typeof(DateTime);
                    break;

                case DbType.Time:
                    toReturn = typeof(DateTime);
                    break;

                case DbType.StringFixedLength:
                    toReturn = typeof(string);
                    break;

                case DbType.UInt16:
                    toReturn = typeof(UInt16);
                    break;

                case DbType.Int16:
                    toReturn = typeof(Int16);
                    break;

                case DbType.SByte:
                    toReturn = typeof(byte);
                    break;

                case DbType.Object:
                    toReturn = typeof(object);
                    break;

                case DbType.AnsiString:
                    toReturn = typeof(string);
                    break;

                case DbType.AnsiStringFixedLength:
                    toReturn = typeof(string);
                    break;

                case DbType.VarNumeric:
                    toReturn = typeof(decimal);
                    break;

                case DbType.Currency:
                    toReturn = typeof(double);
                    break;

                case DbType.Binary:
                    toReturn = typeof(byte[]);
                    break;

                case DbType.Decimal:
                    toReturn = typeof(decimal);
                    break;

                case DbType.Double:
                    toReturn = typeof(Double);
                    break;

                case DbType.Guid:
                    toReturn = typeof(Guid);
                    break;

                case DbType.Boolean:
                    toReturn = typeof(bool);
                    break;
            }

            return toReturn;
        }
    }
}
