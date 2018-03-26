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


        public ActionResult GetAllPictures()
        {
            //Image im = Image.FromFile(@"C:\Users\ClevelandCodes\Pictures\images\002.gif");
            //byte[] pic = ImageToByteArray(im);

            //DVD mov = new DVD
            //{
            //    Title = "Shawshank Redemption",
            //    ReleaseDate = new DateTime(1993, 2, 4),
            //    Price = 1.99M,
            //    Genre = "Thriller",
            //    Actor = "Morgan Freeman",
            //    Rating = "R",
            //    Description = "Andy Dufresne (Tim Robbins) is sentenced to two consecutive life terms in prison for the murders of his wife and her lover and is sentenced to a tough prison. However, only Andy knows he didn't commit the crimes. While there, he forms a friendship with Red (Morgan Freeman), experiences brutality of prison life, adapts, helps the warden, etc., all in 19 years.",
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

        public ActionResult GetSinglePicture(int id)
        {
            Image img = Image.FromFile(@"C:\Users\ClevelandCodes\Pictures\images\default.gif");
            byte[] defpic = ImageToByteArray(img);

            var dvdpic = from d in db.DVDs
                         where d.Id == id
                         select d.PictureSmall;
                          

            string pic ="";
            string imgBase64;
            string imgDataURL;


            foreach (byte[] d in dvdpic)
            {
                if (d == null)
                    imgBase64 = Convert.ToBase64String(defpic);
                else
                    imgBase64 = Convert.ToBase64String(d);

                imgDataURL = string.Format("data:image/gif;base64,{0}", imgBase64);
                pic = imgDataURL;
            }


            ViewBag.ImageData = pic;
            return View(dvdpic);


        }
   

    public ActionResult Index(string filterText)
        {
            GetAllPictures();
           

            FindAllDVDs findDVDs = new FindAllDVDs();
            IEnumerable<Data.Models.DVD> dvds = findDVDs.FindAllDVD("", "");
            var Results = dvds;

            if (string.IsNullOrWhiteSpace(filterText) == false)
            {
                //search on a specific term
                Results = dvds.Where(d => d.Title.ToLower().Contains(filterText)  );
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

        public ActionResult Details(int id)
        {

            GetSinglePicture(id);

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
