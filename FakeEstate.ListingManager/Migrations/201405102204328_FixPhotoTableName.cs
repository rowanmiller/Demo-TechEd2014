namespace FakeEstate.ListingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPhotoTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ListingPhotoes", newName: "ListingPhoto");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ListingPhoto", newName: "ListingPhotoes");
        }
    }
}
