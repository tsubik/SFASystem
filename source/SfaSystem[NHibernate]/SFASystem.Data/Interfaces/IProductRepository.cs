using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;

namespace SFASystem.DataAccess.Interfaces
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        IList<ProductGroup> GetSubProductsGroups(ProductGroup parent);
    }
}
