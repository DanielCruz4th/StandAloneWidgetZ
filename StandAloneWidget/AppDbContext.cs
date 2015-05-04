using Microsoft.AspNet.Identity.EntityFramework;
using StandAloneWidget.Controllers.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StandAloneWidget
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            :base("StandAloneWidget")
        {

        }
    }
}