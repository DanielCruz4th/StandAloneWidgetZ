using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionZ.StandAloneWidget.BO;
using SolutionZ.StandAloneWidget.DAO;

namespace SolutionZ.StandAloneWidget.Services
{
    public class BrandFileCtrl
    {
        /// <summary>
        /// Get all Brand Files from DB
        /// </summary>
        /// <returns></returns>
        public static List<BrandFile> GetList()
        {
            List<BrandFile> list = new List<BrandFile>();

            using(var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from brandFiles in db.BrandFiles
                            orderby brandFiles.DateCreated
                            select brandFiles;

                //Iterate and add to list
                foreach (var item in query)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>
        /// Creates BrandFile in DB
        /// </summary>
        /// <param name="bo"></param>
        /// <returns></returns>
        public static BrandFile Create( BrandFile bo)
        {
            //Complete BO
            bo.DateCreated = DateTime.Now;

            using (var db = new StandAloneWidgetContext())
            {
                db.BrandFiles.Add(bo);
                db.SaveChanges();
            }

            return bo;
        }

    }
}
