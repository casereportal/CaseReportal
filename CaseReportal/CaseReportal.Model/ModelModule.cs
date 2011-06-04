using Autofac;
using CaseReportal.Model.Entities;
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
            var cfg = Fluently.Configure()
                              .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.Database("593101_swbos")
                                                                                  .Username("593101_swbos")
                                                                                  .Password("SW931ab2")
                                                                                  .Server("72.3.204.155,4120")))
                              .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<ModelModule>(new CaseReportalAutomappingConfiguration())
                                                                       .UseOverridesFromAssemblyOf<ReviewOverrides>()))
                              .BuildConfiguration();

            var sessionFactory = cfg.BuildSessionFactory();
            builder.Register(x => sessionFactory).As<ISessionFactory>();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession());
        }
    }
}
