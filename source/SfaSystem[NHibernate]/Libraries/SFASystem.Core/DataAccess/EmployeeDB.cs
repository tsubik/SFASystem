using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using SFASystem.Core.Common;

namespace SFASystem.Core.DataAccess
{
    public class EmployeeDB
    {
        public static Employee InsertEmployee(Employee employee)
        {
            string sqlQuery = "INSERT INTO EMPLOYEE(TerritoryID,AddressID,ManagerID,ContactID,Login,PasswordHash,PasswordSalt,Active,CreationDate,LastLoginDate,LastActivityDate) " +
                " VALUES(@TerritoryID,@AddressID,@ManagerID,@ContactID,@Login,@PasswordHash,@PasswordSalt,@Active,@CreationDate,@LastLoginDate,@LastActivityDate);SELECT @@Identity";

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "TerritoryID", DbType.Int32, employee.TerritoryID);
            db.AddInParameter(dbCommand, "AddressID", DbType.Int32, employee.AddressID);
            db.AddInParameter(dbCommand, "ManagerID", DbType.Int32, employee.ManagerID);
            db.AddInParameter(dbCommand, "ContactID", DbType.Int32, employee.ContactID);
            db.AddInParameter(dbCommand, "Login", DbType.String, employee.Login);
            db.AddInParameter(dbCommand, "PasswordHash", DbType.String, employee.PasswordHash);
            db.AddInParameter(dbCommand, "PasswordSalt", DbType.String, employee.PasswordSalt);
            db.AddInParameter(dbCommand, "Active", DbType.Boolean, true);
            db.AddInParameter(dbCommand, "CreationDate", DbType.DateTime, employee.CreationDate);
            db.AddInParameter(dbCommand, "LastLoginDate", DbType.DateTime, employee.LastLoginDate);
            db.AddInParameter(dbCommand, "LastActivityDate", DbType.DateTime, employee.LastActivityDate);
            employee.EmployeeID = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return employee;
        }

        public static void UpdateEmployee(Employee employee)
        {
            string sqlQuery = "UPDATE EMPLOYEE SET TerritoryID=@TerritoryID, AddressID=@AddressID, ManagerID=@ManagerID, ContactID=@ContactID,Login=@Login,PasswordHash=@PasswordHash,PasswordSalt=@PasswordSalt,Active=@Active, CreationDate=@CreationDate, LastLoginDate=@LastLoginDate, LastActivityDate=@LastActivityDate WHERE EmployeeID=" + employee.EmployeeID;

            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "TerritoryID", DbType.Int32, employee.TerritoryID);
            db.AddInParameter(dbCommand, "AddressID", DbType.Int32, employee.AddressID);
            db.AddInParameter(dbCommand, "ManagerID", DbType.Int32, employee.ManagerID);
            db.AddInParameter(dbCommand, "ContactID", DbType.Int32, employee.ContactID);
            db.AddInParameter(dbCommand, "Login", DbType.String, employee.Login);
            db.AddInParameter(dbCommand, "PasswordHash", DbType.String, employee.PasswordHash);
            db.AddInParameter(dbCommand, "PasswordSalt", DbType.String, employee.PasswordSalt);
            db.AddInParameter(dbCommand, "Active", DbType.Boolean, true);
            db.AddInParameter(dbCommand, "CreationDate", DbType.DateTime, employee.CreationDate);
            db.AddInParameter(dbCommand, "LastLoginDate", DbType.DateTime, employee.LastLoginDate);
            db.AddInParameter(dbCommand, "LastActivityDate", DbType.DateTime, employee.LastActivityDate);
            db.ExecuteNonQuery(dbCommand);
        }

        public static bool DeleteEmployee(int employeeID)
        {
            string sqlQuery = "UPDATE EMPLOYEE SET Active=0 WHERE EmployeeID = " + employeeID.ToString();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            if (db.ExecuteNonQuery(dbCommand) > 0)
                return true;
            else
                return false;
        }

        public static IList<Employee> GetEmployees(bool onlyActive)
        {
            string sqlQuery = "SELECT * FROM EMPLOYEE";
            if (onlyActive)
                sqlQuery += " WHERE Active=1";
            return GetEmployeeListFromQuery(sqlQuery);
        }

        public static IList<Employee> GetEmployeesByRoleID(int roleID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ");
            builder.Append("EMPLOYEE emp INNER JOIN EMPLOYEEROLES empRoles ON emp.EmployeeID=empRoles.EmployeeID ");
            builder.AppendFormat("WHERE empRoles.RoleID = {0}", roleID);

            return GetEmployeeListFromQuery(builder.ToString()); 
        }

        public static Employee GetEmployeeByID(int employeeID)
        {
            Employee employee = null;
            if(employeeID == 0)
                return employee;
            string sqlQuery = "SELECT * FROM EMPLOYEE WHERE EmployeeID=" + employeeID;
            return GetEmployeeFromQuery(sqlQuery);
        }

        public static Employee GetEmployeeByLogin(string login)
        {
            string sqlQuery = "SELECT * FROM EMPLOYEE WHERE Login='" + login + "'"; 
            return GetEmployeeFromQuery(sqlQuery);
        }

        public static void AddEmployeeToRole(int employeeID, int roleID)
        {
            string sqlQuery = "INSERT INTO EMPLOYEEROLES(EmployeeID, RoleID) Values (@EmployeeID, @RoleID)";
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, employeeID);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, roleID);

            db.ExecuteNonQuery(dbCommand);
        }
        public static void RemoveEmployeeFromRole(int employeeID, int roleID)
        {
            string sqlQuery = "DELETE FROM EMPLOYEEROLES WHERE EmployeeID=@EmployeeID AND RoleID=@RoleID";
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, employeeID);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, roleID);

            db.ExecuteNonQuery(dbCommand);
        }

        #region Helper Methods

        private static IList<Employee> GetEmployeeListFromQuery(string sqlQuery)
        {
            IList<Employee> listEmployee = new List<Employee>();
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
            Database db = new SqlDatabase(DBHelper.GetConnectionString());
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
            employee.EmployeeID = DBHelper.GetInt(dataReader, "EmployeeID");
            employee.TerritoryID = DBHelper.GetNullableInt(dataReader, "TerritoryID");
            employee.AddressID = DBHelper.GetNullableInt(dataReader, "AddressID");
            employee.ManagerID = DBHelper.GetNullableInt(dataReader, "ManagerID");
            employee.ContactID = DBHelper.GetNullableInt(dataReader, "ContactID");
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
