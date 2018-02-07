using MVC_MusicStore.Generic;
using MVC_MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MusicStore.Controllers
{
    [Authorize]
    [NotifyException]
    public class HomeController : Controller
    {
        MusicStoreContext db = new MusicStoreContext();

        public ActionResult Index()
        {
            var albums = db.AlbumsSet.Take(5).ToList();
            return View(albums);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}