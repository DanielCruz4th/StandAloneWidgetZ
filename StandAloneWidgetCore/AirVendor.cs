using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolutionZ.StandAloneWidget
{
    /// <summary>
    /// Air Vendor Class representing Airlines
    /// </summary>
    public class AirVendor
    {
        public AirVendor()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Air Vendor ID
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        [MaxLength(2)]
        [Index(IsUnique = true)]
        [StringLength(2)]
        public string Code { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Creates AirVendor in DB
        /// </summary>
        /// <param name="airVendor"></param>
        public static void Insert(AirVendor airVendor)
        {
            if (airVendor == null)
                throw new ArgumentNullException("airVendor");

            using(var db = new StandAloneWidgetContext())
            {
                db.AirVendors.Add(airVendor);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update Air Vendor
        /// </summary>
        /// <param name="airVendor"></param>
        public static void Update(AirVendor airVendor)
        {
            if (airVendor == null)
                throw new ArgumentNullException("airVendor");

            using (var db = new StandAloneWidgetContext())
            {
                db.AirVendors.Attach(airVendor);
                db.Entry(airVendor).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Air Vendor
        /// </summary>
        /// <param name="airVendor"></param>
        public static void Delete(AirVendor airVendor)
        {
            if (airVendor == null)
                throw new ArgumentNullException("airVendor");

            using (var db = new StandAloneWidgetContext())
            {
                db.AirVendors.Attach(airVendor);
                db.AirVendors.Remove(airVendor);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<AirVendor> GetAirVendors(Guid? id)
        {
            List<AirVendor> list = new List<AirVendor>();

            using (var db = new StandAloneWidgetContext())
            {
                var query = from airVendors in db.AirVendors
                            where !id.HasValue || airVendors.ID == id
                            select airVendors;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get All air vendors
        /// </summary>
        /// <returns></returns>
        public static List<AirVendor> GetAll()
        {
            return GetAirVendors(null);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<AirVendor> SearchAirVendors(string query)
        {
            List<AirVendor> list = new List<AirVendor>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var results = from airVendor in db.AirVendors
                              where (string.IsNullOrEmpty(query)
                                  || (!string.IsNullOrEmpty(airVendor.Code)
                                  && airVendor.Code.ToLower().StartsWith(query.ToLower())))
                                  || (string.IsNullOrEmpty(query)
                              || (!string.IsNullOrEmpty(airVendor.Name)
                              && airVendor.Name.ToLower().StartsWith(query.ToLower())))
                              select airVendor;

                list.AddRange(results);
            }

            return list;
        }

    }
}
