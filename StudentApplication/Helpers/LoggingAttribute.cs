using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Helpers
{
    public class LoggingAttribute : ActionFilterAttribute, IActionFilter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StudentApplication.MvcApplication));

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            Console.WriteLine(log.IsInfoEnabled);
            Console.WriteLine(log.Logger.Name);
            log.Info("we executed a request for " + filterContext.HttpContext.Request.Url.ToString());
            this.OnActionExecuted(filterContext);
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            log.Info("we are executing a request for " + filterContext.HttpContext.Request.Url.ToString());
            this.OnActionExecuting(filterContext);
        }
    }
}