namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirportAdjust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Airports", "Longitude", c => c.String());
            DropColumn("dbo.Airports", "Longituded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Airports", "Longituded", c => c.String());
            DropColumn("dbo.Airports", "Longitude");
        }
    }
}
