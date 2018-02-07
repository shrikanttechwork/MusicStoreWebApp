using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_MusicStore.Generic
{

    public class ValidatedUserRoles : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            ViewResult viewresult = new ViewResult();
            var controllername = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionname = filterContext.ActionDescriptor.ActionName;
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if(controllername == "StoreManager")
                {
                    if (!HttpContext.Current.User.IsInRole("admin"))
                    {                        
                        viewresult.ViewName = "Error";
                        viewresult.ViewBag.errormesage = "Your are not admin user.";
                        filterContext.Result = viewresult; 
                    }
                }

                if (controllername == "Admin")
                {
                    if (!HttpContext.Current.User.IsInRole("superadmin"))
                    {
                        viewresult.ViewName = "Error";
                        viewresult.ViewBag.errormesage = "Your are not super admin user.";
                        filterContext.Result = viewresult;
                    }
                }

            }
            else
            { 
                viewresult.ViewName = "Error";
                viewresult.ViewBag.errormesage = "Your are not valid user.";
                filterContext.Result = viewresult;
            }
        }
    }
}