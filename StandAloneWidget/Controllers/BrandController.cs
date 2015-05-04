using Newtonsoft.Json;
using SolutionZ.StandAloneWidget;
using StandAloneWidget.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace StandAloneWidget
{
    public class BrandController : Controller
    {
        public int PageSize = 10;

        //
        // GET: /Brand/
        public ActionResult Index(int page = 1)
        {
            var query = Brand.GetAll();

            return View(new BrandsModel()
            {
                Brands = query.OrderBy(x => x.WidgetHeader)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize).ToList(),
                brand = new Brand(),
                PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = query.Count() }
            });
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

        public ActionResult Export()
        {
            return View();
        }

        [HttpGet]
        public JavaScriptResult ParseBrand(Guid ID)
        {
            try
            {
                //Declare variables
                string js = string.Empty;

                //Retrieve
                Brand brand = Brand.GetBrands(ID, null, null, null).First();
                string serializedBrand = JsonConvert.SerializeObject(brand);

                js = String.Format("alert('{0}')", serializedBrand);

                return JavaScript(js);
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
