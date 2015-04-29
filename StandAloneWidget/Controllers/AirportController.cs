using SolutionZ.StandAloneWidget;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    public class AirportController : Controller
    {
        //
        // GET: /Airport/
        public ActionResult Index()
        {
            return View(new AirportsModel() { Airports = Airport.GetAll().OrderBy(x => x.Name).ToList(), airport = new Airport() } );
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
        /// POST /Airport/Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            //Instanciate deleted
            Airport deletedAirport = Airport.GetAirports(ID, null).First();

            //Delete
            Airport.Delete(deletedAirport);

            return RedirectToAction("Index", "Airport");
        }

    }
}
