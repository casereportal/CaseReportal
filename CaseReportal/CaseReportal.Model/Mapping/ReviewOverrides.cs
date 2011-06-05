using CaseReportal.Model.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CaseReportal.Model.Mapping
{
    public class ReviewOverrides : IAutoMappingOverride<Review>
    {
        public void Override(AutoMapping<Review> mapping)
        {
            mapping.References(x => x.Reviewer).Column("User_id").Not.Nullable();
        }
    }
}