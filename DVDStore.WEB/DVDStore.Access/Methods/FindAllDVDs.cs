using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDStore.Data.Models;


namespace DVDStore.Access.Methods
{
    public class FindAllDVDs
    {

        private DVDStoreContext db = new DVDStoreContext();


        public void FindAllDVD()
        {
            var FindDVDS = new List<string>();

            var DVDQuery = from d in db.DVD
                           orderby d.Title
                           select d.Title;

            FindDVDS.AddRange(DVDQuery.Distinct());
            ViewBag.
        }
    }
}
