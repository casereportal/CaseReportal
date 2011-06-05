using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseReportal.Model.Entities;

namespace CaseReportal.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}