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
            return type is IEntity;
        }
        
        public override bool IsId(FluentNHibernate.Member member)
        {
            return member.Name == member.DeclaringType.Name + "ID";
        }
    }
}
