using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kurs.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [Route("Image/{format}/{id}.jpg")]
        public string CreateImage(string format, string id)
        {
            return $"Filformat: {format} - filnavn: {id}";
        }
    }
}