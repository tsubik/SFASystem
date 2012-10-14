using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Pocket.Core.DataAccess;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class RoleManager
    {
        public static Role InsertRole(Role role)
        {
            return RoleDB.InsertRole(role);
        }

        public static void UpdateRole(Role role)
        {
            RoleDB.UpdateRole(role);
        }

        public static IList<Role> GetRoles()
        {
            return RoleDB.GetRoles();
        }


        public static Role GetRoleByID(Guid roleID)
        {
            return RoleDB.GetRoleByID(roleID);
        }
        public static Role GetRoleByName(string name)
        {
            return RoleDB.GetRoleByName(name);
        }
        public static IList<Role> GetRolesForEmployee(Guid employeeID)
        {
            return RoleDB.GetRolesForEmployee(employeeID);
        }
    }
}
