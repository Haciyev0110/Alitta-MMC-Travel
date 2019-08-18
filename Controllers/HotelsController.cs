using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllittaMMC.Models;


namespace AllittaMMC.Controllers
{
    public class HotelsController : Controller
    {
        // GET: Hotels
        public readonly DB_A4490D_khaligchEntities db;

        public HotelsController()
        {
            db = new DB_A4490D_khaligchEntities();
        }
        public ActionResult Index()
        {
            IndexVM indexVM = new IndexVM();
            indexVM.additional_Infos = db.Additional_Info.ToList();
            indexVM.contact = db.Contacts.First();
            indexVM.tour = db.TourPackets.First();
            indexVM.tourPackets = db.TourPackets.ToList();
            indexVM.hotels = db.Hotels.ToList();
            indexVM.tickets = db.Tickets.ToList();
            indexVM.travels = db.Travels.ToList();

            return View(indexVM);
        }
    }
}