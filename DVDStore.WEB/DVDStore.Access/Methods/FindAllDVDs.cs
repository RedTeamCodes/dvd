using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDStore.Data.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;


namespace DVDStore.Access.Methods
{
    public class FindAllDVDs
    {

        private DVDStoreContext db = new DVDStoreContext();

        public dynamic ViewBag { get; }

        public void FindAllDVD(string DVDTitles, string searchString)
        {
            var FindDVDS = new List<string>();

            var DVDQuery = from d in db.DVD
                           orderby d.Title
                           select d.Title;

            FindDVDS.AddRange(DVDQuery.Distinct());
            ViewBag.DVDTitles = new SelectList(FindDVDS);

            var dvds = from dvd in db.DVD
                       select dvd;

            if (!String.IsNullOrEmpty(searchString))
            {
                dvds = dvds.Where(s => s.Title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(DVDTitles))
            {
                dvds = dvds.Where(x => x.Title == DVDTitles);

            }

        }
    }
}