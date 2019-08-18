using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllittaMMC.Models;

namespace AllittaMMC.Controllers
{
    public class HomeController : Controller
    {
        public readonly DB_A4490D_khaligchEntities db;

        public HomeController()
        {
            db = new DB_A4490D_khaligchEntities();
        }

        public ActionResult Index()
        {
            IndexVM indexVM = new IndexVM();
            indexVM.contact = db.Contacts.First();
            indexVM.homeSlides = db.HomeSlides.ToList();
            indexVM.about = db.AboutUS.First();
            indexVM.xidmetlers = db.Services.ToList();
            indexVM.xidmetlerBasliqs = db.ServicesHeaders.ToList();

            return View(indexVM);
        }
    }
}