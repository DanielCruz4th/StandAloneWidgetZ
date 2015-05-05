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
    public class ChainController : Controller
    {
        //
        // GET: /Chain/
        public ActionResult Index()
        {
            return View(new ChainsModel() { Chains = Chain.GetAll(), chain = new Chain() } );
        }

        /// <summary>
        /// GET: /Chain/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new Chain());
        }

        /// <summary>
        /// POST:  /Chain/Create
        /// </summary>
        /// <param name="chainr"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Chain chain)
        {
            //Persist
            //TODO: Replace with Session USER
            chain.CreatedBy = "UNKNOWN";
            chain.DateCreated = DateTime.Now;

            Chain.Insert(chain);

            return RedirectToAction("Index", "Chain");
        }

        /// <summary>
        /// GET: /Chain/Update
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Update(Guid ID)
        {
            return View(Chain.GetChains(ID).First());
        }

        /// <summary>
        /// POST: /Chain/Update
        /// </summary>
        /// <param name="chain"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Chain chain)
        {
            //Persist
            //TODO: Replace with Session USER
            chain.LastUdpatedDate = DateTime.Now;
            chain.LastUpdatedBy = "UNKNOW";

            Chain.Update(chain);

            return RedirectToAction("Index", "Chain");

        }

        /// <summary>
        /// POST: /Chain/Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            //Retrieve
            Chain deletedChain = Chain.GetChains(ID).First();

            //Persist
            Chain.Delete(deletedChain);

            //Return
            return RedirectToAction("Index", "Chain");

        }

        /// <summary>
        /// GET: /Chain/Parse
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
                Chain chain = Chain.GetChains(ID).First();
                js = JsonConvert.SerializeObject(chain);

                return JavaScript(js);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
