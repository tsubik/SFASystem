using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using SFASystem.DataAccess.Interfaces;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class EmployeeRepository : BaseRepository<Employee, Guid>, IEmployeeRepository
    {
        
    }
}
