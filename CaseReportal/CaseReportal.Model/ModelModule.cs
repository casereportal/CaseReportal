using Autofac;
using CaseReportal.Model.Mapping;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace CaseReportal.Model
{
    public class ModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var sessionFactory = Fluently.Configure()
                              .Database(MsSqlConfiguration.MsSql2008)
                              .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<ModelModule>(new CaseReportalAutomappingConfiguration()).Where((y) => y.Namespace == typeof(Article).Namespace)
                                                                       .UseOverridesFromAssemblyOf<ReviewOverrides>()))
                              .BuildSessionFactory();
            builder.Register(x => sessionFactory).As<ISessionFactory>();
        }
    }
}
