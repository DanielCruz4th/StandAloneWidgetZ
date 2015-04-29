using SolutionZ.StandAloneWidget;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    public class CarController : Controller
    {
        //
        // GET: /Car/
        public ActionResult Index()
        {
            return View(new CarsModel() { Cars = Car.GetAll().OrderBy(x => x.Name).ToList() , car = new Car() } );
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

        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            Car deletedCar = Car.GetCars(ID).First();

            //Delete
            Car.Delete(deletedCar);

            return RedirectToAction("Index", "Car");
        }

    

    }
}
