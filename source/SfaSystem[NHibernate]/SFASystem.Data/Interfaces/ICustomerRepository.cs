using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;

namespace SFASystem.DataAccess.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        IList<Customer> GetCustomers(string name, string nip, string regon);
    }
}
