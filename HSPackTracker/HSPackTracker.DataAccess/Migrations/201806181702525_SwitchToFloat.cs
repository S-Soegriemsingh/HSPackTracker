namespace HSPackTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pack", "EpicCount", c => c.Double(nullable: false));
            AlterColumn("dbo.Pack", "EpicPercentage", c => c.Double(nullable: false));
            AlterColumn("dbo.Pack", "LegendaryCount", c => c.Double(nullable: false));
            AlterColumn("dbo.Pack", "LegendaryPercentage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pack", "LegendaryPercentage", c => c.Int(nullable: false));
            AlterColumn("dbo.Pack", "LegendaryCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Pack", "EpicPercentage", c => c.Int(nullable: false));
            AlterColumn("dbo.Pack", "EpicCount", c => c.Int(nullable: false));
        }
    }
}
