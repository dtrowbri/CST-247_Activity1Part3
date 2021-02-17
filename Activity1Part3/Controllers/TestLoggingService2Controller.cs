using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Services.Utility;
using Unity;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService2Controller : Controller
    {
        [Dependency]
        public ILogger logger { get; set; }
        // GET: TestLoggingService2
        public string Index()
        {
            logger.Info("This is a test info message from TestLoggingService2Controller");
            return "This is a test string from the Index action in TestLoggingService2Controller";
        }
    }
}