using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;


namespace SolutionZ.StandAloneWidget
{
    /// <summary>
    /// Air Vendor Class representing Airlines
    /// </summary>
    public class AirVendor
    {
        [Key]
        [MaxLength(2)]
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
        public static List<AirVendor> GetAirVendors(string code)
        {
            List<AirVendor> list = new List<AirVendor>();

            using (var db = new StandAloneWidgetContext())
            {
                var query = from airVendors in db.AirVendors
                            where string.IsNullOrEmpty(code) || airVendors.Code == code
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

    }
}
