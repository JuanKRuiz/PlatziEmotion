using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private WebApplication2Context db = new WebApplication2Context();
        // GET: Home
        public ActionResult Index()
        {
            var modelo = new Home();
            return View(modelo);
        }

        public ActionResult MostrarStats()
        {
            ViewBag.PictureCount = db.EmoPictures.Count();
            ViewBag.FaceCount = db.EmoFaces.Count();
            ViewBag.EmotionCount = db.EmoEmotions.Count();
            ViewBag.OtroValor = "Hola";

            return View();
        }

        public ActionResult MostrarStatsRaw()
        {

            ViewBag.PictureCount = db.EmoPictures.Count();
            ViewBag.FaceCount = db.EmoFaces.Count();
            ViewBag.EmotionCount = db.EmoEmotions.Count();
            ViewBag.OtroValor = "Hola";

            return View();
        }


    }
}