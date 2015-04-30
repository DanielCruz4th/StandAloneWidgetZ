using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
            //Un-Commnent if Security is Required.
            //filters.Add(new AuthorizeAttribute());
        }
    }
}