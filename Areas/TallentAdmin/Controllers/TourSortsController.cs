using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllittaMMC.Models;

namespace AllittaMMC.Areas.TallentAdmin.Controllers
{
    public class TourSortsController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/TourSorts
        public ActionResult Index()
        {
            return View(db.TourSorts.ToList());
        }

        // GET: TallentAdmin/TourSorts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourSort tourSort = db.TourSorts.Find(id);
            if (tourSort == null)
            {
                return HttpNotFound();
            }
            return View(tourSort);
        }

        // GET: TallentAdmin/TourSorts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TallentAdmin/TourSorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SortBy")] TourSort tourSort)
        {
            if (ModelState.IsValid)
            {
                db.TourSorts.Add(tourSort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourSort);
        }

        // GET: TallentAdmin/TourSorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourSort tourSort = db.TourSorts.Find(id);
            if (tourSort == null)
            {
                return HttpNotFound();
            }
            return View(tourSort);
        }

        // POST: TallentAdmin/TourSorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SortBy")] TourSort tourSort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourSort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourSort);
        }

        // GET: TallentAdmin/TourSorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourSort tourSort = db.TourSorts.Find(id);
            if (tourSort == null)
            {
                return HttpNotFound();
            }
            return View(tourSort);
        }

        // POST: TallentAdmin/TourSorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourSort tourSort = db.TourSorts.Find(id);
            db.TourSorts.Remove(tourSort);
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
