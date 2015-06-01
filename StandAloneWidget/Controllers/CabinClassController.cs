using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    public class CabinClassController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public JsonResult Get()
        {
            //Retrieve
            List<CabinClass> valuesList = CabinClass.GetAll();
            string js = JsonConvert.SerializeObject(valuesList);

            return Json(js, JsonRequestBehavior.AllowGet);
        }
    }
}
