namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandFileUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BrandFiles", "LastUdpatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BrandFiles", "LastUdpatedDate", c => c.DateTime(nullable: false));
        }
    }
}
