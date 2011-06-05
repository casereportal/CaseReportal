using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaseReportal.Model.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CaseReportal.Model.Mapping
{
    public class UserOverrides : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.References(x => x.Role).Not.Nullable();
            mapping.Map(x => x.Nonce).Not.Nullable();
            mapping.Map(x => x.Password).Not.Nullable();
            mapping.Map(x => x.Email).Not.Nullable();
            mapping.Map(x => x.LastName).Not.Nullable();
            mapping.Map(x => x.FirstName).Not.Nullable();
        }
    }
}
