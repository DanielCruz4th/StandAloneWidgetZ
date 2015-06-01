namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AirVendors",
                c => new
                {
                    Code = c.String(nullable: false, maxLength: 2),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Code);

            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(nullable: false, maxLength: 3),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Country = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            

            
            CreateTable(
                "dbo.Brands",
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
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(maxLength: 2),
                        CompanyText = c.String(),
                        TitleTag = c.String(),
                        PrimaryPhoneNumber = c.String(),
                        SecondaryPhoneNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Chains",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        State = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DefaultValues",
                c => new
                    {
                        DefaultKey = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.DefaultKey);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hotels");
            DropTable("dbo.DefaultValues");
            DropTable("dbo.Cities");
            DropTable("dbo.Chains");
            DropTable("dbo.Cars");
            DropTable("dbo.Brands");
            DropTable("dbo.AirVendors");
            DropTable("dbo.Airports");
        }
    }
}
