using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Core.Common;
using SFASystem.Core.DataAccess;
using System.Security.Cryptography;
using System.Web.Security;

namespace SFASystem.Core.BusinessLogic
{
    public class EmployeeManager
    {
        public static Employee InsertEmployee(string login, string password )
        {
            Employee employee = new Employee();
            employee.Login = login;
            employee.PasswordSalt = CreateSalt(5);
            employee.PasswordHash = CreatePasswordHash(password, employee.PasswordSalt);
            employee.Active = true;
            employee.CreationDate = DateTime.Now;
            employee.LastActivityDate = DateTime.Now;
            employee.LastLoginDate = DateTime.MinValue;
            return EmployeeDB.InsertEmployee(employee);
        }

        public static void UpdateEmployee(Employee employee)
        {
            EmployeeDB.UpdateEmployee(employee);
        }

        public static bool DeleteEmployee(int employeeID)
        {
            return EmployeeDB.DeleteEmployee(employeeID);
        }

        public static IList<Employee> GetEmployees(bool onlyActive)
        {
            return EmployeeDB.GetEmployees(onlyActive);
        }

        public static IList<Employee> GetEmployeesByRoleID(int roleID)
        {
            return EmployeeDB.GetEmployeesByRoleID(roleID);
        }

        public static Employee GetEmployeeByID(int employeeID)
        {
            return EmployeeDB.GetEmployeeByID(employeeID);
        }

        public static Employee GetEmployeeByLogin(string login)
        {
            return EmployeeDB.GetEmployeeByLogin(login);
        }


        public static IList<Role> GetRolesForEmployee(int employeeID)
        {
            return RoleDB.GetRolesForEmployee(employeeID);
        }

        public static void AddEmployeeToRole(int employeeID, int roleID)
        {
            EmployeeDB.AddEmployeeToRole(employeeID, roleID);
        }
        public static void RemoveEmployeeFromRole(int employeeID, int roleID)
        {
            EmployeeDB.RemoveEmployeeFromRole(employeeID, roleID);
        }

        public static bool Login(string login, string password)
        {
            Employee employee = EmployeeDB.GetEmployeeByLogin(login);

            if (employee == null)
                return false;
            if (!employee.Active)
                return false;

            string passwordHash = CreatePasswordHash(password, employee.PasswordSalt);
            bool result = employee.PasswordHash.Equals(passwordHash);
            if (result)
            {
                //FormsAuthentication.RedirectFromLoginPage(login, false);
                return true;
            }
            return false;
        }
        public static void LogOut()
        {
            FormsAuthentication.SignOut();
        }

        public static void ChangePassword(string login, string oldpassword, string newpassword)
        {
            Employee employee = GetEmployeeByLogin(login);
            if (employee != null)
            {
                string oldPassHash = CreatePasswordHash(oldpassword, employee.PasswordSalt);
                if (!oldPassHash.Equals(employee.PasswordHash))
                    throw new SFAException("Podane hasło jest nieprawidłowe");
                string newPassSalt = CreateSalt(5);
                string newPassHash = CreatePasswordHash(newpassword, newPassSalt);

                employee.PasswordSalt = newPassSalt;
                employee.PasswordHash = newPassHash;
                UpdateEmployee(employee);
            }
            else
                throw new SFAException("Nieznany błąd");
        }
        
        #region Helper Methods

        private static string CreatePasswordHash(string Password, string Salt)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Password + Salt, "SHA1");
        }

        private static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            provider.GetBytes(data);
            return Convert.ToBase64String(data);
        }


        #endregion
    }
}
