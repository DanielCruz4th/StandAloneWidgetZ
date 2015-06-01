namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CabinClassMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CabinClasses",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CabinClasses");
        }
    }
}
