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

        public void LoadRows()
        {
            Image im = Image.FromFile(@"C:\Users\ClevelandCodes\Pictures\images\005.gif");
            byte[] pic = ImageToByteArray(im);

            DVD mov1 = new DVD
            {
                Title = "Spirited Away",
                ReleaseDate = new DateTime(1993, 09,04),
                Price = 2.59M,
                Genre = "Anime",
                Actor = " Daveigh Chase, Suzanne Pleshette, Miyu Irino",
                Rating = "PG",
                Description = "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.",
                PictureSmall = pic,
                Actors = new List<Actor>()
            };


            Actor act1 = new Actor
            {
                First = "Daveigh",
                Middle = "",
                Last = "Chase",
                Movies = new List<DVD>()

            };

            act1.Movies.Add(mov1);

            Actor act2 = new Actor
            {
                First = "Suzanne",
                Middle = "",
                Last = "Pleshette",
                Movies = new List<DVD>()

            };

            act2.Movies.Add(mov1);

            Actor act3 = new Actor
            {
                First = "Miyu",
                Middle = "",
                Last = "Irino",
                Movies = new List<DVD>()

            };

            act3.Movies.Add(mov1);





            Image im2 = Image.FromFile(@"C:\Users\ClevelandCodes\Pictures\images\003.gif");
            byte[] pic2 = ImageToByteArray(im2);

            DVD mov2 = new DVD
            {
                Title = "City Lights",
                ReleaseDate = new DateTime(1931, 10, 11),
                Price = 2.59M,
                Genre = "Comedy",
                Actor = "Charles Chaplin, Virginia Cherrill, Florence Lee",
                Rating = "G",
                Description = "With the aid of a wealthy erratic tippler, a dewy-eyed tramp who has fallen in love with a sightless flower girl accumulates money to be able to help her medically.",
                PictureSmall = pic2,
                Actors = new List<Actor>()
            };


            Actor act4 = new Actor
            {
                First = "Charlie",
                Middle = "",
                Last = "Chaplin",
                Movies = new List<DVD>()

            };

            act4.Movies.Add(mov2);

            Actor act5 = new Actor
            {
                First = "Virginia",
                Middle = "",
                Last = "Cherrill",
                Movies = new List<DVD>()

            };

            act5.Movies.Add(mov2);

            Actor act6 = new Actor
            {
                First = "Florence",
                Middle = "",
                Last = "Lee",
                Movies = new List<DVD>()

            };

            act6.Movies.Add(mov2);

            db.Actors.Add(act1);
            db.Actors.Add(act2);
            db.Actors.Add(act3);
            db.Actors.Add(act4);
            db.Actors.Add(act5);
            db.Actors.Add(act6);


            mov1.Actors.Add(act1);
            mov1.Actors.Add(act2);
            mov1.Actors.Add(act3);

            mov2.Actors.Add(act4);
            mov2.Actors.Add(act5);
            mov2.Actors.Add(act6);


            db.DVDs.Add(mov1);
            db.DVDs.Add(mov2);

            db.SaveChanges();


        }

        static public byte[] ImageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
        private DVDStoreContext db = new DVDStoreContext();


        public void SearchGenre()
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.DVDs
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);
 
        }

        public void SearchRating()
        {
            var RatingLst = new List<string>();

            var RatingQry = from d in db.DVDs
                           orderby d.Rating
                           select d.Rating;

            RatingLst.AddRange(RatingQry.Distinct());
            ViewBag.movieRating = new SelectList(RatingLst);

        }

        public ActionResult GetAllPictures()
        {
            //Image im = Image.FromFile(@"C:\Users\ClevelandCodes\Pictures\images\006.gif");
            //byte[] pic = ImageToByteArray(im);

            //DVD mov = new DVD
            //{
            //    Title = "Back to the Future",
            //    ReleaseDate = new DateTime(1985, 10, 11),
            //    Price = 1.59M,
            //    Genre = "Adventure",
            //    Actor = "Michael J. Fox",
            //    Rating = "PG",
            //    Description = "Marty McFly, a 17-year-old high school student, is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.",
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

     

    public ActionResult Index(string filterText, string movieGenre, string movieRating, string LastName)
        {

            //LoadRows();
            SearchGenre();
            SearchRating();
            GetAllPictures();
            



            FindAllDVDs findDVDs = new FindAllDVDs();
            IEnumerable<Data.Models.DVD> dvds = findDVDs.FindAllDVD("", "");
            var Results = dvds;

            if (string.IsNullOrWhiteSpace(filterText) == false)
            {
                //search on a specific term
                Results = dvds.Where(d => d.Title.ToLower().Contains(filterText)  );
            }

            //actorsearch

            if (!String.IsNullOrWhiteSpace(LastName))
            {

                Results = from d in db.DVDs
                          from a in d.Actors
                          where a.Last == LastName
                          select d;
            }


            //Results = from m in db.DVDs
            //             where m.Genre == movieGenre
            //             select m;

            if (!string.IsNullOrEmpty(movieGenre))
            {
                Results = dvds.Where(x => x.Genre == movieGenre);
            }

            if (!string.IsNullOrEmpty(movieRating))
            {
                Results = dvds.Where(x => x.Rating == movieRating);
            }



            return View(Results.ToList());
            


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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
