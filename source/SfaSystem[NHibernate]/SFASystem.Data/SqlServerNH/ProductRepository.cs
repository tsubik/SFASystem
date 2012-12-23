using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.DataAccess.Interfaces;
using SFASystem.Domain;
using NHibernate;
using System.Collections;
using NHibernate.Criterion;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public IList<ProductGroup> GetSubProductsGroups(ProductGroup parent)
        {
            ISession session = HBManager.Instance.GetSession();
            IList<ProductGroup> result = null;

            if(parent==null)
                result = session.CreateCriteria(typeof(ProductGroup))
                .Add(Expression.IsNull("ProductGroupParent")).List<ProductGroup>();
            else
                result = session.CreateCriteria(typeof(ProductGroup))
                .Add(Expression.Eq("ProductGroupParent", parent)).List<ProductGroup>();
            return result;
        }

    }
}
