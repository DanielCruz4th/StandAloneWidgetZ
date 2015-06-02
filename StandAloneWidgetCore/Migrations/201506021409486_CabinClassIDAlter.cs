namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CabinClassIDAlter : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CabinClasses");
            AddColumn("dbo.CabinClasses", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.CabinClasses", "Code", c => c.String(maxLength: 25));
            AddPrimaryKey("dbo.CabinClasses", "ID");
            CreateIndex("dbo.CabinClasses", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CabinClasses", new[] { "Code" });
            DropPrimaryKey("dbo.CabinClasses");
            AlterColumn("dbo.CabinClasses", "Code", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.CabinClasses", "ID");
            AddPrimaryKey("dbo.CabinClasses", "Code");
        }
    }
}
