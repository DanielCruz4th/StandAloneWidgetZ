using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using StandAloneWidget.Controllers.Security;
using StandAloneWidget.Models.Security;
using StandAloneWidget.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AuthorizationController()
            : this (Startup.UserManagerFactory.Invoke())
        {

        }

        public AuthorizationController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        
        //
        // GET: /Auth/
        public ActionResult LogIn(string returnUrl)
        {
            return View(new LogInModel() { ReturnUrl = returnUrl } );
        }

        /// <summary>
        /// POST: /LogIn
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel credentials)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await userManager.FindAsync(credentials.UserName, credentials.Password);
            
            if(user != null)
            {
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);

                return Redirect(GetRedirectUrl(credentials.ReturnUrl));
            
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
            

        }

        /// <summary>
        /// LogOut
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authorizationManager = ctx.Authentication;

            authorizationManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterModel() { ID = Guid.NewGuid() } );
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppUser
            {
                UserName = model.UserName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("Index", "Admin");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
        }


        protected override void Dispose(bool disposing)
        {
            if(disposing && userManager != null)
            {
                userManager.Dispose();
            }

            base.Dispose(disposing);
        }
        
        
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                return Url.Action("Index", "Admin");
            else
                return returnUrl;
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }


    }
}
