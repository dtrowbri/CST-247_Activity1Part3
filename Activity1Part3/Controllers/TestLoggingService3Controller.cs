using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Services.Utility;
using Activity1Part3.Services.Business;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService3Controller : Controller
    {

        private readonly ILogger logger;
        private readonly ITestService service;

        public TestLoggingService3Controller(ILogger logger, ITestService service)
        {
            this.logger = logger;
            this.service = service;
        }
        // GET: TestLoggingService3
        public string Index()
        {
            logger.Info("This is a test info message from TestLoggingService3Controller");
            service.TestLogger();
            return "This is a test string from the Index action in TestLoggingService3Controller";
        }
    }
}