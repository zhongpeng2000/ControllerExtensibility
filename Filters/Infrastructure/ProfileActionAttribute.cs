using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    public class ProfileActionAttribute : FilterAttribute, IActionFilter
    {

        private Stopwatch timer;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();

            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Write(
                    string.Format("<div> Action method elapsed time: {0:F6} </div>", timer.Elapsed.TotalSeconds));
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();

           
        }
    }
}