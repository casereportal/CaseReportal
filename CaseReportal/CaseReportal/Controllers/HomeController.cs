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
    [HandleError]
    public class HomeController : Controller
    {
        private readonly ISession _Session;

        public HomeController(ISession session)
        {
            this._Session = session;
        }

        public ActionResult ViewArticle(int? articleId)
        {
            if (articleId.HasValue == false)
            {
                return Index();
            }
            Article article;
            using (var itx = _Session.BeginTransaction())
            {
                article = _Session.QueryOver<Article>().Where(x => x.Id == articleId).SingleOrDefault();
            }
            return View(article);
        }

        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated == false)
            {
                return View();
            }
            var homeViewModel = new HomeViewModel();
            using (var itx =_Session.BeginTransaction())
            {
                var requiredReviewCount = _Session.QueryOver<Config>().SingleOrDefault().RevCount;
                homeViewModel.Articles = _Session.CreateQuery("select a from Article a where size(a.Reviews) >= :reviewCount")
                                                 .SetInt32("reviewCount", requiredReviewCount)
                                                 .List<Article>()
                                                 .Where(x=>x.Reviews.Where(y=>y.Approved).Count() >= requiredReviewCount);
                itx.Commit();
            }

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
