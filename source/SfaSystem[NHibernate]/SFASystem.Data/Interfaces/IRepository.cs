using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.DataAccess.Interfaces
{
    public interface IRepository<T, TId>
    {
        void SaveOrUpdate(T entity);
        void Remove(T entity);
        T GetByID(TId id);
        IList<T> GetAll();
        IQueryable<T> GetQueryable();
    }
}
