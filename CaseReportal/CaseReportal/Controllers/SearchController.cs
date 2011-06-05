using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Submit(SearchModels model, string returnUrl)
        {
            if(ModelState.IsValid == false)
            {
                return View();
            }

            List<Model.Entities.Article> articles = null;
            using (var itx = this._Session.BeginTransaction())
            {
                articles = (List<Model.Entities.Article>)_Session.CreateQuery("select a from Article a where size(a.Reviews) >= 3 and a.Case like " 
                    + model.Title).List<Model.Entities.Article>();

            }
            return View("SearchResult", "Search", articles);
        }

    }

}
