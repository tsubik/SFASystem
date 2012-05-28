using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using SFASystem.Domain;
using SFASystem.Services;

namespace SFASystem.WebUtils.Security
{
    class SFARoleProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (string username in usernames)
            {
                Employee emp = EmployeeService.GetEmployeeByLogin(username);
                if (emp != null)
                {
                    foreach (string rolename in roleNames)
                    {
                        Role role = EmployeeService.GetRoleByName(rolename);
                        if (role != null)
                        {
                            emp.Roles.Add(role);
                        }
                    }
                }
                EmployeeService.SaveEmployee(emp);
            }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            Role role = new Role();
            role.Name = roleName;
            EmployeeService.SaveRole(role);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            Employee employee = EmployeeService.GetEmployeeByLogin(username);
            if (employee == null)
                return new string[] { };
            IList<Role> roles = employee.Roles;
            List<string> rolesStr = new List<string>();
            foreach (Role role in roles)
                rolesStr.Add(role.Name);
            return rolesStr.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            Employee employee = EmployeeService.GetEmployeeByLogin(username);
            if (employee == null)
                return false;
            IList<Role> empRoles = employee.Roles;
            foreach (Role role in empRoles)
            {
                if (role.Name.Equals(roleName))
                    return true;
            }
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (string username in usernames)
            {
                Employee emp = EmployeeService.GetEmployeeByLogin(username);
                if (emp != null)
                {
                    foreach (string rolename in roleNames)
                    {
                        Role role = EmployeeService.GetRoleByName(rolename);
                        if (role != null)
                            emp.Roles.Remove(role);
                    }
                }
                EmployeeService.SaveEmployee(emp);
            }
        }

        public override bool RoleExists(string roleName)
        {
            Role role = EmployeeService.GetRoleByName(roleName);
            if (role == null)
                return false;
            return true;
        }
    }
}
