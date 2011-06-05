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

        ////
        //// GET: /Submission/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Submission/Create

        //public ActionResult Create()
        //{
        //    return View();
        //} 

        //
        // POST: /Submission/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        
        ////
        //// GET: /Submission/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Submission/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Submission/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Submission/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
                var user = this._Session.QueryOver<Model.Entities.User>()
                                        .Where(x => x.Email == User.Identity.Name)
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
