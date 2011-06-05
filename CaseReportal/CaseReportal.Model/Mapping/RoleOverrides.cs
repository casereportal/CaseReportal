using CaseReportal.Model.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CaseReportal.Model.Mapping
{
    public class RoleOverrides : IAutoMappingOverride<Role>
    {
        public void Override(AutoMapping<Role> mapping)
        {
            mapping.Map(x => x.RoleName).Column("RoleName").Not.Nullable();
        }
    }
}
