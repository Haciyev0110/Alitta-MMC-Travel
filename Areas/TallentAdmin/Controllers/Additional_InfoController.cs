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
    public class Additional_InfoController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/Additional_Info
        public ActionResult Index()
        {
            return View(db.Additional_Info.ToList());
        }

        // GET: TallentAdmin/Additional_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional_Info additional_Info = db.Additional_Info.Find(id);
            if (additional_Info == null)
            {
                return HttpNotFound();
            }
            return View(additional_Info);
        }

        // GET: TallentAdmin/Additional_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TallentAdmin/Additional_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Location,Duration,Min_Age,Max_People,Landing,Check_In,Check_Out")] Additional_Info additional_Info)
        {
            if (ModelState.IsValid)
            {
                db.Additional_Info.Add(additional_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(additional_Info);
        }

        // GET: TallentAdmin/Additional_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional_Info additional_Info = db.Additional_Info.Find(id);
            if (additional_Info == null)
            {
                return HttpNotFound();
            }
            return View(additional_Info);
        }

        // POST: TallentAdmin/Additional_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Location,Duration,Min_Age,Max_People,Landing,Check_In,Check_Out")] Additional_Info additional_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additional_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additional_Info);
        }

        // GET: TallentAdmin/Additional_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional_Info additional_Info = db.Additional_Info.Find(id);
            if (additional_Info == null)
            {
                return HttpNotFound();
            }
            return View(additional_Info);
        }

        // POST: TallentAdmin/Additional_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Additional_Info additional_Info = db.Additional_Info.Find(id);
            db.Additional_Info.Remove(additional_Info);
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
