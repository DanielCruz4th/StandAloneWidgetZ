namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultChange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DefaultValues");
            AddColumn("dbo.DefaultValues", "DefaultKey", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DefaultValues", "DefaultKey");
            DropColumn("dbo.DefaultValues", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DefaultValues", "Key", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.DefaultValues");
            DropColumn("dbo.DefaultValues", "DefaultKey");
            AddPrimaryKey("dbo.DefaultValues", "Key");
        }
    }
}
