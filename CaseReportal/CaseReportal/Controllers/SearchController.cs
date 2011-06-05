using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseReportal.Model.Entities;
using NHibernate;
using CaseReportal.Models;

namespace CaseReportal.Controllers
{
    public class SearchController : Controller
    {
         private readonly ISession _Session;

        public SearchController(ISession session)
        {
            _Session = session;
        }

       //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchModels model, string returnUrl)
        {
            if(ModelState.IsValid == false)
            {
                return View();
            }

            var srm = new SearchResultModel();
            using (var itx = this._Session.BeginTransaction())
            {
                var arts = _Session.QueryOver<Article>().List();
                srm.articles = arts.Where(x => x.Title.Contains(model.Title));
                itx.Commit();
            }

            return View("SearchResult", srm);
        }

    }

}
