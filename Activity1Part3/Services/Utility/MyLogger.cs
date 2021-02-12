using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Activity1Part3.Services.Utility
{
    public class MyLogger : ILogger
    {

        private static MyLogger instance;
        private static Logger logger;

        private MyLogger()
        {

        }

        public static MyLogger getInstance()
        {
            if(instance == null)
            {
                instance = new MyLogger();
            }
            return instance;
        }

        private Logger GetLogger(string loggerName)
        {
            if(MyLogger.logger == null)
            {
                MyLogger.logger = LogManager.GetLogger(loggerName);
            }
            return MyLogger.logger;
        }


        public void Debug(string message)
        {
            GetLogger("myAppLoggerRules").Debug(message);
        }

        public void Error(string message)
        {
            GetLogger("myAppLoggerRules").Error(message);
        }

        public void Info(string message)
        {
            GetLogger("myAppLoggerRules").Info(message);
        }

        public void Warning(string message)
        {
            GetLogger("myAppLoggerRules").Warn(message);
        }
    }
}