using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using StandAloneWidget.Controllers.Security;

namespace StandAloneWidget.Controllers
{
    //[AllowAnonymous]
    public class AdminController : AppController
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            //Get from Owin
            //ViewBag.UserName = CurrentUser.Name;



            return View();
        }

    }
}
