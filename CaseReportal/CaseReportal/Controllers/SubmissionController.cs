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
    public class SubmissionController : Controller
    {
        private readonly ISession _Session;

        public SubmissionController(ISession session)
        {
            _Session = session;
        }

        //
        // GET: /Submission/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(SubmissionModel model, string returnUrl)
        {
            if(ModelState.IsValid == false)
            {
                return View();
            }

            using (var itx = this._Session.BeginTransaction())
            {
                var id = Int32.Parse(User.Identity.Name.Split('|')[1]);
                var user = this._Session.QueryOver<Model.Entities.User>()
                                        .Where(x => x.Id == id)
                                        .SingleOrDefault();
                if (user == null)
                {
                    itx.Rollback();
                    return View();
                }

                var submission = new Article();
                submission.User = user;
                submission.Title = model.Title;
                submission.Case = model.Case;
                submission.Creation = DateTime.Now;
                this._Session.Save(submission);
                itx.Commit();
            }

            return RedirectToAction("ThankYouSubmission");
        }

        public ActionResult ThankYouSubmission()
        {
            ViewData["ShowSuccess"] = true;
            return View("Index");
        }
    }
}
