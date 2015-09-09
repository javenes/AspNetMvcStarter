using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kurs.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [Route("Image/{format}/{id}.jpg")]
        public ActionResult CreateImage(string format, string id)
        {
            var pixel = 0;
            switch (format)
            {
                case "thumb":
                    pixel = 100;
                    break;
                case "medium":
                    pixel = 300;
                    break;
                default:
                    return HttpNotFound();
            }


            if (format.Equals("thumb")) pixel = 100;

            var db = new ImdbContext();

            var movie = db.Movies.Find(id);
            var filename = Server.MapPath("~/App_Data/covers/" + movie.MovieId + ".jpg");

            new WebImage(filename)
                .Resize(pixel, pixel)
                .Write();


            return new EmptyResult();

        }
    }
}