using MVC_MusicStore.Generic;
using MVC_MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MusicStore.Controllers
{
    //[Authorize(Roles = "superadmin")]
    //[Authorize]
    [ValidatedUserRoles]
    [NotifyException]
    public class AdminController : Controller
    {
        MusicStoreContext db = new MusicStoreContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.UsersSet.ToList());
        }

        // Get Account User 
        public ActionResult Create()
        {
            return View();
        }

        //Post user
        [HttpPost]
        public ActionResult Create(User user)
        {

            if (ModelState.IsValid)
            {
                db.UsersSet.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(user);
        }
    }
}