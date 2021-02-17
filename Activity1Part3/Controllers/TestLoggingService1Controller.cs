using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Services.Utility;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService1Controller : Controller
    {

        private readonly ILogger logger;

        public TestLoggingService1Controller(ILogger logger)
        {
            this.logger = logger;
        }
        // GET: TestLoggingService1
        public string Index()
        {
            logger.Info("This is a test info message from TestLoggingService1Controller");
            return "This is a test string from the Index action in TestLoggingService1Controller";
        }
    }
}