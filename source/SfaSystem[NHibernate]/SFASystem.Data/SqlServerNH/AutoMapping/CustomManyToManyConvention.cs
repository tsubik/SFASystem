using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping
{
    public class CustomManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IManyToManyCollectionInstance instance)
        {
            if (instance.OtherSide == null)
            {
                instance.Table(
                   string.Format(
                       "{0}To{1}",
                       instance.EntityType.Name + "_Id",
                       instance.ChildType.Name + "_Id"));
            }
            else
            {
                instance.Inverse();
            }
            instance.Cascade.All();
        }

    }
}
