using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [CustomAuthorization]
        // GET: Test
        public string Index()
        {
            return "This is a message from controller Test and action Index";
        }
    }
}