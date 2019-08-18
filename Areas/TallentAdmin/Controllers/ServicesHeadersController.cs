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
    public class ServicesHeadersController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/ServicesHeaders
        public ActionResult Index()
        {
            return View(db.ServicesHeaders.ToList());
        }

        // GET: TallentAdmin/ServicesHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesHeader servicesHeader = db.ServicesHeaders.Find(id);
            if (servicesHeader == null)
            {
                return HttpNotFound();
            }
            return View(servicesHeader);
        }

        // GET: TallentAdmin/ServicesHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TallentAdmin/ServicesHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Header")] ServicesHeader servicesHeader,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image == null)
                {
                    return RedirectToAction("Create", "ServicesHeaders");
                }
                if (Extension.CheckImg(Image, Extension.MAxfileSize))
                {
                    try
                    {
                        servicesHeader.Image = Extension.SaveImg(Image, "~/Public2/images/service");

                    }
                    catch
                    {

                        return View(servicesHeader);
                    }
                }
                else
                {
                    return View(servicesHeader);
                }

                db.ServicesHeaders.Add(servicesHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicesHeader);
        }

        // GET: TallentAdmin/ServicesHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesHeader servicesHeader = db.ServicesHeaders.Find(id);
            if (servicesHeader == null)
            {
                return HttpNotFound();
            }
            return View(servicesHeader);
        }

        // POST: TallentAdmin/ServicesHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Header")] ServicesHeader servicesHeader,HttpPostedFileBase Image,string fileadi)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        try
                        {
                            servicesHeader.Image = Extension.SaveImg(Image, "~/Public2/images/service");

                        }
                        catch
                        {

                            return View(servicesHeader);
                        }
                    }
                    else
                    {
                        return View(servicesHeader);
                    }
                }
                else
                {
                    servicesHeader.Image = fileadi;

                }
                db.Entry(servicesHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicesHeader);
        }

        // GET: TallentAdmin/ServicesHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesHeader servicesHeader = db.ServicesHeaders.Find(id);
            if (servicesHeader == null)
            {
                return HttpNotFound();
            }
            return View(servicesHeader);
        }

        // POST: TallentAdmin/ServicesHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicesHeader servicesHeader = db.ServicesHeaders.Find(id);
            db.ServicesHeaders.Remove(servicesHeader);
            Extension.Deletimg("~/Public2/images/service", servicesHeader.Image);

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
