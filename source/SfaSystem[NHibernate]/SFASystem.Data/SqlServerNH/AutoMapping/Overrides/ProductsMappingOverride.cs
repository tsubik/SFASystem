using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using SFASystem.Domain;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping.Overrides
{
    public class ProductsMappingOverride : IAutoMappingOverride<Product>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Product> mapping)
        {
            mapping.HasManyToMany(x => x.Images).Table("ProductsToImages");
        }
    }
}
