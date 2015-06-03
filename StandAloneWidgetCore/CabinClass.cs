using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionZ.StandAloneWidget
{
    public class CabinClass
    {
        public CabinClass()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Cabin Class ID
        /// </summary>
        [Key]
        public Guid ID { get; set; }
        
        /// <summary>
        /// Cabin Class Code - Unique
        /// </summary>
        [Index(IsUnique = true)]
        [StringLength(25)]
        public string Code { get; set; }

        /// <summary>
        /// Cabin Class Name
        /// </summary>
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
        public static List<CabinClass> GetCabinClass(Guid? id)
        {
            List<CabinClass> list = new List<CabinClass>();

            using (var db = new StandAloneWidgetContext())
            {
                var query = from cabinClass in db.CabinClasses
                            where !id.HasValue || cabinClass.ID == id
                            select cabinClass;

                list.AddRange(query);
            }

            return list;
        }


        public static List<CabinClass> SearchCabinClass(string query)
        {
            List<CabinClass> list = new List<CabinClass>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var results = from cabinClass in db.CabinClasses
                              where (string.IsNullOrEmpty(query)
                                  || (!string.IsNullOrEmpty(cabinClass.Code)
                                  && cabinClass.Code.ToLower().StartsWith(query.ToLower())))
                                  || (string.IsNullOrEmpty(query)
                              || (!string.IsNullOrEmpty(cabinClass.Name)
                              && cabinClass.Name.ToLower().StartsWith(query.ToLower())))
                              select cabinClass;

                list.AddRange(results);
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
