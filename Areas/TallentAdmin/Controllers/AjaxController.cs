using AllittaMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllittaMMC.Areas.TallentAdmin.Controllers
{
    public class AjaxController : Controller
    {
        private DB_A4490D_khaligchEntities db = new DB_A4490D_khaligchEntities();
        // GET: TallentAdmin/Ajax
        public ActionResult Adinforesult(int id)
        {
            Additional_Info bnm = db.Additional_Info.Find(id);
           
           

            return PartialView("_PartialPage1", bnm);
        }
    }
}