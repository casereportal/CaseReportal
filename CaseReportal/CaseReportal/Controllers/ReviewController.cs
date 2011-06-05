using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseReportal.Model.Entities;
using CaseReportal.Models;
using NHibernate;

namespace CaseReportal.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ISession _Session;

        public ReviewController(ISession session)
        {
            _Session = session;
        }

        //
        // GET: /Review/

        public ActionResult Index()
        {
            using (var itx = _Session.BeginTransaction())
            {
                var articles = new ReviewModels();
                 articles.Articles = _Session.QueryOver<Article>().Where(x => x.Reviews.Count < 3).List();
            }
             
            return View();
        }

    }
}
