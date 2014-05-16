namespace FakeEstate.ListingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullText : DbMigration
    {
        public override void Up()
        {
            this.CreateFullTextIndex(
                "dbo.Listings",
                "PK_dbo.Listings",
                new[] { "Title", "Description" });
        }
        
        public override void Down()
        {
        }
    }
}
