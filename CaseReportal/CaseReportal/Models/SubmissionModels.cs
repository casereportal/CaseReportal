using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseReportal.Models
{
    public class SubmissionModel
    {
        [Required]
        [DisplayName("Case Title")]
        public string Title { get; set; }
        
        [Required]
        [DisplayName("Case")]
        public string Case { get; set; }
    }
}