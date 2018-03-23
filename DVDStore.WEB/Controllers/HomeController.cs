using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
            IEnumerable<Data.Models.DVD> dvds = findDVDs.FindAllDVD("", "");
            return View(dvds.ToList());
        }
    }
}