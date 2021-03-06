﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Filters.Infrastructure
{
    public class CustomActionAttribute :  FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}