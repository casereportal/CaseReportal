using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaseReportal.Model;
using CaseReportal.Model.Entities;
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
        private Configuration _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.Database("593101_swbos")
                                                                                  .Username("593101_swbos")
                                                                                  .Password("SW931ab2")
                                                                                  .Server("72.3.204.155,4120")))
                    .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<CaseReportalAutomappingConfiguration>(new CaseReportalAutomappingConfiguration())
                                                 .UseOverridesFromAssemblyOf<ReviewOverrides>()))
                    .BuildConfiguration();
        }
        
        [Test]
        public void OutputSchemaTest()
        {
            var se = new SchemaExport(_configuration);
            se.SetOutputFile("Output.txt");
            se.Execute(true, true, false);
        }

        [Test]
        public void SchemaUpdate()
        {
            var su = new SchemaUpdate(_configuration);
            
            su.Execute(true, true);
        }

        [Test]
        public void CanBuildSessionFActory()
        {
            var sf = _configuration.BuildSessionFactory();
            using (var ses = sf.OpenSession())
            {
                using (var itx = ses.BeginTransaction())
                {
                    //var r = new Role();
                    //r.RoleName = "Nick's Role";

                    //var user = new User();
                    //user.FirstName = "Nicholas";
                    //user.LastName = "Goodwin";
                    //user.Nonce = "123";
                    //user.Password = "Mypassword";
                    //user.Email = "theunforgiven@gmail.com";
                    //user.Role = r;
                    //ses.Save(r);
                    //ses.Save(user);
                    //itx.Commit();
                }
            }
        }
    }


}


