using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionZ.StandAloneWidget.BO
{
    /// <summary>
    /// BrandFile Class
    /// </summary>
    public class BrandFile
    {
        /// <summary>
        /// BrandFile ID - Guid
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Widget Header
        /// </summary>
        public string WidgetHeader { get; set; }

        /// <summary>
        /// Departure Date
        /// </summary>
        public string DepartureDate { get; set; }

        /// <summary>
        /// Length of Stay
        /// </summary>
        public string LenghtOfStaty { get; set; }

        /// <summary>
        /// Address - Default
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// PostalCode
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Hotel Brand Default
        /// </summary>
        public string HotelBrandDefault { get; set; }

        /// <summary>
        /// Hotel Stars Default
        /// </summary>
        public int HotelStarsRateDefault { get; set; }

        /// <summary>
        /// Date Created - Audit
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Created By - Audit
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Last Updated Date
        /// </summary>
        public DateTime LastUdpatedDate { get; set; }

        /// <summary>
        /// Last Updated By
        /// </summary>
        public string LastUpdatedBy { get; set; }




    }
}
