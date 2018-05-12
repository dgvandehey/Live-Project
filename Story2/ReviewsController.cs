using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueRibbonsReview.Models;
using Microsoft.AspNet.Identity;

namespace BlueRibbonsReview.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.ApplicationUser);
            return View(reviews.ToList());
        }
        
        // GET: Relevant Reviews
        // Same expression as seen on Campaign Controller
        // No current Reviews to collect
        public ActionResult ReviewIndex()
        {
            string UserId = HttpContext.User.Identity.GetUserId();
            var campaignReviews = db.Reviews.Where(x => x.UserId.ToString() == UserId);

            return View("Index", campaignReviews);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            string UserId = HttpContext.User.Identity.GetUserId();

            ViewBag.UserId = new SelectList(new[] { UserId });
            Review review = new Review();
            review.ReviewDate = DateTime.Today;
            return View(review);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,ReviewDate,ProductRating,ReviewDetails,UserId")] Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    review.ReviewID = Guid.NewGuid();
                    review.ReviewDate = DateTime.Today;
                    review.UserId = User.Identity.GetUserId();
                    db.Reviews.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again and if the problem persists, see your System Administrator.");
            }
            ViewBag.UserId = new SelectList(db.Buyers, /*"UserId", "Amazon_ID",*/ review.UserId);
            return View(review);
            }
            
        // GET: Reviews/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Buyers, /*"UserId", "Amazon_ID"*/ review.UserId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (TryUpdateModel(review, "", new string[] { "ReviewDate", "ProductRating", "ReviewDetails", "UserId" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException/*dex*/)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again and if the problem continues contact your System Administrator.");
                }
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
