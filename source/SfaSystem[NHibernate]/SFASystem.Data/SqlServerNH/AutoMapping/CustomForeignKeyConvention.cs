using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Conventions;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping
{
    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(FluentNHibernate.Member property, Type type)
        {
            if (property == null)
                return type.Name + "ID";

            return property.Name + "ID";
        }
    }
}
