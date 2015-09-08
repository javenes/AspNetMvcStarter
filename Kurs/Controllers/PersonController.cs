using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kurs.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public string Actors()
        {
            return "Din Actor ";
        }

        public ViewResult Details(int id)
        {
            var db = new ImdbContext();

            var person = db.Persons.Find(id);
            ViewData.Model = person;

            return View();
        }
    }
}