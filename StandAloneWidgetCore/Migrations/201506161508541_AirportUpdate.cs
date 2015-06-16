namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirportUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Airports", "StateCode", c => c.String(maxLength: 2));
            AddColumn("dbo.Airports", "CountryCode", c => c.String(maxLength: 2));
            AddColumn("dbo.Airports", "RankScorePPN", c => c.Int(nullable: false));
            DropColumn("dbo.Airports", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Airports", "Country", c => c.String());
            DropColumn("dbo.Airports", "RankScorePPN");
            DropColumn("dbo.Airports", "CountryCode");
            DropColumn("dbo.Airports", "StateCode");
        }
    }
}
