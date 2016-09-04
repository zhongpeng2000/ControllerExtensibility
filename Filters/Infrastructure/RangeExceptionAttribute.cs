using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class RangeExceptionAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}