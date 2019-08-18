using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllittaMMC.Areas.TallentAdmin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: TallentAdmin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}