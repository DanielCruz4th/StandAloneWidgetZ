using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace StandAloneWidget.Controllers.Security
{
    public class AppUserPrincipal : ClaimsPrincipal
    {

        public AppUserPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {

        }

        public string Name
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value;
            }
        }
    }
}