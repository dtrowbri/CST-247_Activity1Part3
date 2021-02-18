using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    [CustomAuthorization]
    public class CustomerController : Controller
    {
        
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}