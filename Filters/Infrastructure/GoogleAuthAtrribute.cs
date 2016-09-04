using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Security.Principal;
using System.Web.Security;


namespace Filters.Infrastructure
{
    public class GoogleAuthAttribute : FilterAttribute, System.Web.Mvc.Filters.IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;
            if(!ident.IsAuthenticated || !ident.Name.EndsWith("@google.com"))
            {
                filterContext.Result = new HttpUnauthorizedResult();  // what is this????
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult) // IT WILL USE THE RESULT FROM OnAuthentication if Result != null (from there)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "GoogleAccount"},
                    { "action", "Login"},
                    { "returnUrl", filterContext.HttpContext.Request.RawUrl} // RwaUrl current Url from request
                });

            }

            else
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}