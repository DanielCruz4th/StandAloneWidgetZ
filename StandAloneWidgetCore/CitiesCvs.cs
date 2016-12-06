using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SolutionZ.StandAloneWidget
{
    public class CitiesCvs
    {
        public CitiesCvs()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// ID - Guid
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        public string HotelCityId { get; set; }

        public string AirCityId { get; set; }

        public string Name { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public int HotelCount { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        
        /// <summary>
        /// Creates City in DB
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public static void Insert(CitiesCvs city)
        {
            if (city == null)
                throw new ArgumentNullException("CitiesCvs");

            using (var db = new StandAloneWidgetContext())
            {
                db.CitiesCvs.Add(city);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate City
        /// </summary>
        /// <param name="city">City instance</param>
        public static void Update(CitiesCvs city)
        {
            if (city == null)
                throw new ArgumentNullException("CitiesCvs");

            using (var db = new StandAloneWidgetContext())
            {
                db.CitiesCvs.Attach(city);
                db.Entry(city).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="city">City instance</param>
        public static void Delete(CitiesCvs city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            using (var db = new StandAloneWidgetContext())
            {
                db.CitiesCvs.Attach(city);
                db.CitiesCvs.Remove(city);
                db.SaveChanges();
            }
        }

        public static List<CitiesCvs> GetCities(Guid id)
        {
            return CitiesCvs.GetCities(id, null, null);
        }

        /// <summary>
        /// Get Cities from DB
        /// </summary>
        /// <returns></returns>
        public static List<CitiesCvs> GetCities(Guid? id, string name, bool? airCity)
        {
            List<CitiesCvs> list = new List<CitiesCvs>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from city in db.CitiesCvs
                            where !id.HasValue || city.ID == id.Value
                            where string.IsNullOrEmpty(name) || (!string.IsNullOrEmpty(city.Name) && city.Name.ToLower().Contains(name.ToLower()))
                           // where !airCity.HasValue || city.AirCity == airCity
                            select city;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get ALL Cities from DB
        /// </summary>
        /// <returns></returns>
        public static List<CitiesCvs> GetAll()
        {
            return GetCities(null, null, null);
        }


        public static List<CitiesCvs> SearchCities(string query, int? pageIndex, int pageSize)
        {
            List<CitiesCvs> list = new List<CitiesCvs>();
            int _page = pageIndex ?? 0;

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var results = from city in db.CitiesCvs
                              where string.IsNullOrEmpty(query)
                                  || (!string.IsNullOrEmpty(city.Name)
                                  && city.Name.ToLower().StartsWith(query.ToLower()))
                              select city;

                list.AddRange(results.OrderBy(x => x.Name).Skip(_page * pageSize).Take(pageSize));
            }

            return list;
        }


    }
}
