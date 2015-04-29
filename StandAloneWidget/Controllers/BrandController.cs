using SolutionZ.StandAloneWidget;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget
{
    public class BrandController : Controller
    {
        //
        // GET: /Brand/
        public ActionResult Index()
        {
            return View(new BrandsModel() { Brands = Brand.GetAll().OrderBy(x=>x.WidgetHeader).ToList() , brand = new Brand()});
        }

        /// <summary>
        /// GET: /Brand/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new Brand());
        }

        /// <summary>
        /// POST: /Brand/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            //Persist
            //TODO: Replace with Session USER.
            brand.CreatedBy = "UNKNOWN";
            brand.DateCreated = DateTime.Now;
            Brand.Insert(brand);

            return RedirectToAction("Index", "Brand");
        }

        /// <summary>
        /// Update GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(Guid id)
        {
            return View(Brand.GetBrands(id, null, null, null).First());
        }

        /// <summary>
        /// Update POST
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Brand brand)
        {
            //Complete & Persist
            //TODO: Replace with Session USER
            brand.LastUpdatedBy = "UNKNOWN";
            brand.LastUdpatedDate = DateTime.Now;

            //Persist
            Brand.Update(brand);

            return RedirectToAction("Index", "Brand");
        }

        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            Brand deletedBrand = Brand.GetBrands(ID, null, null, null).First();

            //Delete
            Brand.Delete(deletedBrand);

            return RedirectToAction("Index", "Brand");
        }
    }
}
