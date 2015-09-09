using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Kurs.Controllers
{
    public class ImdbApiController : Controller
    {
        ImdbContext db = new ImdbContext();
        // GET: ImdbApi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Movies()
        {
            //var db = new ImdbContext();
            //var movies = db.Movies;
            var doc = new XElement("movies", from movie in db.Movies.ToList()
                                             select new XElement("movie", 
                                                new XAttribute("id", movie.MovieId),
                                                movie.Title));
            return Content(doc.ToString(), "text/xml");
        }

        public ActionResult Details(string id)
        {

            var m = db.Movies.Find(id);
            var doc = new XElement("movie", new XElement("details",
                                                new XAttribute("id", m.MovieId), 
                                                new XAttribute("title", m.Title),
                                                new XAttribute("orgTitle", m.OriginalTitle),
                                                new XAttribute("prodar", m.ProductionYear),
                                                new XAttribute("lengde", m.RunningLength)
                                                     ));
            return Content(doc.ToString(), "text/xml");
        }


    }
}