namespace SolutionZ.StandAloneWidget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChainCodeImplementation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chains", "Code", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chains", "Code");
        }
    }
}
