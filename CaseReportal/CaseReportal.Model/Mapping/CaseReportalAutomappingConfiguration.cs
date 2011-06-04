using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;

namespace CaseReportal.Model.Mapping
{
    public class CaseReportalAutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == typeof(Article).Namespace;
        }
    }
}
