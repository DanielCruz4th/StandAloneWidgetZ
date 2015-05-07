namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarsAdjustments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Code", c => c.String(maxLength: 2));
            AddColumn("dbo.Cars", "CompanyText", c => c.String());
            AddColumn("dbo.Cars", "TitleTag", c => c.String());
            AddColumn("dbo.Cars", "PrimaryPhoneNumber", c => c.String());
            AddColumn("dbo.Cars", "SecondaryPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "SecondaryPhoneNumber");
            DropColumn("dbo.Cars", "PrimaryPhoneNumber");
            DropColumn("dbo.Cars", "TitleTag");
            DropColumn("dbo.Cars", "CompanyText");
            DropColumn("dbo.Cars", "Code");
        }
    }
}
