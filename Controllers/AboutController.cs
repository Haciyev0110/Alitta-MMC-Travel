using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllittaMMC.Models;


namespace AllittaMMC.Controllers
{
    public class AboutController : Controller
    {
        public readonly DB_A4490D_khaligchEntities db;

        // GET: About
        public AboutController()
        {
            db = new DB_A4490D_khaligchEntities();
        }

        public ActionResult Index()
        {
            IndexVM indexVM = new IndexVM();
            indexVM.contact = db.Contacts.First();
            indexVM.about = db.AboutUS.First();
            indexVM.ourTeams = db.OurTeams.ToList();
            return View(indexVM);
        }
    }
}
