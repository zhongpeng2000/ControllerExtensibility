using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    public class ProfileAllAttribute: ActionFilterAttribute
    {
        private Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Write(
                    string.Format("<div> Total elapsed time: {0:F6} </div>", timer.Elapsed.TotalSeconds));
            }
        }
    }
}