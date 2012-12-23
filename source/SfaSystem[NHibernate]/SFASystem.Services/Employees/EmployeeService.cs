using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using SFASystem.DataAccess.Interfaces;
using SFASystem.DataAccess.SqlServerNH;
using System.Web.Security;
using System.Security.Cryptography;

namespace SFASystem.Services
{
    public static class EmployeeService
    {
        private static IEmployeeRepository employeeRepository;
        private static IRoleRepository roleRepository;

        static EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
            roleRepository = new RoleRepository();
        }

        public static IList<Employee> GetManagerEmployees()
        {
            Role managerRole = EmployeeService.GetRoleByName("SalesManager");
            Role directorRole = EmployeeService.GetRoleByName("SalesDirector");

            return employeeRepository.GetQueryable().Where(e => e.Roles.Contains(managerRole) || e.Roles.Contains(directorRole)).ToList();
        }


        public static IList<Employee> GetEmployees(Guid roleId)
        {

            var result = employeeRepository.GetQueryable();
            if (roleId != Guid.Empty)
            {
                Role role = BasicService<Role, Guid>.GetByID(roleId);
                if (role != null)
                    result = result.Where(e => e.Roles.Contains(role));
            }
            return result.ToList();
        }

        public static IList<Employee> GetAllEmployees(bool onlyActive)
        {
            if (onlyActive)
                return employeeRepository.GetQueryable().Where(e => e.Active == true).ToList();
            else
                return employeeRepository.GetAll();
        }
        public static Employee GetEmployeeById(Guid id)
        {
            return employeeRepository.GetByID(id);
        }
        public static Employee GetEmployeeByLogin(string login)
        {
            return employeeRepository.GetQueryable().Where(e => e.Login == login).SingleOrDefault();
        }
        public static IList<Employee> GetEmployeeByRoleId(Guid roleId)
        {
            return employeeRepository.GetQueryable().Where(e => e.Roles.Where(r => r.RoleID == roleId).Count() > 0).ToList();
        }


        public static Role GetRoleByName(string name)
        {
            return roleRepository.GetQueryable().Where(r => r.Name == name).SingleOrDefault();
        }
        public static IList<Role> GetRoles()
        {
            return roleRepository.GetAll();
        }

        public static void SaveEmployee(Employee emp)
        {
            employeeRepository.SaveOrUpdate(emp);
        }
        public static void SaveRole(Role role)
        {
            roleRepository.SaveOrUpdate(role);
        }
        public static void AddEmployeeToRole(Guid employeeID, Guid roleID)
        {
            Role role = roleRepository.GetByID(roleID);
            role.Employees.Add(employeeRepository.GetByID(employeeID));
            SaveRole(role);
        }
        public static void RemoveEmployeeFromRole(Guid employeeID, Guid roleID)
        {
            Role role = roleRepository.GetByID(roleID);
            role.Employees.Remove(employeeRepository.GetByID(employeeID));
            SaveRole(role);
        }

        public static Dictionary GetTaskStatusByName(string name)
        {
            Repository<Dictionary, Guid> rep = new Repository<Dictionary, Guid>();
            var result = from dict in rep.GetQueryable()
                         where dict.DictionaryType.Name == "Status zadania" && dict.Value == name
                         select dict;
            return result.SingleOrDefault();
        }

        public static IList<Task> GetTaskToApprove(Employee emp, int howMany)
        {
            Repository<Task, Guid> rep = new Repository<Task, Guid>();
            var result = from t in rep.GetQueryable()
                         where t.GivenBy == emp && t.DateExecuted != null
                         orderby t.DateExecuted ascending
                         select t;
            return result.Take(howMany).ToList();
        }

        public static IList<Task> GetNewestTaskForEmployee(Employee emp, int howMany)
        {
            Repository<Task, Guid> rep = new Repository<Task, Guid>();
            var result = from t in rep.GetQueryable()
                         where t.AssignedTo == emp && t.TaskStatus.DictionaryNumber != (byte)TaskStatusEnum.Zakonczone
                         orderby t.DateCreated ascending
                         select t;
            return result.Take(howMany).ToList();
        }

        public static IList<Task> GetTasks(Employee assignedTo, Employee givenBy, Employee createdBy, Dictionary taskStatus,
        bool showOnlyApproved, DateTime? dateCreatedFrom, DateTime? dateCreatedTo)
        {
            Repository<Task, Guid> rep = new Repository<Task, Guid>();
            var result = from t in rep.GetQueryable() select t;
            if (assignedTo != null)
                result = result.Where(t => t.AssignedTo == assignedTo);
            if (givenBy != null)
                result = result.Where(t => t.GivenBy == givenBy);
            if (createdBy != null)
                result = result.Where(t => t.CreatedBy == createdBy);
            if (taskStatus != null)
                result = result.Where(t => t.TaskStatus == taskStatus);
            if (dateCreatedFrom.HasValue)
                result = result.Where(t => t.DateCreated > dateCreatedFrom.Value);
            if (dateCreatedTo.HasValue)
                result = result.Where(t => t.DateCreated < dateCreatedTo.Value);
            if (showOnlyApproved)
                result = result.Where(t => t.IsApproved == true);

            return result.ToList();
        }

        public static bool Login(string login, string password)
        {
            Employee employee = EmployeeService.GetEmployeeByLogin(login);

            if (employee == null)
                return false;
            if (!employee.Active)
                return false;

            string passwordHash = CreatePasswordHash(password, employee.PasswordSalt);
            bool result = employee.PasswordHash.Equals(passwordHash);
            if (result)
            {
                return true;
            }
            return false;
        }

        #region Helper Methods



        private static string CreatePasswordHash(string Password, string Salt)
        {
            string hashed = "";
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hash =
            sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password + Salt));

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

        public static void LogOut()
        {
            FormsAuthentication.SignOut();
        }

        //public static void ChangePassword(string login, string oldpassword, string newpassword)
        //{
        //    Employee employee = GetEmployeeByLogin(login);
        //    if (employee != null)
        //    {
        //        string oldPassHash = CreatePasswordHash(oldpassword, employee.PasswordSalt);
        //        if (!oldPassHash.Equals(employee.PasswordHash))
        //            throw new Exception("Podane hasło jest nieprawidłowe");
        //        string newPassSalt = CreateSalt(5);
        //        string newPassHash = CreatePasswordHash(newpassword, newPassSalt);

        //        employee.PasswordSalt = newPassSalt;
        //        employee.PasswordHash = newPassHash;
        //        employeeRepository.Update(employee);
        //    }
        //    else
        //        throw new Exception("Nieznany błąd");
        //}


    }
}
