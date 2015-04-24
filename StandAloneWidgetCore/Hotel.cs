using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolutionZ.StandAloneWidget
{
    public class Hotel
    {
        /// <summary>
        /// Hotel ID - Guid
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        //TODO: Verify if catalog is viable
        public string City { get; set; }

        //TODO: Verify if catalog is viable
        public string State { get; set; }

        //TODO: Verify if catalog is viable
        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        // NOT IN SCOPE
        ////TODO: Check if Available
        ////public string POBox { get; set; }

        ////TODO: Verify if collection is viable
        //public string Phone { get; set; }

        //public bool OnlineBookings { get; set; }

        //public bool HotRates { get; set; }

        //public bool Video { get; set; }

        //public bool Brochure { get; set; }

        //public bool Overview { get; set; }

        //public bool Map { get; set; }

        ////TODO: Verify if catalog is viable
        //public string PriceBand { get; set; }

        ////TODO: Verifi if Decimal is viable
        //public int StarRating { get; set; }

        ////TODO: Verify if catalog is viable
        //public string StarSource { get; set; }

        ////TODO: Verify if catalog + collection is viable
        //public string Amenities { get; set; }

        //public string PopularityGrade { get; set; }

        //public string CollectionsGrade { get; set; }

        //public string SabreID { get; set; }

        ////TODO: Verify if collection is viable
        //public string RateLow { get; set; }

        //public string RateHight { get; set; }

        //public string Currency { get; set; }

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
        /// Creates Hotel in DB
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public static void Insert(Hotel hotel)
        {
            if (hotel == null)
                throw new ArgumentNullException("hotel");

            using (var db = new StandAloneWidgetContext())
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate Hotel
        /// </summary>
        /// <param name="hotel">Hotel instance</param>
        public static void Update(Hotel hotel)
        {
            if (hotel == null)
                throw new ArgumentNullException("hotel");

            using (var db = new StandAloneWidgetContext())
            {
                db.Hotels.Attach(hotel);
                db.Entry(hotel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Hotel
        /// </summary>
        /// <param name="Hotel">Hotel instance</param>
        public static void Delete(Hotel hotel)
        {
            if (hotel == null)
                throw new ArgumentNullException("hotel");

            using (var db = new StandAloneWidgetContext())
            {
                db.Hotels.Attach(hotel);
                db.Hotels.Remove(hotel);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all Hotels from DB
        /// </summary>
        /// <returns></returns>
        public static List<Hotel> GetHotels(Guid? id, string city, string state, string postalCode)
        {
            List<Hotel> list = new List<Hotel>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from hotel in db.Hotels
                            where !id.HasValue || hotel.ID == id.Value
                            where string.IsNullOrEmpty(city) || hotel.City == city
                            where string.IsNullOrEmpty(state) || hotel.State == state
                            where string.IsNullOrEmpty(postalCode) || hotel.PostalCode == postalCode
                            select hotel;

                list.AddRange(query);
            }

            return list;
        }



    }
}
