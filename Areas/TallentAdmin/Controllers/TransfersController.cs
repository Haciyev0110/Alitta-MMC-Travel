using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllittaMMC.Models;
using VincentRestorant.Extino;

namespace AllittaMMC.Areas.TallentAdmin.Controllers
{
    public class TransfersController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/Transfers
        public ActionResult Index()
        {
            return View(db.Transfers.ToList());
        }

        // GET: TallentAdmin/Transfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = db.Transfers.Find(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            return View(transfer);
        }

        // GET: TallentAdmin/Transfers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TallentAdmin/Transfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Images,Car")] Transfer transfer,HttpPostedFileBase Images)
        {
            if (ModelState.IsValid)
            {
                if (Images == null)
                {
                    return RedirectToAction("Create", "ServicesHeaders");
                }
                if (Extension.CheckImg(Images, Extension.MAxfileSize))
                {
                    try
                    {
                        transfer.Images = Extension.SaveImg(Images, "~/Public2/images/service");

                    }
                    catch
                    {

                        return View(transfer);
                    }
                }
                else
                {
                    return View(transfer);
                }
                db.Transfers.Add(transfer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transfer);
        }

        // GET: TallentAdmin/Transfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = db.Transfers.Find(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            return View(transfer);
        }

        // POST: TallentAdmin/Transfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Images,Car")] Transfer transfer,HttpPostedFileBase Images,string fileadi)
        {
            if (ModelState.IsValid)
            {
                if (Images != null)
                {
                    if (Extension.CheckImg(Images, Extension.MAxfileSize))
                    {
                        try
                        {
                            transfer.Images = Extension.SaveImg(Images, "~/Public2/images/service");

                        }
                        catch
                        {

                            return View(transfer);
                        }
                    }
                    else
                    {
                        return View(transfer);
                    }
                }
                else
                {
                    transfer.Images = fileadi;

                }
                db.Entry(transfer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transfer);
        }

        // GET: TallentAdmin/Transfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = db.Transfers.Find(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            return View(transfer);
        }

        // POST: TallentAdmin/Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transfer transfer = db.Transfers.Find(id);
            db.Transfers.Remove(transfer);
            Extension.Deletimg("~/Public2/images/service", transfer.Images);
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
