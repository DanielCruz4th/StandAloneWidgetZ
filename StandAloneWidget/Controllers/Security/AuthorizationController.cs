using StandAloneWidget.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        //
        // GET: /Auth/
        public ActionResult LogIn(string returnUrl)
        {
            return View(new LogInModel() { ReturnUrl = returnUrl } );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LogIn(LogInModel credentials)
        {
            if (!ModelState.IsValid)
                return View();

            //TODO: User sign, should be something like credentials valid or something! Add OUT parameter to tell what failed make use of the new ASP.NET Identity UserManager to authenticate
            if (true)
            {
                var identity = new ClaimsIdentity(new[] { 
                    new Claim( ClaimTypes.Name , "Me"),
                    new Claim( ClaimTypes.Country, "MX") },
                        "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authorizationManager = ctx.Authentication;

                authorizationManager.SignIn(identity);

                return Redirect(GetRedirectUrl(credentials.ReturnUrl));

            }
            else
            {
                // user authN failed
                //TODO: Handle Sighn in Errors
                //ModelState.AddModelError("", "Invalid email or password");
                //return View();
            }
            

        }


        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                return Url.Action("Index", "Admin");
            else
                return returnUrl;
        }

    }
}
