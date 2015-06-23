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
    public class CarController : Controller
    {
        //
        // GET: /Car/
        public ActionResult Index()
        {
            return View(new CarsModel() { Cars = Car.GetAll().OrderBy(x => x.Name).ToList(), car = new Car() });
        }

        /// <summary>
        /// GET: /Car/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new Car());
        }

        /// <summary>
        /// POST: /Car/Create
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Car car)
        {
            //Persist
            //TODO: Replace with Session USER.
            car.CreatedBy = "UNKNOWN";
            car.DateCreated = DateTime.Now;

            Car.Insert(car);

            return RedirectToAction("Index", "Car");
        }

        /// <summary>
        /// GET: /Car/Udpate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(Guid id)
        {
            return View(Car.GetCars(id).First());
        }

        /// <summary>
        /// POST: /Car/Update
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Car car)
        {
            //Complete & Persist
            //TODO: Replace with Session USER
            car.LastUpdatedBy = "UNKNOWN";
            car.LastUdpatedDate = DateTime.Now;

            //Perssit
            Car.Update(car);

            return RedirectToAction("Index", "Car");

        }

        /// <summary>
        /// POST: /Car/Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            Car deletedCar = Car.GetCars(ID).First();

            //Delete
            Car.Delete(deletedCar);

            return RedirectToAction("Index", "Car");
        }


        /// <summary>
        /// GET: /Car/Parse
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
                Car car = Car.GetCars(ID).First();
                js = JsonConvert.SerializeObject(car);

                return JavaScript(js);

            }
            catch (Exception)
            {
                throw;
            }
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
            List<Car> carList = Car.GetAll();
            return Json(carList, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult Search(string query)
        {
            return Json(
                Car.SearchCars(query).Take(100),
                JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult Pickup(string query)
        {

            var codes = from item in Airport.SearchAirports(query , null, Functions.DefaultPageSize())
                        select new
                        {
                            type = "AIR",
                            key = item.Code,
                            value = item.Name
                        };


            var cities = from item in City.GetCities(null, query).Take(30)
                         select new
                         {
                             type = "CITY",
                             key = item.Code.ToString(),
                             value = String.Format("{0}, {1}", item.Name, item.State)
                         };

            
            return Json(codes.Union(cities), JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult DropOff(string query)
        {

            var codes = from code in Airport.SearchAirports(query, null, Functions.DefaultPageSize())
                        select new
                        {
                            type = "AIR",
                            key =  code.Code,
                            value = code.Name
                        };

            return Json(codes , JsonRequestBehavior.AllowGet);
        }



    }
}
