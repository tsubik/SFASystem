using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class CustomerManager
    {
        public static Customer GetCustomerByID(Guid id)
        {
            return CustomerDB.GetCustomerByID(id);
        }

        public static IList<Contact> GetCustomerContacts(Guid customerID)
        {
            return ContactDB.GetCustomerContacts(customerID);
        }

        public static IList<Contact> GetCustomerFacContacts(Guid customerFacilityID)
        {
            return ContactDB.GetCustomerFacContacts(customerFacilityID);
        }


        public static IList<Customer> GetCustomers(Guid territoryID, string name)
        {
            IEnumerable<Customer> result = CustomerDB.GetCustomers().Where(p => p.Name.Contains(name));

            if (territoryID != Guid.Empty)
            {

                IList<CustomerFacility> customerFacilities = CustomerFacilityDB.GetCustomerFacilities(Guid.Empty, territoryID);

                var custIds = from pG in customerFacilities
                                      select pG.CustomerID;

                result = from c in result
                         where custIds.Contains(c.CustomerID)
                         select c;
            }
            return result.ToList();
        }

        public static IList<CustomerFacility> GetCustomerFacilities(Guid customerID, Guid territoryID)
        {
            return CustomerFacilityDB.GetCustomerFacilities(customerID, territoryID);
        }

        public static CustomerFacility GetCustomerFacilityByID(Guid customerFaciluityID)
        {
            return CustomerFacilityDB.GetCustomerFacilityByID(customerFaciluityID);
        }
    }
}
