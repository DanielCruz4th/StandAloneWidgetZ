using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace StandAloneWidget.Controllers
{
    public class AirVendorController : Controller
    {

        //
        // GET: /Airport/
        public ActionResult Index()
        {
            return View(new AirVendorModel() { AirVendors = AirVendor.GetAll().OrderBy(x => x.Name).ToList(), AirVendor = new AirVendor() });
        }

        /// <summary>
        /// GET: /AirVendor/Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new AirVendor());
        }

        /// <summary>
        /// POST: /AirVendor/Create
        /// </summary>
        /// <param name="airVendor"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(AirVendor airVendor)
        {
            AirVendor.Insert(airVendor);

            return RedirectToAction("Index", "AirVendor");
        }

        /// <summary>
        /// GET: /AirVendor/Udpate
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            return View(AirVendor.GetAirVendors(id).First());
        }

        /// <summary>
        /// POST: /AirVendor/Udpate
        /// </summary>
        /// <param name="airVendor"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Udpate(AirVendor airVendor)
        {
            AirVendor.Update(airVendor);

            return RedirectToAction("Index", "AirVendor");

        }

        /// <summary>
        /// POST: /AirVendor/Delete
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            AirVendor deletedAirVendor = AirVendor.GetAirVendors(id).First();
            AirVendor.Delete(deletedAirVendor);

            return RedirectToAction("Index", "AirVendor");
        }


        /// <summary>
        /// Json WebService to get all Airvendors
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult Get()
        {
            //Retrieve
            List<AirVendor> valuesList = AirVendor.GetAll();
            return Json(valuesList, JsonRequestBehavior.AllowGet);
        }

    }
}
