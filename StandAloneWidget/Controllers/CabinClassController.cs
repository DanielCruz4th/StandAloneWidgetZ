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
    public class CabinClassController : Controller
    {
        /// <summary>
        /// GET: /Cabin Class
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new CabinClassModel() { CabinClasses = CabinClass.GetAll(), CabinClass = new CabinClass() });
        }

        /// <summary>
        /// GET: /CabinClass/Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CabinClass());
        }

        /// <summary>
        /// POST: /CabinClass/Create
        /// </summary>
        /// <param name="cabinClass"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(CabinClass cabinClass)
        {
            CabinClass.Insert(cabinClass);
            return RedirectToAction("Index", "CabinClass");

        }

        /// <summary>
        /// GET: /CabinClass/Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update(string id)
        {
            return View(CabinClass.GetCabinClass(id).First());
        }

        /// <summary>
        /// POST: /CabinClass/Update
        /// </summary>
        /// <param name="cabinClass"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(CabinClass cabinClass)
        {
            CabinClass.Update(cabinClass);
            return RedirectToAction("Index", "CabinClass");
        }

        /// <summary>
        /// POST: /CabinClass/Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string Code)
        {
            CabinClass deleteCabinClass = CabinClass.GetCabinClass(Code).First();
            return RedirectToAction("Index", "CabinClass");
        }


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
