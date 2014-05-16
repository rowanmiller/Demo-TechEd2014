using FakeEstate.ListingManager.Models.Listings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FakeEstate.ListingManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Automatically create the database and seed it with data
            // if it doesn't exist
            Database.SetInitializer<FakeEstateContext>(null);
            using (var db = new FakeEstateContext())
            {
                if(!db.Database.Exists())
                {
                    db.Database.Create();
                    AddSeedData(db);
                }
            }
        }

        public static void AddSeedData(FakeEstateContext db)
        {
            var agent = new Agent { FirstName = "Rowan", LastName = "Miller" };
            db.Agents.Add(agent);

            db.Listings.AddRange(new List<Listing> 
            {
                new Listing
                {
                    Title = "Pavers, Pansies and Prestige!",
                    Description = "Beautiful gardens, superb architecture and amazing attention to detail make this luxurious abode a one off home.",
                    Price = 850000,
                    Status = ListingStatus.Active,
                    Street = "100 Imaginary Lane",
                    City = "Redmond",
                    State = "WA",
                    ZipOrPostalCode = "98052",
                    Country = "United States",
                    SellingAgentId = 1,
                    Photos =
                    {
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing1_1.jpg", Caption = "Stunning entrance" },
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing1_2.jpg", Caption = "The lounge" },
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing1_3.jpg", Caption = "Well appointed den" }
                    }
                },
                new Listing
                {
                    Title = "Own ‘The American Dream’",
                    Description = "Complete with the white picket fence! Generously portioned living spaces and all the creature comforts make this stylish suburban property a must have.",
                    Price = 400000,
                    Status = ListingStatus.Sold,
                    Street = "42 Make Believe Place",
                    City = "Redmond",
                    State = "WA",
                    ZipOrPostalCode = "98052",
                    Country = "United States",
                    SellingAgentId = 1,
                    Photos =
                    {
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing2_1.jpg", Caption = "Sorry, this one is gone!" },
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing2_2.jpg", Caption = "The master bedroom" }
                    }
                },
                new Listing
                {
                    Title = "Peaceful Living Close to the City",
                    Description = "Escape the rat race with this superb property nestled in a quite valley surrounded by forest and hiking trails. All this just 25 miles from downtown.",
                    Price = 675000,
                    Status = ListingStatus.Active,
                    Street = "2200 No Such Place",
                    City = "Redmond",
                    State = "WA",
                    ZipOrPostalCode = "98052",
                    Country = "United States",
                    SellingAgentId = 1,
                    Photos =
                    {
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing3_1.jpg", Caption = "Curbside appeal" },
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing3_2.jpg", Caption = "Sunny dining" }
                    }
                },
                new Listing
                {
                    Title = "Location, Location, Location!",
                    Description = "'A renovators dream', 'amazing potential' and many other clichés fit this rustic waterfront property. Get your power tools handy for this little bargain.",
                    Price = 180000,
                    Status = ListingStatus.Active,
                    Street = "12 Nonexistent Avenue",
                    City = "Redmond",
                    State = "WA",
                    ZipOrPostalCode = "98052",
                    Country = "United States",
                    SellingAgentId = 1,
                    Photos =
                    {
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing4_1.jpg", Caption = "Curbside appeal" },
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing4_2.jpg", Caption = "Sunny dining" }
                    }
                },
                new Listing
                {
                    Title = "Majestic Mansion with Beautiful Gardens",
                    Description = "No expense spared on this amazing one off property. Complete with sauna, hot tub, heated pool, fitness room and your own theater.",
                    Price = 2800000,
                    Status = ListingStatus.Active,
                    Street = "356 Expensive Street",
                    City = "Redmond",
                    State = "WA",
                    ZipOrPostalCode = "98052",
                    Country = "United States",
                    SellingAgentId = 1,
                    Photos =
                    {
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing5_1.jpg", Caption = "Curbside appeal" },
                        new ListingPhoto { PhotoUrl = @"~/PhotoUploads/Listing5_2.jpg", Caption = "Sunny dining" }
                    }
                }
            });

            db.SaveChanges();
        }
    }
}