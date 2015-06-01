using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SolutionZ.StandAloneWidget;

namespace SolutionZ.StandAloneWidget
{
    public partial class StandAloneWidgetContext : DbContext
    {

        public StandAloneWidgetContext()
            : base("StandAloneWidget")
        {
            //LazyLoading config
            //this.Configuration.LazyLoadingEnabled = false;
        }


        /// <summary>
        /// BrandFiles DBContext
        /// </summary>
        public DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Hotels DBContext
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }

        /// <summary>
        /// Default Values DBContext
        /// </summary>
        public DbSet<DefaultValue> DefaultValues { get; set; }

        /// <summary>
        /// Cities DBContext
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Chains DBContext
        /// </summary>
        public DbSet<Chain> Chains { get; set; }

        /// <summary>
        /// Cars DBContext
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Airports Context
        /// </summary>
        public DbSet<Airport> Airports { get; set; }

        /// <summary>
        /// Air Vendors Context
        /// </summary>
        public DbSet<AirVendor> AirVendors { get; set; }



    }
}

