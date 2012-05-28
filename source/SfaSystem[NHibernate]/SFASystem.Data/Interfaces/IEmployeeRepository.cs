using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;

namespace SFASystem.DataAccess.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
    }
}
