using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SFASystem.Core.Common;

namespace SFASystem.Core.DataAccess
{
    class RoleDB
    {
        public static Role InsertRole(Role role)
        {
            string sqlQuery = "INSERT INTO ROLE(Name) VALUES(@Name);SELECT @@Identity";

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            
            db.AddInParameter(dbCommand, "Name", DbType.String, role.Name);
          
            role.RoleID = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return role;
        }

        public static void UpdateRole(Role role)
        {
            string sqlQuery = "UPDATE ROLE SET Name=@Name WHERE RoleID=" + role.RoleID;

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "Name", DbType.String, role.Name);
            db.ExecuteNonQuery(dbCommand);
        }

        public static IList<Role> GetRoles()
        {
            string sqlQuery = "SELECT * FROM ROLE";
            return GetRoleListFromQuery(sqlQuery);
        }

        public static IList<Role> GetRolesForEmployee(int employeeID)
        {
            string sqlQuery = "SELECT * FROM ROLE role INNER JOIN EMPLOYEEROLES emprol ON role.RoleID=emprol.RoleID WHERE emprol.EmployeeID="+employeeID.ToString();
            return GetRoleListFromQuery(sqlQuery);
        }


        public static Role GetRoleByID(int roleID)
        {
            Role role = null;
            if (roleID == 0)
                return role;
            string sqlQuery = "SELECT * FROM ROLE WHERE RoleID=" + roleID.ToString();
            return GetRoleFromQuery(sqlQuery);
        }

        public static Role GetRoleByName(string name)
        {
            string sqlQuery = "SELECT * FROM ROLE WHERE Name='" + name + "'";
            return GetRoleFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Role> GetRoleListFromQuery(string sqlQuery)
        {
            IList<Role> listRole = new List<Role>();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listRole.Add(GetRoleFromReader(dataReader));
                }
            }
            return listRole;
        }



        private static Role GetRoleFromQuery(string sqlQuery)
        {
            Role role = null;
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    role = GetRoleFromReader(dataReader);
                }
            }
            return role;
        }

        private static Role GetRoleFromReader(IDataReader dataReader)
        {
            Role role = new Role();
            role.RoleID = DBHelper.GetInt(dataReader, "RoleID");
            role.Name = DBHelper.GetString(dataReader, "Name");
            return role;
        }

        #endregion
    }
}
