namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PointOfInterests",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PPNID = c.String(maxLength: 9),
                        PPNTID = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Category = c.String(),
                        IsLandmark = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.PPNID, unique: true);
            
            AddColumn("dbo.Cities", "Code", c => c.String());
            AddColumn("dbo.Cities", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropIndex("dbo.PointOfInterests", new[] { "PPNID" });
            DropColumn("dbo.Cities", "Country");
            DropColumn("dbo.Cities", "Code");
            DropTable("dbo.PointOfInterests");
        }
    }
}
