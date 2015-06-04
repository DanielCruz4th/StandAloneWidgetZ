namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POIFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointOfInterests", "PPNCityID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointOfInterests", "PPNCityID");
        }
    }
}
