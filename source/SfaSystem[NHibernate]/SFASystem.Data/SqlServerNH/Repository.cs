using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.DataAccess.Interfaces;
using NHibernate;
using NHibernate.Criterion;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class Repository<T, TId> : BaseRepository<T, TId>, IRepository<T, TId>
    {

    }
}
