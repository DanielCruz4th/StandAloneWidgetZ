using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;

namespace SolutionZ.StandAloneWidget
{
    public class CabinClass
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Crates Cabin Class
        /// </summary>
        /// <param name="cabinClass"></param>
        public static void Insert(CabinClass cabinClass)
        {
            if (cabinClass == null)
                throw new ArgumentNullException("cabinClass");

            using (var db = new StandAloneWidgetContext())
            {
                db.CabinClasses.Add(cabinClass);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update Cabin Class
        /// </summary>
        /// <param name="cabinClass"></param>
        public static void Update(CabinClass cabinClass)
        {
            if (cabinClass == null)
                throw new ArgumentNullException("cabinClass");

            using (var db = new StandAloneWidgetContext())
            {
                db.CabinClasses.Attach(cabinClass);
                db.Entry(cabinClass).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Cabin Class
        /// </summary>
        /// <param name="cabinClass"></param>
        public static void Delete(CabinClass cabinClass)
        {
            if (cabinClass == null)
                throw new ArgumentNullException("cabinClass");

            using (var db = new StandAloneWidgetContext())
            {
                db.CabinClasses.Attach(cabinClass);
                db.CabinClasses.Remove(cabinClass);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Cabin Class
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<CabinClass> GetCabinClass(string code)
        {
            List<CabinClass> list = new List<CabinClass>();

            using (var db = new StandAloneWidgetContext())
            {
                var query = from cabinClass in db.CabinClasses
                            where string.IsNullOrEmpty(code) || cabinClass.Code == code
                            select cabinClass;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get all Cabin Classes
        /// </summary>
        /// <returns></returns>
        public static List<CabinClass> GetAll()
        {
            return GetCabinClass(null);
        }

    }
}
