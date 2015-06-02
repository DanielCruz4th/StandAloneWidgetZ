namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirVendorIDImplementation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AirVendors");
            AddColumn("dbo.AirVendors", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.AirVendors", "Code", c => c.String(maxLength: 2));
            AddPrimaryKey("dbo.AirVendors", "ID");
            CreateIndex("dbo.AirVendors", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AirVendors", new[] { "Code" });
            DropPrimaryKey("dbo.AirVendors");
            AlterColumn("dbo.AirVendors", "Code", c => c.String(nullable: false, maxLength: 2));
            DropColumn("dbo.AirVendors", "ID");
            AddPrimaryKey("dbo.AirVendors", "Code");
        }
    }
}
