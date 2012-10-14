using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.DataAccess.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace SFASystem.DataAccess.SqlServerNH
{
    public abstract class BaseRepository<T, TId> : IRepository<T, TId>
    {
        public virtual T GetByID(TId id)
        {
            ISession session = HBManager.Instance.GetSession();
            return session.Get<T>(id);
        }

        public virtual IList<T> GetAll()
        {
            ISession session = HBManager.Instance.GetSession();
            return session.Query<T>().ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            ISession session = HBManager.Instance.GetSession();
            return session.Query<T>();
        }

        public virtual void SaveOrUpdate(T entity)
        {
            ISession session = HBManager.Instance.GetSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                transaction.Commit();
            }
           
        }

        public virtual void Remove(T entity)
        {
            ISession session = HBManager.Instance.GetSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }
    }
}
