using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {

        private Stopwatch timer;
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();

            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Write(
                    string.Format("<div> Result elapsed time: {0:F6} </div>", timer.Elapsed.TotalSeconds));
            }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }
    }

}