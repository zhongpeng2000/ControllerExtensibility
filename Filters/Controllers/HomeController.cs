using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Users = "admin")]
        public string Index()
        {

            if (!Request.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();  // this will automatically give you returnUrl=XXXXX in URL
            }

            return "This is the Index action on the Home Controller";
        }



        [GoogleAuth]
        public string List()
        {
            return "This is the list action on the Home controller";
        }

        [HandleError( View = "Error")]
        public string RangeTest(int id)
        {
            throw new ArgumentOutOfRangeException("id", id, "");
        }
    }
}