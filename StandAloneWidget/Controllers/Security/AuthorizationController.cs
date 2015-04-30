using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        //
        // GET: /Auth/

        public ActionResult LogIn()
        {
            return View();
        }

    }
}
