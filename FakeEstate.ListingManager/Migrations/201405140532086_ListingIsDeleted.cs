namespace FakeEstate.ListingManager.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ListingIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listings", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listings", "IsDeleted");
        }
    }
}
