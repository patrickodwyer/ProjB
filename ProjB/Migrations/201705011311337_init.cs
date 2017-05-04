namespace ProjB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(),
                        Venue = c.String(),
                        Price = c.Double(nullable: false),
                        StartTime = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "EventID", "dbo.Events");
            DropIndex("dbo.Customers", new[] { "EventID" });
            DropTable("dbo.Events");
            DropTable("dbo.Customers");
        }
    }
}
