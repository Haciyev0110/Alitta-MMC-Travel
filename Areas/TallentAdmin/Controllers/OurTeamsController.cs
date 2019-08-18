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
    public class OurTeamsController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();

        // GET: TallentAdmin/OurTeams
        public ActionResult Index()
        {
            var ourTeams = db.OurTeams.Include(o => o.Social);
            return View(ourTeams.ToList());
        }

        // GET: TallentAdmin/OurTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam ourTeam = db.OurTeams.Find(id);
            if (ourTeam == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam);
        }

        // GET: TallentAdmin/OurTeams/Create
        public ActionResult Create()
        {
            ViewBag.SocialID = new SelectList(db.Socials, "Id", "Link1");
            return View();
        }

        // POST: TallentAdmin/OurTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Fullname,Job,Email,SocialID")] OurTeam ourTeam,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image == null)
                {
                    return RedirectToAction("Create", "OurTeams");
                }
                if (Extension.CheckImg(Image, Extension.MAxfileSize))
                {
                    try
                    {
                        ourTeam.Image = Extension.SaveImg(Image, "~/Public2/images/team");

                    }
                    catch
                    {

                        return View(ourTeam);
                    }
                }
                else
                {
                    return View(ourTeam);
                }
                db.OurTeams.Add(ourTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SocialID = new SelectList(db.Socials, "Id", "Link1", ourTeam.SocialID);
            return View(ourTeam);
        }

        // GET: TallentAdmin/OurTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam ourTeam = db.OurTeams.Find(id);
            if (ourTeam == null)
            {
                return HttpNotFound();
            }
            ViewBag.SocialID = new SelectList(db.Socials, "Id", "Link1", ourTeam.SocialID);
            return View(ourTeam);
        }

        // POST: TallentAdmin/OurTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Fullname,Job,Email,SocialID")] OurTeam ourTeam,HttpPostedFileBase Image,string fileadi)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        try
                        {
                            ourTeam.Image = Extension.SaveImg(Image, "~/Public2/images/team");

                        }
                        catch
                        {

                            return View(ourTeam);
                        }
                    }
                    else
                    {
                        return View(ourTeam);
                    }
                }
                else
                {
                    ourTeam.Image = fileadi;

                }
                db.Entry(ourTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SocialID = new SelectList(db.Socials, "Id", "Link1", ourTeam.SocialID);
            return View(ourTeam);
        }

        // GET: TallentAdmin/OurTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam ourTeam = db.OurTeams.Find(id);
            if (ourTeam == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam);
        }

        // POST: TallentAdmin/OurTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurTeam ourTeam = db.OurTeams.Find(id);
            db.OurTeams.Remove(ourTeam);
            db.SaveChanges();
            Extension.Deletimg("~/Public2/images/team", ourTeam.Image);

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
