using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using StandAloneWidget.Base;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using System.Device.Location;
using StandAloneWidget.Models.Search;

namespace StandAloneWidget.Controllers
{
    public class AirportController : Controller
    {
        //
        // GET: /Airport/
        public ActionResult Index()
        {
            return View(new AirportsModel { Airports = Airport.GetAll().OrderBy(x => x.Name).ToList(), airport = new Airport() });
        }

        /// <summary>
        /// GET: /Airport/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new Airport());
        }

        /// <summary>
        /// POST: /Airport/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Airport airport)
        {
            //Complete & Persist
            //TODO: Replace with Session USER
            airport.CreatedBy = "UNKNOW";
            airport.DateCreated = DateTime.Now;

            Airport.Insert(airport);

            return RedirectToAction("Index", "Airport");
        }

        /// <summary>
        /// Update GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(Guid id)
        {
            return View(Airport.GetAirports(id, null).First());
        }

        /// <summary>
        /// POST /Airport/Update
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Airport airport)
        {
            //Complete & Persist
            //TODO: Replace with Session USER
            airport.LastUdpatedDate = DateTime.Now;
            airport.LastUpdatedBy = "UNKNOWN";

            Airport.Update(airport);

            return RedirectToAction("Index", "Airport");

        }

        /// <summary>
        /// POST: /Airport/Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            //Instanciate deleted
            Airport deletedAirport = Airport.GetAirports(id, null).First();

            //Delete
            Airport.Delete(deletedAirport);

            return RedirectToAction("Index", "Airport");
        }

        /// <summary>
        /// GET: /Airport/Parse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public JavaScriptResult Parse(Guid id)
        {
            try
            {
                //Declare variables
                string js = string.Empty;

                //Retrieve
                Airport airport = Airport.GetAirports(id).First();
                js = JsonConvert.SerializeObject(airport);

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
        public JsonResult Get(Guid? id, string code, string name)
        {
            return Json(
                Airport.GetAirports(id, code, name),
                JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult Search(string query)
        {
            return Json(
                Airport.SearchAirports(query, null, Functions.DefaultPageSize()),
                JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public JsonResult OriginDestination(string query)
        {
            var codes = from item in Airport.SearchAirports(query, null, Functions.DefaultPageSize())
                        select new DestinationModel
                        {
                            type = "AIR",
                            key = item.Code,
                            value = item.Name
                        };

            if (codes.ToList().Count == 0)
            {
                var cities = GetCities(query);

                if (cities.Count > 0)
                {
                    List<DestinationModel> airports = GetNearestAirport(cities.First());
                    //var listAirport = new List<DestinationModel>
                    //{
                    //    airport
                    //};
                    return Json(airports, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(codes, JsonRequestBehavior.AllowGet);
        }

        private List<CitiesCvs> GetCities(string query)
        {
            var cities = CitiesCvs.GetCities(null, query, true);
            return cities;
        }

        private List<DestinationModel> GetNearestAirport(CitiesCvs centralСity)
        {
            var cityCoord = new GeoCoordinate(centralСity.Latitude, centralСity.Longitude);
            var allAiroports = Airport.GetAll();
            var airportDistanceModels = new List<AirportDistanceModel>();

            foreach (var airport in allAiroports)
            {
                var airportModel = GetAirportModel(airport, cityCoord);
                airportDistanceModels.Add(airportModel);
            }

            var nearestAirports = airportDistanceModels
                .OrderBy(x => x.DistanceToCity)
                .Select(s => new DestinationModel()
            {
                type = "AIR",
                key = s.Airport.Code,
                value = s.Airport.Name
            })
            .Take(5)
            .ToList();


            return nearestAirports;
        }

        private AirportDistanceModel GetAirportModel(Airport airport, GeoCoordinate cityCoord)
        {
            double latitude = Convert.ToDouble(airport.Latitude);
            double longitude = Convert.ToDouble(airport.Longitude);
            var airportCoord = new GeoCoordinate(latitude, longitude);
            double distanceToAirPort = cityCoord.GetDistanceTo(airportCoord);

            return new AirportDistanceModel
            {
                Airport = airport,
                DistanceToCity = distanceToAirPort
            };
        }
    }
}
