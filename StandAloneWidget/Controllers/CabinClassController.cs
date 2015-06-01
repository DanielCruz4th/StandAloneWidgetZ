using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace StandAloneWidget.Controllers
{
    public class CabinClassController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult Get()
        {
            //Retrieve
            List<CabinClass> valuesList = CabinClass.GetAll();
            return Json(valuesList, JsonRequestBehavior.AllowGet);
        }


    }
}
