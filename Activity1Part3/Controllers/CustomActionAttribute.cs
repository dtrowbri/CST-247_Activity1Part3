using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Services.Utility;
using Activity1Part3.Models;

namespace Activity1Part3.Controllers
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UserModel user = (UserModel)filterContext.HttpContext.Session["user"];
            string username = "null";
            if (user != null && user.Username != null && user.Username != "")
            {
                username = user.Username;
            }
            string contoller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            string logString = "The action: {" + action + "} in controller: {" + contoller + "} invoked by user: {" + username + "} has completed execution.";
            MyLogger.getInstance().Info(logString);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserModel user = (UserModel)filterContext.HttpContext.Session["user"];
            string username = "null"; 
            if(user != null && user.Username != null && user.Username != "")
            {
                username = user.Username;
            }
            string contoller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            string logString = "The action: {" + action + "} in controller: {" + contoller + "} invoked by user: {" + username + "} is executing.";
            MyLogger.getInstance().Info(logString);
        }
    }
}