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

        }


        /// <summary>
        /// BrandFiles DBContext
        /// </summary>
        public DbSet<Brand> Brands { get; set; }

    }
}

