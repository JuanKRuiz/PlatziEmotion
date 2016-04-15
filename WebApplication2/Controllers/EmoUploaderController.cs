using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Util;

namespace WebApplication2.Controllers
{
    public class EmoUploaderController : Controller
    {
        string serverFolderPath;
        EmotionHelper emoHelper;
        string key;
        WebApplication2Context db = new WebApplication2Context();

        public EmoUploaderController()
        {
            serverFolderPath = ConfigurationManager.AppSettings["UPLOAD_DIR"];
            key = ConfigurationManager.AppSettings["EMOTION_KEY"];
            emoHelper = new EmotionHelper(key);

        }

        // GET: EmoUploader
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file?.ContentLength > 0)
            {
                var pictureName = Guid.NewGuid().ToString();
                pictureName += Path.GetExtension(file.FileName);

                var route = Server.MapPath(serverFolderPath);
                route = route + "/" + pictureName;

                file.SaveAs(route);

                var emoPicture = await emoHelper.DetectAndExtracFacesAsync(file.InputStream);

                emoPicture.Name = file.FileName;
                emoPicture.Path = $"{serverFolderPath}/{pictureName}";

                db.EmoPictures.Add(emoPicture);
                await db.SaveChangesAsync();

                return RedirectToAction("Details", "EmoPictures", new { Id = emoPicture.Id });
            }
            return View();
        }
    }
}