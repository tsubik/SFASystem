using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using SFASystem.DataAccess.Interfaces;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class RoleRepository : BaseRepository<Role, Guid>, IRoleRepository
    {
        
    }
}
