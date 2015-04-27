namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChainImplementation : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chains");
        }
    }
}
