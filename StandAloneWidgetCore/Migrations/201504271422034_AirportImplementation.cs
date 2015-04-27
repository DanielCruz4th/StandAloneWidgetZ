namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirportImplementation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(nullable: false, maxLength: 3),
                        Latitude = c.String(),
                        Longituded = c.String(),
                        Country = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Airports");
        }
    }
}
