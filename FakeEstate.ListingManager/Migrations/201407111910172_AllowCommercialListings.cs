namespace FakeEstate.ListingManager.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AllowCommercialListings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommercialListings",
                c => new
                    {
                        ListingId = c.Int(nullable: false),
                        ApprovedUses = c.String(),
                    })
                .PrimaryKey(t => t.ListingId)
                .ForeignKey("dbo.Listings", t => t.ListingId)
                .Index(t => t.ListingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommercialListings", "ListingId", "dbo.Listings");
            DropIndex("dbo.CommercialListings", new[] { "ListingId" });
            DropTable("dbo.CommercialListings");
        }
    }
}
