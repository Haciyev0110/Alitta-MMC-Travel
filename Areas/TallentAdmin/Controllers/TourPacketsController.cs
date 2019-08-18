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
    public class TourPacketsController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/TourPackets
        public ActionResult Index()
        {
            var tourPackets = db.TourPackets.Include(t => t.Additional_Info).Include(t => t.TourSort);
            return View(tourPackets.ToList());
        }

        // GET: TallentAdmin/TourPackets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPacket tourPacket = db.TourPackets.Find(id);
            if (tourPacket == null)
            {
                return HttpNotFound();
            }
            return View(tourPacket);
        }

        // GET: TallentAdmin/TourPackets/Create
        public ActionResult Create()
        {
            ViewBag.Additional_Info_ID = new SelectList(db.Additional_Info, "ID", "Location");
            ViewBag.TourSortID = new SelectList(db.TourSorts, "ID", "SortBy");
            ViewBag.TourSort = db.TourSorts.ToList();
            ViewBag.Adinfo = db.Additional_Info.ToList();
            return View();
        }

        // POST: TallentAdmin/TourPackets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TourName,TourDay,HotelStar,Price,Image,Description,Additional_Info_ID,Map_Tour,TourSortID")] TourPacket tourPacket)
        {
            if (ModelState.IsValid)
            {
                db.TourPackets.Add(tourPacket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Additional_Info_ID = new SelectList(db.Additional_Info, "ID", "Location", tourPacket.Additional_Info_ID);
            ViewBag.TourSortID = new SelectList(db.TourSorts, "ID", "SortBy", tourPacket.TourSortID);
            return View(tourPacket);
        }

        // GET: TallentAdmin/TourPackets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPacket tourPacket = db.TourPackets.Find(id);
            if (tourPacket == null)
            {
                return HttpNotFound();
            }
            ViewBag.Additional_Info_ID = new SelectList(db.Additional_Info, "ID", "Location", tourPacket.Additional_Info_ID);
            ViewBag.TourSortID = new SelectList(db.TourSorts, "ID", "SortBy", tourPacket.TourSortID);
            return View(tourPacket);
        }

        // POST: TallentAdmin/TourPackets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TourName,TourDay,HotelStar,Price,Image,Description,Additional_Info_ID,Map_Tour,TourSortID")] TourPacket tourPacket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourPacket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Additional_Info_ID = new SelectList(db.Additional_Info, "ID", "Location", tourPacket.Additional_Info_ID);
            ViewBag.TourSortID = new SelectList(db.TourSorts, "ID", "SortBy", tourPacket.TourSortID);
            return View(tourPacket);
        }

        // GET: TallentAdmin/TourPackets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPacket tourPacket = db.TourPackets.Find(id);
            if (tourPacket == null)
            {
                return HttpNotFound();
            }
            return View(tourPacket);
        }

        // POST: TallentAdmin/TourPackets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourPacket tourPacket = db.TourPackets.Find(id);
            db.TourPackets.Remove(tourPacket);
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
