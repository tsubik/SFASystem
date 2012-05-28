using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class SalesRepository
    {
        public IList<Territory> GetSubTerritories(Territory parent)
        {
            ISession session = HBManager.Instance.GetSession();
            IList<Territory> result = null;

            if (parent == null)
                result = session.CreateCriteria(typeof(Territory))
                .Add(Expression.IsNull("ParentTerritory")).List<Territory>();
            else
                result = session.CreateCriteria(typeof(Territory))
                .Add(Expression.Eq("ParentTerritory", parent)).List<Territory>();
            return result;
        }
    }
}
