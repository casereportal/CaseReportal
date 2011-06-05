using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CaseReportal.Model.Entities;

namespace CaseReportal.Models
{
    public class ReviewModels
    {
        public IEnumerable<Article> Articles { get; set; }
    }

    public class ReviewArticleModel
    {
        public string Case { get; set; }

        public string Title { get; set; }

        public string AuthorLastName { get; set; }

        public string AuthorFirstName { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [DisplayName("Approve Article")]
        public bool Accepted { get; set; }

        [DisplayName("Comments")]
        public string ReviewComment { get; set; }

        public int ArticleId { get; set; }
    }
}