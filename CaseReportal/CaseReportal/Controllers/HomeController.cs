using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseReportal.Model.Entities;
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
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            var users = this._Session.QueryOver<User>().List();
            ViewData["Users"] = users;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
