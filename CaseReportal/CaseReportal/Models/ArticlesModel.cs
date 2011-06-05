using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseReportal.Models
{
    public class ArticlesModel
    {
        public DateTime CaseCreation { get; set; }
        public string CaseTitle { get; set; }
        public string CaseText { get; set; }
    }
}