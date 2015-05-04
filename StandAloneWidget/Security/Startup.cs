using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using StandAloneWidget.Controllers.Security;
using System;

namespace StandAloneWidget.Security
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            //Set authentication Type & Login Path
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                    AuthenticationType = "ApplicationCookie",
                    LoginPath = new PathString("/Authorization/login")
                });

            UserManagerFactory = () =>
            {
                    var usermanager = new UserManager<AppUser>(
                        new UserStore<AppUser>(new AppDbContext()));

                    usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
                    {
                        AllowOnlyAlphanumericUserNames = false
                    };

                    return usermanager;
            };
        }




    }
}
