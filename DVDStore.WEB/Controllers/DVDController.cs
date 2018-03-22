using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDStore.WEB.Controllers
{
    public class DVDController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}