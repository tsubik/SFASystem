using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace SFASystem.WebUtils.Security
{
    public class SecurityHelper
    {

        public static bool CanAddEditManufacturers(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }
        public static bool CanAddEditProducts(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }
        public static bool CanAddEditCustomers(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }
        public static bool CanAddEditCustomerFacilities(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }
        public static bool CanAddEditContacts(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }
        public static bool CanAddEditTerritories(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }
        public static bool CanAddEditProductGroups(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }

        public static bool CanAddEditEmployees(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }

        public static bool CanAddEditOrders(IPrincipal user)
        {
            if (user.IsInRole("Administrator") || user.IsInRole("SalesDirector"))
                return true;
            return false;
        }
      
    }
}
