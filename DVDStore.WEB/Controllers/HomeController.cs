using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DVDStore.Access.Methods;
using DVDStore.Data.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace DVDStore.WEB.Controllers
{
    public class HomeController : Controller
    {

        static public byte[] ImageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
        private DVDStoreContext db = new DVDStoreContext();


        public ActionResult Picture()
        {
            //Image im = Image.FromFile(@"C:\Users\ClevelandCodes\Pictures\images\003.gif");
            //byte[] pic = ImageToByteArray(im);

            //DVD mov = new DVD
            //{
            //    Title = "City Lights",
            //    ReleaseDate = new DateTime(1931, 6, 4),
            //    Price = 4.99M,
            //    Genre = "Comedy",
            //    Actor = "Charlie Chaplin",
            //    Rating = "G",
            //    Description = "With the aid of a wealthy erratic tippler, a dewy-eyed tramp who has fallen in love with a sightless flower girl accumulates money to be able to help her medically.",
            //    PictureSmall = pic,
            //};

            //db.DVDs.Add(mov);
            //db.SaveChanges();

            Image img = Image.FromFile(@"C:\Users\ClevelandCodes\Pictures\images\default.gif");
            byte[] defpic = ImageToByteArray(img);


            var dvdpics = from d in db.DVDs
                          select d;


            string[] pics = new string[1000];
            string imgBase64;
            string imgDataURL;

            foreach (DVD d in dvdpics)
            {
                if (d.PictureSmall == null)
                    imgBase64 = Convert.ToBase64String(defpic);
                else
                    imgBase64 = Convert.ToBase64String(d.PictureSmall);

                imgDataURL = string.Format("data:image/gif;base64,{0}", imgBase64);
                pics[d.Id] = imgDataURL;
            }


            ViewBag.ImageData = pics;
            return View(dvdpics);
        }

        public ActionResult Index(string filterText)
        {
            Picture();
           

            FindAllDVDs findDVDs = new FindAllDVDs();
            IEnumerable<Data.Models.DVD> dvds = findDVDs.FindAllDVD("", "");
            var Results = dvds;

            if (string.IsNullOrWhiteSpace(filterText) == false)
            {
                //search on a specific term
                Results = dvds.Where(d => d.Title.ToLower().Contains(filterText)  );
                Results = dvds.Where(d => d.Genre.ToLower().Contains(filterText));
            }
            //if (string.IsNullOrWhiteSpace(filterText) == false)
            //{
            //    //search on a specific term
            //    Results = dvds.Where(d => d.Rating.ToLower().Contains(filterText));
            //}
            //else if (string.IsNullOrWhiteSpace(filterText) == false)
            //{
            //    //search on a specific term
                
            //} 

            return View(Results.ToList());


        }

        public ActionResult Details(int? id)
        {


            FindAllDVDs findDVDs = new FindAllDVDs();

            DVD SingleDVD = new DVD();

            if (id != null)
            {
                
                 SingleDVD = findDVDs.GetDVDById(id);

            }
            return View(SingleDVD);
        }

    }
}
