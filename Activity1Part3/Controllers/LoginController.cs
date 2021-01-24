using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Models;
using Activity1Part3.Services.Business;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            if(new SecurityService().Authenticate(model))
            {
                return View("LoginPassed");
            } else
            {
                return View("LoginFailed");
            }
        }
    }
}