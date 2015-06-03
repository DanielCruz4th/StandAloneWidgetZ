using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolutionZ.StandAloneWidget
{
    public class PointOfInterest
    {
        public PointOfInterest()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Air Vendor ID
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        [MaxLength(9)]
        [Index(IsUnique = true)]
        [StringLength(9)]
        public string PPNID { get; set;  }

        public string PPNTID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Category { get; set; }

        public bool IsLandmark { get; set; }

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


        public static List<PointOfInterest> SearchPointsOfInterest(string query)
        {
            List<PointOfInterest> list = new List<PointOfInterest>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var results = from poi in db.PointsOfInterest
                              where string.IsNullOrEmpty(query)
                                  || (!string.IsNullOrEmpty(poi.Name)
                                  && poi.Name.ToLower().StartsWith(query.ToLower()))
                              select poi;

                list.AddRange(results);
            }

            return list;
        }
    }
}
