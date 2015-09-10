using Kurs.Areas.Admin.Models;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kurs.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        ImdbContext db = new ImdbContext();

        // GET: Admin/Movie
        public ActionResult Index()
        {
            ViewData.Model = db.Movies;

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Genres = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieX model)
        {
            ViewBag.Genres = new SelectList(db.Genres, "GenreId", "Name");

            if (ModelState.IsValid)
            {

                var movie = new Movie();
                movie.MovieId = model.MovieId;

                movie.OriginalTitle = model.OriginalTitle;
                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.RunningLength = (model.RunningLengthHour * 60) + model.RunningLengthMinute;

                if (movie.RunningLength < 10)
                {
                    ModelState.AddModelError("RunningLengthHour", "Filmen er for kort");
                    ModelState.AddModelError("RunningLengthMinutes", "Filmen er for kort");
                    return View();
                }
                movie.ProductionYear = model.ProductionYear;
                movie.Genre = db.Genres.Find(model.GenreId);

                db.Movies.Add(movie);
                db.SaveChanges();

                return RedirectToAction("Index", "Movie");

            }

            return View();
        }

        public ActionResult Delete(string movieId)
        {
            var m = db.Movies.Find(movieId);
            if (m == null)
                return HttpNotFound();

            ViewData.Model = new MovieX
            return View("Index");
        }


    }
}