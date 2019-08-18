using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllittaMMC.Models;

namespace AllittaMMC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public readonly DB_A4490D_khaligchEntities db;

        public ContactController()
        {
            db = new DB_A4490D_khaligchEntities();
        }

        public ActionResult Index()
        {
            IndexVM indexVM = new IndexVM();
            indexVM.contact = db.Contacts.First();
            indexVM.contacts = db.Contacts.ToList();

            return View(indexVM);
        }
    }
}