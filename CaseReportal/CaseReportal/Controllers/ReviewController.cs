using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseReportal.Model.Entities;
using CaseReportal.Models;
using Iesi.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

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
            var articles = new ReviewModels();
            GetArticles(articles); 
            return View(articles);
        }

        private void GetArticles(ReviewModels articles)
        {
            using (var itx = _Session.BeginTransaction())
            {
                var id = Int32.Parse(this.User.Identity.Name.Split('|')[1]);
                var user = _Session.QueryOver<User>().Where(x => x.Id == id);
                var requiredReviewCount = _Session.QueryOver<Config>().SingleOrDefault();
                articles.Articles = _Session.CreateQuery("select a from Article a where size(a.Reviews) < :reviewCount")
                                            .SetInt32("reviewCount", requiredReviewCount.RevCount)
                                            .List<Article>()
                                            .Where(x=> x.Reviews.Any(y=>y.Reviewer.Id == id) == false);
                itx.Commit();
            }
        }

        public ActionResult ReviewArticle(int? articleId)
        {
            var reviewArticleModel = new ReviewArticleModel();
            using (var itx = _Session.BeginTransaction())
            {
                var articleUnderReview = _Session.QueryOver<Article>()
                                                 .Where(x => x.Id == articleId)
                                                 .SingleOrDefault();
                reviewArticleModel.ArticleId = articleUnderReview.Id;
                reviewArticleModel.Created = articleUnderReview.Creation;
                reviewArticleModel.AuthorFirstName = articleUnderReview.User.FirstName;
                reviewArticleModel.AuthorLastName = articleUnderReview.User.LastName;
                reviewArticleModel.Title = articleUnderReview.Title;
                reviewArticleModel.Case = articleUnderReview.Case;
                itx.Commit();
            }

            return View(reviewArticleModel);
        }

        [HttpPost]
        public ActionResult ReviewArticle(ReviewArticleModel articleReview)
        {
            if (ModelState.IsValid == false || articleReview == null)
            {
                return View();
            }

            using (var itx = _Session.BeginTransaction())
            {
                var article = _Session.QueryOver<Article>().Where(x => x.Id == articleReview.ArticleId).SingleOrDefault();
                if (article == null)
                {
                    ModelState.AddModelError("ArticleId", "An error occured.");
                    return View();
                }

                var review = new Review();
                review.Approved = articleReview.Accepted;
                var id = Int32.Parse(User.Identity.Name.Split('|')[1]);
                review.Reviewer = _Session.QueryOver<User>()
                                          .Where(x => x.Id == id)
                                          .SingleOrDefault();
                review.Comment = articleReview.ReviewComment;
                review.Created = DateTime.Now;
                review.Article = _Session.QueryOver<Article>()
                                         .Where(x=>x.Id == articleReview.ArticleId)
                                         .SingleOrDefault();
                review.Article.Reviews.Add(review);
                var reviewCountConfig = _Session.QueryOver<Config>().SingleOrDefault().RevCount;
                if (review.Article.Reviews.Count >= reviewCountConfig)
                {
                    review.Article.Published = DateTime.Now;
                }
                _Session.Update(review.Article);
                _Session.Save(review);
                itx.Commit();
            }

            return RedirectToAction("ThankYouSubmission");
        }

        public ActionResult ThankYouSubmission()
        {
            ViewData["ShowSuccess"] = true;
            var articles = new ReviewModels();
            GetArticles(articles);
            return View("Index", articles);
        }
    }
}
