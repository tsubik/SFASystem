using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {
            string typeName = instance.EntityType.Name;
            
            instance.Table(Inflector.Inflector.Pluralize(typeName));
        }
    }
}
