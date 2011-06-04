using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CaseReportal.Model.Mapping
{
    public class ArticleOverrides : IAutoMappingOverride<Article>
    {
        public void Override(AutoMapping<Article> mapping)
        {
            mapping.Map(x => x.Title).Length(100);
            mapping.Map(x => x.Case).Length(5000);
            mapping.Map(x => x.Case).Column("CaseReport");
        }
    }
}