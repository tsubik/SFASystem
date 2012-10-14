using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class EmployeeDB
    {
        public static Employee InsertEmployee(Employee employee)
        {
            string sqlQuery = "INSERT INTO EMPLOYEE(EmployeeID,TerritoryID,AddressID,ManagerID,ContactID,Login,PasswordHash,PasswordSalt,Active,CreationDate,LastLoginDate,LastActivityDate) " +
                " VALUES(@EmployeeID,@TerritoryID,@AddressID,@ManagerID,@ContactID,@Login,@PasswordHash,@PasswordSalt,@Active,@CreationDate,@LastLoginDate,@LastActivityDate);SELECT @@Identity";
            if (employee.EmployeeID == Guid.Empty)
                employee.EmployeeID = Guid.NewGuid();
            else
                return null;
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "EmployeeID", DbType.Guid, employee.TerritoryID);
            DBHelper.AddInParameter(dbCommand, "TerritoryID", DbType.Guid, employee.TerritoryID);
            DBHelper.AddInParameter(dbCommand, "AddressID", DbType.Guid, employee.AddressID);
            DBHelper.AddInParameter(dbCommand, "ManagerID", DbType.Guid, employee.ManagerID);
            DBHelper.AddInParameter(dbCommand, "ContactID", DbType.Guid, employee.ContactID);
            DBHelper.AddInParameter(dbCommand, "Login", DbType.String, employee.Login);
            DBHelper.AddInParameter(dbCommand, "PasswordHash", DbType.String, employee.PasswordHash);
            DBHelper.AddInParameter(dbCommand, "PasswordSalt", DbType.String, employee.PasswordSalt);
            DBHelper.AddInParameter(dbCommand, "Active", DbType.Boolean, true);
            DBHelper.AddInParameter(dbCommand, "CreationDate", DbType.DateTime, employee.CreationDate);
            DBHelper.AddInParameter(dbCommand, "LastLoginDate", DbType.DateTime, employee.LastLoginDate);
            DBHelper.AddInParameter(dbCommand, "LastActivityDate", DbType.DateTime, employee.LastActivityDate);

            return employee;
        }

        public static void UpdateEmployee(Employee employee)
        {
            string sqlQuery = "UPDATE EMPLOYEE SET TerritoryID=@TerritoryID, AddressID=@AddressID, ManagerID=@ManagerID, ContactID=@ContactID,Login=@Login,PasswordHash=@PasswordHash,PasswordSalt=@PasswordSalt,Active=@Active, CreationDate=@CreationDate, LastLoginDate=@LastLoginDate, LastActivityDate=@LastActivityDate WHERE EmployeeID='" + employee.EmployeeID+"'";

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "TerritoryID", DbType.Guid, employee.TerritoryID);
            DBHelper.AddInParameter(dbCommand, "AddressID", DbType.Guid, employee.AddressID);
            DBHelper.AddInParameter(dbCommand, "ManagerID", DbType.Guid, employee.ManagerID);
            DBHelper.AddInParameter(dbCommand, "ContactID", DbType.Guid, employee.ContactID);
            DBHelper.AddInParameter(dbCommand, "Login", DbType.String, employee.Login);
            DBHelper.AddInParameter(dbCommand, "PasswordHash", DbType.String, employee.PasswordHash);
            DBHelper.AddInParameter(dbCommand, "PasswordSalt", DbType.String, employee.PasswordSalt);
            DBHelper.AddInParameter(dbCommand, "Active", DbType.Boolean, true);
            DBHelper.AddInParameter(dbCommand, "CreationDate", DbType.DateTime, employee.CreationDate);
            DBHelper.AddInParameter(dbCommand, "LastLoginDate", DbType.DateTime, employee.LastLoginDate);
            DBHelper.AddInParameter(dbCommand, "LastActivityDate", DbType.DateTime, employee.LastActivityDate);
            DBHelper.ExecuteNonQuery(dbCommand);
        }

        public static IList<Employee> GetEmployees(bool onlyActive)
        {
            string sqlQuery = "SELECT * FROM EMPLOYEE";
            if (onlyActive)
                sqlQuery += " WHERE Active=1";
            return GetEmployeeListFromQuery(sqlQuery);
        }

        public static IList<Employee> GetEmployeesByRoleID(Guid roleID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ");
            builder.Append("EMPLOYEE emp INNER JOIN EMPLOYEEROLES empRoles ON emp.EmployeeID=empRoles.EmployeeID ");
            builder.AppendFormat("WHERE empRoles.RoleID = '{0}'", roleID);

            return GetEmployeeListFromQuery(builder.ToString()); 
        }

        public static Employee GetEmployeeByID(Guid employeeID)
        {
            Employee employee = null;
            if(employeeID == Guid.Empty)
                return employee;

            string sqlQuery = "SELECT * FROM EMPLOYEE WHERE EmployeeID='" + employeeID+"'";
            return GetEmployeeFromQuery(sqlQuery);
        }

        public static Employee GetEmployeeByLogin(string login)
        {
            string sqlQuery = "SELECT * FROM EMPLOYEE WHERE Login='" + login + "'"; 
            return GetEmployeeFromQuery(sqlQuery);
        }

        public static void AddEmployeeToRole(Guid employeeID, Guid roleID)
        {
            string sqlQuery = "INSERT INTO EMPLOYEEROLES(EmployeeID, RoleID) Values (@EmployeeID, @RoleID)";
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "EmployeeID", DbType.Guid, employeeID);
            DBHelper.AddInParameter(dbCommand, "RoleID", DbType.Guid, roleID);

            DBHelper.ExecuteNonQuery(dbCommand);
        }
        public static bool IsEmployeeInRole(Guid employeeID, string roleName)
        {
            string sqlQuery = "SELECT Count(*) FROM EmployeeRoles er JOIN Role r on er.RoleID=r.RoleID WHERE r.Name='" + roleName + "' AND er.EmployeeID='" + employeeID + "'";
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            int result = (int) DBHelper.ExecuteScalar(dbCommand);
            if (result > 0)
                return true;
            return false;
        }


        public static void RemoveEmployeeFromRole(Guid employeeID, Guid roleID)
        {
            string sqlQuery = "DELETE FROM EMPLOYEEROLES WHERE EmployeeID=@EmployeeID AND RoleID=@RoleID";
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "EmployeeID", DbType.Guid, employeeID);
            DBHelper.AddInParameter(dbCommand, "RoleID", DbType.Guid, roleID);

            DBHelper.ExecuteNonQuery(dbCommand);
        }

        #region Helper Methods

        private static IList<Employee> GetEmployeeListFromQuery(string sqlQuery)
        {
            IList<Employee> listEmployee = new List<Employee>();
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listEmployee.Add(GetEmployeeFromReader(dataReader));
                }
            }
            return listEmployee;
        }

        private static Employee GetEmployeeFromQuery(string sqlQuery)
        {
            Employee employee = null;
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    employee = GetEmployeeFromReader(dataReader);
                }
            }
            return employee;
        }

        private static Employee GetEmployeeFromReader(IDataReader dataReader)
        {
            Employee employee = new Employee();
            employee.EmployeeID = DBHelper.GetGuid(dataReader, "EmployeeID");
            employee.TerritoryID = DBHelper.GetGuid(dataReader, "TerritoryID");
            employee.AddressID = DBHelper.GetGuid(dataReader, "AddressID");
            employee.ManagerID = DBHelper.GetGuid(dataReader, "ManagerID");
            employee.ContactID = DBHelper.GetGuid(dataReader, "ContactID");
            employee.Login = DBHelper.GetString(dataReader, "Login");
            employee.PasswordHash = DBHelper.GetString(dataReader, "PasswordHash");
            employee.PasswordSalt = DBHelper.GetString(dataReader, "PasswordSalt");
            employee.Active = DBHelper.GetBoolean(dataReader, "Active");
            employee.LastActivityDate = DBHelper.GetDateTime(dataReader, "LastActivityDate");
            employee.LastLoginDate = DBHelper.GetDateTime(dataReader, "LastLoginDate");
            employee.CreationDate = DBHelper.GetDateTime(dataReader, "CreationDate");
            return employee;
        }

        #endregion

    }
}
