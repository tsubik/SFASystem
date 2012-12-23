using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using SFASystem.Domain;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping 
{
    public class AutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return typeof(IEntity).IsAssignableFrom(type);
            //return type.GetInterface(typeof(IEntity).FullName);
        }

        public override bool ShouldMap(FluentNHibernate.Member member)
        {
            if (member.IsProperty && !member.CanWrite)
            {
                return false;
            }
            return base.ShouldMap(member);
        }

        public override bool IsId(FluentNHibernate.Member member)
        {
            return member.Name == member.DeclaringType.Name + "ID";
        }
    }
}
