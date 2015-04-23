namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBrandFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandFiles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        WidgetHeader = c.String(),
                        DepartureDate = c.String(),
                        LenghtOfStaty = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        HotelBrandDefault = c.String(),
                        HotelStarsRateDefault = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BrandFiles");
        }
    }
}
