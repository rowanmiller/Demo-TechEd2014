namespace FakeEstate.ListingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipOrPostalCode = c.String(),
                        Country = c.String(),
                        SellingAgentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListingId)
                .ForeignKey("dbo.Agents", t => t.SellingAgentId, cascadeDelete: true)
                .Index(t => t.SellingAgentId);
            
            CreateTable(
                "dbo.ListingPhotoes",
                c => new
                    {
                        ListingPhotoId = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        Caption = c.String(),
                        ListingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListingPhotoId)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "SellingAgentId", "dbo.Agents");
            DropForeignKey("dbo.ListingPhotoes", "ListingId", "dbo.Listings");
            DropIndex("dbo.ListingPhotoes", new[] { "ListingId" });
            DropIndex("dbo.Listings", new[] { "SellingAgentId" });
            DropTable("dbo.ListingPhotoes");
            DropTable("dbo.Listings");
            DropTable("dbo.Agents");
        }
    }
}
