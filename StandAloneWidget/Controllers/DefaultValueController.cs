using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    public class DefaultValueController : Controller
    {
        //
        // GET: /DefaultValue/
        public ActionResult Index()
        {
            return View( new DefaultValuesModel() { DefaultValues = DefaultValue.GetAll() , Default = new DefaultValue() } );
        }

        /// <summary>
        /// GET: /DefaultValue/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            DefaultValue newDefault = new DefaultValue();
            newDefault.GenerateKeyString(10);

            return View(newDefault);
        }

        /// <summary>
        /// POST: /DefaultValue/Create
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(DefaultValue defaultValue)
        {
            //Persist
            //TODO: Replace with Session USER.
            defaultValue.CreatedBy = "UNKNOWN";
            defaultValue.DateCreated = DateTime.Now;

            DefaultValue.Insert(defaultValue);

            return RedirectToAction("Index", "DefaultValue");
        }

        /// <summary>
        /// GET: /DefaultValue/Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(string defaultKey)
        {
            return View(DefaultValue.GetDefaultValues(defaultKey).First());
        }

        /// <summary>
        /// POST: /DefaultValue/Update
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(DefaultValue defaultValue)
        {
            //Persist
            //TODO: Replace with Session USER.
            defaultValue.LastUdpatedDate = DateTime.Now;
            defaultValue.LastUpdatedBy = "UNKNOWN";

            DefaultValue.Update(defaultValue);

            return RedirectToAction("Index", "DefaultValue");
        }

        /// <summary>
        /// POST: /DefaultValue/Delete
        /// </summary>
        /// <param name="defaultKey"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string defaultKey)
        {

            DefaultValue deletedDefault = DefaultValue.GetDefaultValues(defaultKey).First();

            DefaultValue.Delete(deletedDefault);

            return RedirectToAction("Index", "DefaultValue");
        }

        /// <summary>
        /// Parse to JavaScriptResult
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public JavaScriptResult Parse()
        {

            //Retrieve
            List<DefaultValue> valuesList = DefaultValue.GetAll();
            string js = JsonConvert.SerializeObject(valuesList);
            
            return JavaScript(js);
        }

        /// <summary>
        /// JsonResult Example
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public JsonResult Get()
        {
            //Retrieve
            List<DefaultValue> valuesList = DefaultValue.GetAll();
            string js = JsonConvert.SerializeObject(valuesList);

            return Json(js, JsonRequestBehavior.AllowGet);
        }
    }
}
