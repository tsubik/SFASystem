using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.DataAccess.SqlServerNH;
using SFASystem.DataAccess.Interfaces;

namespace SFASystem.Services
{
    public static class BasicService<T, TId>
    {
        private static IRepository<T, TId> repository;

        static BasicService()
        {
            repository = new Repository<T, TId>();
        }

        public static T GetByID(TId id)
        {
            return repository.GetByID(id);
        }

        public static IList<T> GetAll()
        {
            return repository.GetAll();
        }

        public static void Delete(TId id)
        {
            var entity = repository.GetByID(id);
            repository.Remove(entity);
        }

        public static void Delete(T entity)
        {
            repository.Remove(entity);
        }

        public static void SaveOrUpdate(T entity)
        {
            repository.SaveOrUpdate(entity);
        }

        public static void Evict()
        {
            HBManager.Instance.FlushSession();
        }

        public static void CloseSession()
        {
            HBManager.Instance.CloseSession();
        }
    }
}
