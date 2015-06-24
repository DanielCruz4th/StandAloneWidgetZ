namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirportCarRentaNowAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Airports", "CarRentalAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Airports", "CarRentalAvailable");
        }
    }
}
