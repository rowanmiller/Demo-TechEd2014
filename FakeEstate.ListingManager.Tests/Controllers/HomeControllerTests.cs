using EntityFramework.Testing.Moq;
using FakeEstate.ListingManager.Controllers;
using FakeEstate.ListingManager.Models.Listings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeEstate.ListingManager.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public async Task Index_returns_two_newest_listings()
        {
            // Create some test data
            var data = new List<Listing>
            {
                new Listing { ListingId = 1 },
                new Listing { ListingId = 4 },
                new Listing { ListingId = 2 },
                new Listing { ListingId = 3 }
            };

            // TODO Create a mock set and context
            var set = new MockDbSet<Listing>()
                .SetupSeedData(data)
                .SetupLinq();

            var context = new Mock<FakeEstateContext>();
            context.Setup(c => c.Listings).Returns(set.Object);

            // TODO Create a HomeController and invoke the Index action
            var controller = new HomeController(context.Object);
            var result = await controller.Index();

            // TODO Check the results
            var listings = (List<Listing>)result.Model;
            Assert.AreEqual(2, listings.Count());
            Assert.AreEqual(4, listings[0].ListingId);
            Assert.AreEqual(3, listings[1].ListingId);
        }
    }
}
