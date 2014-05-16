namespace FakeEstate.ListingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgentContactInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "Phone", c => c.String());
            AddColumn("dbo.Agents", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "Email");
            DropColumn("dbo.Agents", "Phone");
        }
    }
}
