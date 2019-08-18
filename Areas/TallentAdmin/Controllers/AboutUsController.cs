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
    public class AboutUsController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/AboutUs
        public ActionResult Index()
        {
            return View(db.AboutUS.ToList());
        }

        // GET: TallentAdmin/AboutUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutU aboutU = db.AboutUS.Find(id);
            if (aboutU == null)
            {
                return HttpNotFound();
            }
            return View(aboutU);
        }

        // GET: TallentAdmin/AboutUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TallentAdmin/AboutUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,TextH,TextP")] AboutU aboutU,HttpPostedFileBase Image)
        {


            if (ModelState.IsValid)
            {
                if (Image == null)
                {
                    return RedirectToAction("Create", "AboutUs");
                }
                if (Extension.CheckImg(Image, Extension.MAxfileSize))
                {
                    try
                    {
                        aboutU.Image = Extension.SaveImg(Image, "~/Public2/images/about");

                    }
                    catch
                    {

                       return View(aboutU);
                    }
                }
                else
                {
                    return View(aboutU);
                }
                db.AboutUS.Add(aboutU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutU);
        }

        // GET: TallentAdmin/AboutUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutU aboutU = db.AboutUS.Find(id);
            if (aboutU == null)
            {
                return HttpNotFound();
            }
            return View(aboutU);
        }

        // POST: TallentAdmin/AboutUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,TextH,TextP")] AboutU aboutU,HttpPostedFileBase Image,string fileadi)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        try
                        {
                            aboutU.Image = Extension.SaveImg(Image, "~/Public2/images/about");

                        }
                        catch
                        {

                            return View(aboutU);
                        }
                    }
                    else
                    {
                        return View(aboutU);
                    }
                }
                else
                {
                    aboutU.Image = fileadi;

                }

                db.Entry(aboutU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutU);
        }

        // GET: TallentAdmin/AboutUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutU aboutU = db.AboutUS.Find(id);
            if (aboutU == null)
            {
                return HttpNotFound();
            }
            return View(aboutU);
        }

        // POST: TallentAdmin/AboutUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutU aboutU = db.AboutUS.Find(id);
            db.AboutUS.Remove(aboutU);
            db.SaveChanges();
            Extension.Deletimg("~/Public2/images/about", aboutU.Image);

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
