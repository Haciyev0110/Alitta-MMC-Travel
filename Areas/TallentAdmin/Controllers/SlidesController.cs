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
    public class SlidesController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/Slides
        public ActionResult Index()
        {
            return View(db.Slides.ToList());
        }

        // GET: TallentAdmin/Slides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: TallentAdmin/Slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TallentAdmin/Slides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text1,Text2,Text3,Text4,SlideImg")] Slide slide,HttpPostedFileBase SlideImg)
        {
            if (ModelState.IsValid)
            {
                if (SlideImg == null)
                {
                    return RedirectToAction("Create", "HomeSlides");
                }
                if (Extension.CheckImg(SlideImg, Extension.MAxfileSize))
                {
                    try
                    {
                        slide.SlideImg = Extension.SaveImg(SlideImg, "~/Public/images/slider");

                    }
                    catch
                    {

                        return View(slide);
                    }
                }
                else
                {
                    return View(slide);
                }
                db.Slides.Add(slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        // GET: TallentAdmin/Slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: TallentAdmin/Slides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text1,Text2,Text3,Text4")] Slide slide,HttpPostedFileBase SlideImg,string fileadi)
        {
            if (ModelState.IsValid)
            {
                if (SlideImg != null)
                {
                    if (Extension.CheckImg(SlideImg, Extension.MAxfileSize))
                    {
                        try
                        {
                            slide.SlideImg = Extension.SaveImg(SlideImg, "~/Public/images/slider");

                        }
                        catch
                        {

                            return View(slide);
                        }
                    }
                    else
                    {
                        return View(slide);
                    }
                }
                else
                {
                    slide.SlideImg = fileadi;

                }
                db.Entry(slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        // GET: TallentAdmin/Slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: TallentAdmin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide slide = db.Slides.Find(id);
            db.Slides.Remove(slide);
            Extension.Deletimg("~/Public/images/slider", slide.SlideImg);

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
