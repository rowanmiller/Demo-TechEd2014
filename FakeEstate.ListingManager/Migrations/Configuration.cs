namespace FakeEstate.ListingManager.Migrations
{
    using FakeEstate.ListingManager.Models.EFHelpers;
    using FakeEstate.ListingManager.Models.Listings;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.SqlServer;

    internal sealed class Configuration : DbMigrationsConfiguration<FakeEstateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator(
                SqlProviderServices.ProviderInvariantName,
                new MyMigrationSqlGenerator());
        }
    }
}
