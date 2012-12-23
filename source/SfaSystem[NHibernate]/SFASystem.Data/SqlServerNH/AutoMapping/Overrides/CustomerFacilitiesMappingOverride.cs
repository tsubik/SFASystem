using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using SFASystem.Domain;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping.Overrides
{
    class CustomerFacilitiesMappingOverride : IAutoMappingOverride<CustomerFacility>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<CustomerFacility> mapping)
        {
            mapping.HasManyToMany(x => x.Contacts).Table("CustomerFacilitiesToContacts");
        }
    }
}
