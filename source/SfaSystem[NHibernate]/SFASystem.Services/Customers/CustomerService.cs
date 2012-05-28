using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using SFASystem.DataAccess.SqlServerNH;
using SFASystem.DataAccess.Interfaces;
using System.Linq.Expressions;
namespace SFASystem.Services
{
    public class CustomerService
    {
        private static ICustomerRepository customerRepository;

        static CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public static IList<Customer> GetCustomers(string name, string nip, string regon)
        {
            return customerRepository.GetCustomers(name, nip, regon);

        }

        public static IList<Contact> GetContacts(CustomerFacility fac)
        {
            if (fac == null)
                return null;
            if (fac.CustomerFacilityid == Guid.Empty)
                return null;
            Repository<Contact, Guid> contactRep = new Repository<Contact,Guid>();
            IEnumerable<Contact> contacts = new List<Contact>();
            contacts = contactRep.GetAll().Where(c => fac.Contact.Contains(c));
            return contacts.ToList();
        }
        public static IList<Contact> GetContacts(Customer cust)
        {
            if (cust == null)
                return null;
            if (cust.Customerid == Guid.Empty)
                return null;
            IList<CustomerFacility> customerFacilities = GetFacilities(string.Empty, cust, null);
            IEnumerable<Contact> result = new List<Contact>();
            foreach (CustomerFacility fac in customerFacilities)
            {
                result = result.Concat(fac.Contact);
            }
            if (cust.Contact != null)
            {
                IList<Contact> director = new List<Contact>();
                director.Add(cust.Contact);
                result = result.Concat(director);
            }
            return result.Distinct().ToList();
        }

        public static IList<CustomerFacility> GetFacilitiesForCustomer(Customer customer)
        {
            if (customer == null)
                return null;
            Repository<CustomerFacility, Guid> repo = new Repository<CustomerFacility, Guid>();
            var result = repo.GetAll();
            return result.Where(fac => fac.Customer.Customerid == customer.Customerid).ToList();
        }

        public static IList<CustomerFacility> GetFacilitiesForContact(Contact contact)
        {
            Repository<CustomerFacility, Guid> repo = new Repository<CustomerFacility, Guid>();
            var result = repo.GetQueryable().Where(fac => fac.Contact.Contains(contact));
            return result.ToList();
        }

        public static IList<CustomerFacility> GetFacilities(string name,Customer customer, Territory territory)
        {
            Repository<CustomerFacility, Guid> repo = new Repository<CustomerFacility, Guid>();
            var result = repo.GetAll()
                .Where(fac => fac.Name.Contains(name));
            if (customer != null)
                result = result.Where(fac => fac.Customer.Customerid == customer.Customerid);
            if (territory != null)
            {
                result = result.Where(fac => fac.Territory.Territoryid == territory.Territoryid);

                IList<Territory> allTerr = GetAllChildTerritories(territory);
                allTerr.Add(territory);
                var allTerrId = from pG in allTerr
                                      select pG.Territoryid;

                result = from p in result
                         where allTerrId.Contains(p.Territory.Territoryid)
                         select p;
            }
            return result.ToList();
        }

        public static IList<Territory> GetAllChildTerritories(Territory territory)
        {
            IList<Territory> result = territory.SubTerritories;
            foreach (Territory terr in result)
            {
                IList<Territory> subTer = GetAllChildTerritories(terr);
                result = result.Concat(subTer).ToList();
            }
            return result;
        }

        public static IList<Customer> GetCustomersForContactID(Contact contact)
        {
            IList<CustomerFacility> facilities = GetCustomerFacilitiesForContact(contact);
            var customers = from c in facilities
                            select c.Customer;
            return customers.Distinct().ToList();
        }

        public static IList<CustomerFacility> GetCustomerFacilitiesForContact(Contact contact)
        {
            Repository<CustomerFacility, Guid> rep = new Repository<CustomerFacility,Guid>();
            var result = from cf in rep.GetQueryable()
                         where cf.Contact.Contains(contact)
                         select cf;

            return result.ToList();
        }

        public static IList<Contact> GetContactsOnlyCust(string imieNaz, string email, string phone)
        {
            var employeeContact = from e in EmployeeService.GetAllEmployees(false)
                                  select e.Contact;

            IList<Contact> contacts = BasicService<Contact, Guid>.GetAll()
                .Where(c => (c.FirstName.Contains(imieNaz) || c.LastName.Contains(imieNaz)) &&
                    c.Email.Contains(email) && c.Phone.Contains(phone)).ToList();
          
            var result = from c in contacts.AsEnumerable()
                         where employeeContact.Contains(c)==false
                         select c;
            
            return result.ToList();        
        }
    }
}
