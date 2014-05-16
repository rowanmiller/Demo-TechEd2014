using FakeEstate.ListingManager.Models.EFHelpers;
using System.Data.Entity;

namespace FakeEstate.ListingManager.Models.Listings
{
    public class EntityFrameworkConfiguration : DbConfiguration
    {
        public EntityFrameworkConfiguration()
        {
            AddInterceptor(new SoftDeleteInterceptor());
        }
    }
}