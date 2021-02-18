using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using Activity1Part3.Services.Utility;

using System.Runtime.Caching;

namespace Activity1Part3.Controllers
{
    [CustomAction]
    public class LoginController : Controller
    {
        private readonly ILogger logger;

        public LoginController(ILogger logger)
        {
            this.logger = logger;
        }
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
            //MyLogger.getInstance().Info("Entering LoginController.Login()");
            //MyLogger.getInstance().Info("Parameters are: " + new JavaScriptSerializer().Serialize(user));
            logger.Info("Entering LoginController.Login()");
            logger.Info("Parameters are: " + new JavaScriptSerializer().Serialize(user));
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
                    //MyLogger.getInstance().Info("Exit LoginController.Login() with login passing");
                    logger.Info("Exit LoginController.Login() with login passing");
                    return View("LoginPassed");
                }
                else
                {
                    Session.Clear();
                    //MyLogger.getInstance().Info("Exit LoginController.Login() with login failing");
                    logger.Info("Exit LoginController.Login() with login failing");
                    return View("LoginFailed");
                }
            }catch(Exception e)
            {
                Session.Clear();
                //MyLogger.getInstance().Error("Exception LoginController.Login()" + e.Message);
                logger.Error("Exception LoginController.Login()" + e.Message);
                return View("LoginFailed");
            }
        }
    
        [HttpGet]
        [CustomAuthorization]
        public string Protected()
        {
            return "This text is a place holder";
        }

        
        public ActionResult GetUsers()
        {
            MemoryCache cache = MemoryCache.Default;

            List<UserModel> users;

            users = (List<UserModel>)cache.Get("Users");

            if (users == null) {
                users = new List<UserModel>();
                users.Add(new UserModel { Username = "dtrowbri", Password = "UnimaginativePassword1!" });
                users.Add(new UserModel { Username = "brydonJ", Password = "blandPassw0rd" });
                users.Add(new UserModel { Username = "JoshScott", Password = "passwordCreat1v1tyIsStillL0w" });
                users.Add(new UserModel { Username = "MPritchard", Password = "ITSecurityPassw-rdAppr0v4l=%100" });

                DateTimeOffset policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(1);

                cache.Set("Users", users, policy);

                //MyLogger.getInstance().Info("Adding users to cache!");
                logger.Info("Adding users to cache!");
            }
            else
            {
                //MyLogger.getInstance().Info("Getting users from cache!");
                logger.Info("Getting users from cache!");
            }

            return Content(new JavaScriptSerializer().Serialize(users));
        }
    }
}