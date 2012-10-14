using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.DataAccess.Interfaces;
using SFASystem.Domain;
using NHibernate;
using NHibernate.Linq;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
    {
        public IList<Customer> GetCustomers(string name, string nip, string regon)
        {
            ISession session = HBManager.Instance.GetSession();
            return session.Query<Customer>().Where(c=> c.Name.Contains(name)
                && c.NIP.Contains(nip) && c.REGON.Contains(regon))
                .ToList();
        }
    }
}
