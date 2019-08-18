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
    public class HomeSlidesController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/HomeSlides
        public ActionResult Index()
        {
            return View(db.HomeSlides.ToList());
        }

        // GET: TallentAdmin/HomeSlides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeSlide homeSlide = db.HomeSlides.Find(id);
            if (homeSlide == null)
            {
                return HttpNotFound();
            }
            return View(homeSlide);
        }

        // GET: TallentAdmin/HomeSlides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TallentAdmin/HomeSlides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text1,Text2,Image")] HomeSlide homeSlide,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image == null)
                {
                    return RedirectToAction("Create", "HomeSlides");
                }
                if (Extension.CheckImg(Image, Extension.MAxfileSize))
                {
                    try
                    {
                        homeSlide.Image = Extension.SaveImg(Image, "~/Public2/images/home");

                    }
                    catch
                    {

                        return View(homeSlide);
                    }
                }
                else
                {
                    return View(homeSlide);
                }
                db.HomeSlides.Add(homeSlide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeSlide);
        }

        // GET: TallentAdmin/HomeSlides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeSlide homeSlide = db.HomeSlides.Find(id);
            if (homeSlide == null)
            {
                return HttpNotFound();
            }
            return View(homeSlide);
        }

        // POST: TallentAdmin/HomeSlides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text1,Text2,Image")] HomeSlide homeSlide,HttpPostedFileBase Image,string fileadi)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        try
                        {
                            homeSlide.Image = Extension.SaveImg(Image, "~/Public2/images/home");

                        }
                        catch
                        {

                            return View(homeSlide);
                        }
                    }
                    else
                    {
                        return View(homeSlide);
                    }
                }
                else
                {
                    homeSlide.Image = fileadi;

                }
                db.Entry(homeSlide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeSlide);
        }

        // GET: TallentAdmin/HomeSlides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeSlide homeSlide = db.HomeSlides.Find(id);
            if (homeSlide == null)
            {
                return HttpNotFound();
            }
            return View(homeSlide);
        }

        // POST: TallentAdmin/HomeSlides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeSlide homeSlide = db.HomeSlides.Find(id);
            db.HomeSlides.Remove(homeSlide);
            db.SaveChanges();
           
                Extension.Deletimg("~/Public2/images/about", homeSlide.Image);
            

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
