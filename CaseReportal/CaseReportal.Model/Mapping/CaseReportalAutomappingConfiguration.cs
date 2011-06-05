using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaseReportal.Model.Entities;
using FluentNHibernate.Automapping;

namespace CaseReportal.Model.Mapping
{
    public class CaseReportalAutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            //.Where(y => y.Namespace == typeof(Article).Namespace)
            return type.Namespace == typeof (Article).Namespace;
        }
    }
}
