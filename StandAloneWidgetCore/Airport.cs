using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolutionZ.StandAloneWidget
{
    public class Airport
    {
        public Airport()
        {
            this.ID = Guid.NewGuid();

        }


        /// <summary>
        /// ID - Guid
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        [MaxLength(3)]
        [Required]
        public string Code { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Country { get; set; }

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
        /// Creates Airport in DB
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        public static void Insert(Airport airport)
        {
            if (airport == null)
                throw new ArgumentNullException("airport");

            using (var db = new StandAloneWidgetContext())
            {
                db.Airports.Add(airport);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate Airport
        /// </summary>
        /// <param name="chain">Airport instance</param>
        public static void Update(Airport airport)
        {
            if (airport == null)
                throw new ArgumentNullException("airport");

            using (var db = new StandAloneWidgetContext())
            {
                db.Airports.Attach(airport);
                db.Entry(airport).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Airport
        /// </summary>
        /// <param name="airport">Airport instance</param>
        public static void Delete(Airport airport)
        {
            if (airport == null)
                throw new ArgumentNullException("airport");

            using (var db = new StandAloneWidgetContext())
            {
                db.Airports.Attach(airport);
                db.Airports.Remove(airport);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Airports from DB
        /// </summary>
        /// <returns></returns>
        public static List<Airport> GetAirports(Guid? id)
        {
            return Airport.GetAirports(id, null, null);
        }

        public static List<Airport> GetAirports(Guid? id, string code)
        {
            return Airport.GetAirports(id, code, null);
        }

        public static List<Airport> GetAirports(Guid? id , string code, string name)
        {
            List<Airport> list = new List<Airport>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from airport in db.Airports
                            where !id.HasValue || airport.ID == id.Value
                            where string.IsNullOrEmpty(code) 
                                || (!string.IsNullOrEmpty(airport.Code)
                                && airport.Code.ToLower().StartsWith(code.ToLower()))
                            where string.IsNullOrEmpty(name)
                            || (!string.IsNullOrEmpty(airport.Name)
                            && airport.Name.ToLower().StartsWith(name.ToLower()))
                            select airport;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get ALL airports
        /// </summary>
        /// <returns></returns>
        public static List<Airport> GetAll()
        {
            return Airport.GetAirports(null, null, null);
        }

    }
}
