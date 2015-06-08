using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using StandAloneWidget.Base;
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
    public class CityController : Controller
    {
        //
        // GET: /City
        public ActionResult Index()
        {
            return View( new CitiesModel() { Cities = City.GetAll().OrderBy(x => x.Name).ToList() , city = new City() } );
        }

        /// <summary>
        /// GET: /City/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new City());
        }

        /// <summary>
        /// POST: /City/Create
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(City city)
        {
            //Persist
            //TODO: Replace with Session USER
            city.CreatedBy = "UNKNOW";
            city.DateCreated = DateTime.Now;

            City.Insert(city);

            return RedirectToAction("Index", "City");

        }

        /// <summary>
        /// GET: /City/Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(Guid id)
        {
            return View(City.GetCities(id).First());
        }

        /// <summary>
        /// POST: /City/Update
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(City city)
        {
            //Persist
            //TODO: Replace with Session USER
            city.LastUdpatedDate = DateTime.Now;
            city.LastUpdatedBy = "UNKNOWN";

            City.Update(city);

            return RedirectToAction("Index", "City");
        }

        /// <summary>
        /// POST: /City/Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            //Retrieve
            City deletedCity = City.GetCities(ID).First();

            //Persist
            City.Delete(deletedCity);

            //Ret
            return RedirectToAction("Index", "City");
        }


        /// <summary>
        /// JsonResult
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult Get()
        {
            //Retrieve
            List<City> cityList = City.GetAll();
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// GET: /City/Parse
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public JavaScriptResult Parse(Guid ID)
        {
            try
            {
                //Declare variables
                string js = string.Empty;

                //Retrieve
                City city = City.GetCities(ID).First();
                js = JsonConvert.SerializeObject(city);

                return JavaScript(js);

            }
            catch (Exception)
            {
                throw;
            }
        }


        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult Search(string query)
        {
            return Json(
                City.SearchCities(query , null, Functions.DefaultPageSize() ), 
                JsonRequestBehavior.AllowGet);
        }



    }
}
