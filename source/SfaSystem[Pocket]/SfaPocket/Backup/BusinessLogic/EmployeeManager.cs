using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;
using System.Security.Cryptography;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class EmployeeManager
    {
        public static Employee InsertEmployee(string login, string password)
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

        //public static bool DeleteEmployee(Guid employeeID)
        //{
        //    return EmployeeDB.DeleteEmployee(employeeID);
        //}

        public static IList<Employee> GetEmployees(bool onlyActive)
        {
            return EmployeeDB.GetEmployees(onlyActive);
        }

        public static IList<Employee> GetEmployeesByRoleID(Guid roleID)
        {
            return EmployeeDB.GetEmployeesByRoleID(roleID);
        }

        public static Employee GetEmployeeByID(Guid employeeID)
        {
            return EmployeeDB.GetEmployeeByID(employeeID);
        }

        public static Employee GetEmployeeByLogin(string login)
        {
            return EmployeeDB.GetEmployeeByLogin(login);
        }


        public static IList<Role> GetRolesForEmployee(Guid employeeID)
        {
            return RoleDB.GetRolesForEmployee(employeeID);
        }

        public static void AddEmployeeToRole(Guid employeeID, Guid roleID)
        {
            EmployeeDB.AddEmployeeToRole(employeeID, roleID);
        }
        public static void RemoveEmployeeFromRole(Guid employeeID, Guid roleID)
        {
            EmployeeDB.RemoveEmployeeFromRole(employeeID, roleID);
        }

        public static bool IsEmployeeInRole(Guid employeeID, string roleName)
        {
            return EmployeeDB.IsEmployeeInRole(employeeID, roleName);
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
            string hashed = "";
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hash =
            sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password+Salt));

            foreach (byte b in hash)
                hashed += String.Format("{0,2:X2}", b);

            return hashed;
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
