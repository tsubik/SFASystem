using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using SFASystem.Domain;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping.Overrides
{
    public class OrderLinesMappingOverride : IAutoMappingOverride<OrderLine>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<OrderLine> mapping)
        {
            mapping.CompositeId(x => x.ID)
                .Mapped()
                .KeyProperty(x => x.Order, "OrderID")
                .KeyProperty(x => x.Product, "ProductID");
        }
    }
}
