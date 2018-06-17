namespace HSPackTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SetName = c.String(),
                        EpicCount = c.Int(nullable: false),
                        EpicPercentage = c.Int(nullable: false),
                        LegendaryCount = c.Int(nullable: false),
                        LegendaryPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pack");
        }
    }
}
