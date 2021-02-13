using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using NLog;
using Activity1Part3.Services.Utility;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {

        //private static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            MyLogger.getInstance().Info("Entering LoginController.Login()");
            MyLogger.getInstance().Info("Parameters are: " + new JavaScriptSerializer().Serialize(user));
            try
            {
                SecurityService service = new SecurityService();
                bool authenticated = service.Authenticate(user);


                if (!ModelState.IsValid)
                {
                    return View("Login");
                }
                if (authenticated)
                {
                    Session["user"] = user;
                    MyLogger.getInstance().Info("Exit LoginController.Login() with login passing");
                    return View("LoginPassed");
                }
                else
                {
                    Session.Clear();
                    MyLogger.getInstance().Info("Exit LoginController.Login() with login failing");
                    return View("LoginFailed");
                }
            }catch(Exception e)
            {
                Session.Clear();
                MyLogger.getInstance().Error("Exception LoginController.Login()" + e.Message);
                return View("LoginFailed");
            }
        }
    
        [HttpGet]
        [CustomAuthorization]
        public string Protected()
        {
            return "This text is a place holder";
        }
    }
}