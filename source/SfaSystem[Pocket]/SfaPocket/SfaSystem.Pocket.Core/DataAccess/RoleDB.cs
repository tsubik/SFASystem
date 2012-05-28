using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.Core.DataAccess
{
    class RoleDB
    {
        public static Role InsertRole(Role role)
        {
            string sqlQuery = "INSERT INTO ROLE(RoleID,Name) VALUES(@RoleID,@Name)";
            if (role.RoleID == Guid.Empty)
                role.RoleID = Guid.NewGuid();
            else
                return null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "RoleID", DbType.Guid, role.RoleID);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, role.Name);
            return role;
        }

        public static void UpdateRole(Role role)
        {
            string sqlQuery = "UPDATE ROLE SET Name=@Name WHERE RoleID='" + role.RoleID + "'";

            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "Name", DbType.String, role.Name);
            DBHelper.ExecuteNonQuery(dbCommand);
        }

        public static IList<Role> GetRoles()
        {
            string sqlQuery = "SELECT * FROM ROLE";
            return GetRoleListFromQuery(sqlQuery);
        }

        public static IList<Role> GetRolesForEmployee(Guid employeeID)
        {
            string sqlQuery = "SELECT * FROM ROLE role INNER JOIN EMPLOYEEROLES emprol ON role.RoleID=emprol.RoleID WHERE emprol.EmployeeID='"+employeeID.ToString()+"'";
            return GetRoleListFromQuery(sqlQuery);
        }


        public static Role GetRoleByID(Guid roleID)
        {
            Role role = null;
            if (roleID == Guid.Empty)
                return role;
            string sqlQuery = "SELECT * FROM ROLE WHERE RoleID='" + roleID.ToString()+"'";
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
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
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
            role.RoleID = DBHelper.GetGuid(dataReader, "RoleID");
            role.Name = DBHelper.GetString(dataReader, "Name");
            return role;
        }

        #endregion
    }
}
