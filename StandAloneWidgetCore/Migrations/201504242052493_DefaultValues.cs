namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultValues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultValues",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUdpatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DefaultValues");
        }
    }
}
