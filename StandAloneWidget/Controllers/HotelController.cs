using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        public ActionResult Index()
        {
            return View( new HotelsModel() { Hotels = Hotel.GetAll().OrderBy(x => x.Name).ToList() , hotel = new Hotel() } );
        }

        /// <summary>
        /// GET: /Hotel/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new Hotel());
        }

        /// <summary>
        /// POST: /Hotel/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Hotel hotel)
        {
            //Persist
            //TODO: Replace with Session USER
            hotel.CreatedBy = "UNKNOWN";
            hotel.DateCreated = DateTime.Now;

            Hotel.Insert(hotel);

            return RedirectToAction("Index", "Hotel");

        }

        /// <summary>
        /// GET: /Hotel/Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(Guid id)
        {
            return View(Hotel.GetHotels(id, null, null, null).First());
        }

        /// <summary>
        /// POST: /Hotel/Update
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Hotel hotel)
        {
            //Persist
            //TODO: Replace with Session USER
            hotel.LastUdpatedDate = DateTime.Now;
            hotel.LastUpdatedBy = "UNKNON";

            Hotel.Update(hotel);

            return RedirectToAction("Index", "Hotel");
        }

        /// <summary>
        /// POST: /Hotel/Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            //Retrieve
            Hotel deletedHotel = Hotel.GetHotels(ID, null, null, null).First();

            Hotel.Delete(deletedHotel);

            return RedirectToAction("Index", "Hotel");
        }

        /// <summary>
        /// GET: /Hotel/Parse
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
                Hotel hotel = Hotel.GetHotels(ID ,null, null, null).First();
                js = JsonConvert.SerializeObject(hotel);

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
        public JsonResult Get()
        {
            //Retrieve
            List<Hotel> hotelList = Hotel.GetAll();
            return Json(JsonConvert.SerializeObject(hotelList), JsonRequestBehavior.AllowGet);
        }

    }
}
