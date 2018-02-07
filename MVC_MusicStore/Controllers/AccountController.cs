using MVC_MusicStore.Generic;
using MVC_MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_MusicStore.Controllers
{
    [NotifyException]
    public class AccountController : Controller
    {
        MusicStoreContext db = new MusicStoreContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account
        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool uservalid = db.UsersSet.Any(e => e.UserName == user.UserName && e.Password == user.Password);
                if (uservalid)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password is incorrect.");
                }
            }

            return View(user);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}