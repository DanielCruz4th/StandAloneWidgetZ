using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    public class AirVendorController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public JsonResult Get()
        {
            //Retrieve
            List<AirVendor> valuesList = AirVendor.GetAll();
            string js = JsonConvert.SerializeObject(valuesList);

            return Json(js, JsonRequestBehavior.AllowGet);
        }

    }
}
