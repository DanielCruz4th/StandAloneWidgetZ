namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityCodeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "Code", c => c.String());
        }
    }
}
