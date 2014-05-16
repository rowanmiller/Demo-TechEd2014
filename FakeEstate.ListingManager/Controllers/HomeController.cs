using FakeEstate.ListingManager.Models.Listings;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FakeEstate.ListingManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly FakeEstateContext db;

        public HomeController()
            :this(new FakeEstateContext())
        { }

        public HomeController(FakeEstateContext context)
        {
            db = context;
        }

        public async Task<ViewResult> Index()
        {
            var query = db.Listings
                .Include(l => l.Photos)
                .OrderByDescending(l => l.ListingId)
                .Take(2);

            return View(await query.ToListAsync());
        }
    }
}