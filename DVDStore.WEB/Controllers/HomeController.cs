using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDStore.Access.Methods;

namespace DVDStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FindAllDVDs findDVDs = new FindAllDVDs();


            return View(findDVDs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}