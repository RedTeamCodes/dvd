using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDStore.Access.Methods;

namespace DVDStore.WEB.Controllers
{
    public class DVDController : Controller
    {

        public ActionResult Index(string filterText)
        {            
            FindAllDVDs findDVDs = new FindAllDVDs();
            IEnumerable<Data.Models.DVD> dvds = findDVDs.FindAllDVD("", "");
            var Results = dvds;

            if (string.IsNullOrWhiteSpace(filterText) == false)
            {
                //search on a specific term
                Results = dvds.Where(d => d.Title.ToLower().Contains(filterText)) ;
            }

            return View(Results.ToList());


        }

    }
}