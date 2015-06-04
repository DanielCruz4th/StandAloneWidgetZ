namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chainUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chains", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chains", "Code", c => c.String(maxLength: 5));
        }
    }
}
