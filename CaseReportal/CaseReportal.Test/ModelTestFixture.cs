using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaseReportal.Model;
using CaseReportal.Model.Mapping;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CaseReportal.Test
{
    [TestFixture]
    public class ModelTestFixture
    {
        private Configuration cfg;
        [SetUp]
        public void Setup()
        {
            cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008)
                    .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<ModelTestFixture>(new CaseReportalAutomappingConfiguration()).UseOverridesFromAssemblyOf<ReviewOverrides>()))
                    .BuildConfiguration();
        }
        [Test]
        public void OutputSchemaTest()
        {
            var se = new SchemaExport(cfg);
            se.SetOutputFile("Output.txt");
            se.Create(true, false);
        }
        [Test]
        public void CanBuildSessionFActory()
        {
            var sf = cfg.BuildSessionFactory();
        }
    }


}


