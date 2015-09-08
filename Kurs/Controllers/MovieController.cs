using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kurs.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

            public ViewResult Index()
        {
            var db = new ImdbContext();
            var movies = db.Movies;
            ViewData.Model = movies;
            return View();
        }
        //public string Index()
        //{
        //    return "Hei";
        //}

        public ViewResult Details (string id)
        {
            var db = new ImdbContext();

            var movie = db.Movies.Find(id);
            ViewData.Model = movie;

            return View();
        }

        public string Genres()
        {
            return "Movie Genres()";
        }

        public string MoviesByGenre(string genrename)
        {
            return "Movie genre: " + genrename;
        }

    }
}