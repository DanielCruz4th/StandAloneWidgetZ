﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolutionZ.StandAloneWidget
{
    public class City
    {
        public City()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// ID - Guid
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        /// <summary>
        /// Date Created - Audit
        /// Must not be null
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Created By - Audit
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Last Updated Date
        /// </summary>
        public DateTime? LastUdpatedDate { get; set; }

        /// <summary>
        /// Last Updated By
        /// </summary>
        public string LastUpdatedBy { get; set; }



        /// <summary>
        /// Creates City in DB
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public static void Insert(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            using (var db = new StandAloneWidgetContext())
            {
                db.Cities.Add(city);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate City
        /// </summary>
        /// <param name="city">City instance</param>
        public static void Update(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            using (var db = new StandAloneWidgetContext())
            {
                db.Cities.Attach(city);
                db.Entry(city).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="city">City instance</param>
        public static void Delete(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            using (var db = new StandAloneWidgetContext())
            {
                db.Cities.Attach(city);
                db.Cities.Remove(city);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Cities from DB
        /// </summary>
        /// <returns></returns>
        public static List<City> GetCities(Guid? id)
        {
            List<City> list = new List<City>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from city in db.Cities
                            where !id.HasValue || city.ID == id.Value
                            select city;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get ALL Cities from DB
        /// </summary>
        /// <returns></returns>
        public static List<City> GetAll()
        {
            return GetCities(null);
        }



    }
}
