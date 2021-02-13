using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Services.Business;
using Activity1Part3.Models;

namespace Activity1Part3.Controllers
{
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            SecurityService securityService = new SecurityService();
            UserModel user = (UserModel)filterContext.HttpContext.Session["user"];
            bool success = false;

            if (user != null)
            {
               success = securityService.Authenticate(user);
            }

            if (!success)
            {
                filterContext.Result = new RedirectResult("/login");
            } 
        }
    }
}