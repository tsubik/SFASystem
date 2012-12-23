using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using SFASystem.Domain;

namespace SFASystem.DataAccess.SqlServerNH.AutoMapping.Overrides
{
    class ContactsMappingOverride : IAutoMappingOverride<Contact>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Contact> mapping)
        {
            mapping.HasManyToMany(x => x.CustomerFacilities).Table("CustomerFacilitiesToContacts");
        }
    }
}
