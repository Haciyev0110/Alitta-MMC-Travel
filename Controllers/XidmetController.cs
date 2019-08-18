using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllittaMMC.Models;

namespace AllittaMMC.Controllers
{
    public class XidmetController : Controller
    {
        // GET: Xidmet
        public readonly DB_A4490D_khaligchEntities db;

        public XidmetController()
        {
            db = new DB_A4490D_khaligchEntities();
        }
        public ActionResult Index(int id)
        {
            IndexVM indexVM = new IndexVM();
            indexVM.contact = db.Contacts.First();
            indexVM.xidmetlers = db.Services.ToList();
            indexVM.xidmetlerBasliqs = db.ServicesHeaders.ToList();
            indexVM.sp_ID = id;

            return View(indexVM);
        }

        public ActionResult Transfer()
        {
            IndexVM indexVM = new IndexVM();
            indexVM.contact = db.Contacts.First();
            indexVM.transfers = db.Transfers.ToList();

            return View(indexVM);
        }

    }
}