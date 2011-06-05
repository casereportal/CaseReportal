using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CaseReportal.Models
{
    public class SearchModels
    {
        [Required]
        [DisplayName("Search Title")]
        public string Title { get; set; }
    }

    public class SearchResultModel
    {
        public IEnumerable<Model.Entities.Article> articles { get; set; }
    }
}