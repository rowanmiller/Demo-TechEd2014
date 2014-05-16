using FakeEstate.ListingManager.Models.Listings;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FakeEstate.ListingManager.Controllers
{
    public class ListingsController : Controller
    {
        private readonly FakeEstateContext db;

        public ListingsController()
            :this(new FakeEstateContext())
        { }

        public ListingsController(FakeEstateContext context)
        {
            db = context;
        }

        public async Task<ActionResult> Index()
        {
            var listings = await db.Listings.ToListAsync();

            // Load related photos in a separate query
            await db.ListingPhotos.LoadAsync();

            return View(listings);
        }

        public async Task<ActionResult> Search(string term)
        {
            var table = db.GetTableName(typeof(Listing));

            var sql = string.Format(
                "SELECT * FROM {0} WHERE CONTAINS((Title, Description), @p0)",
                table);

            var listings = await db.Listings
                .SqlQuery(sql, term)
                .ToListAsync();

            // Load related photos in a separate query
            var listingIds = listings.Select(q => q.ListingId).ToList();
            db.ListingPhotos.Where(p => listingIds.Contains(p.ListingId)).Load();

            return View(listings);
        }

        // GET: Listings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = await db.Listings.FindAsync(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ListingId,Title,Description,Price,Status,Street,City,State,ZipOrPostalCode,Country,SellingAgentId")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(listing);
        }

        // GET: Listings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = await db.Listings.FindAsync(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ListingId,Title,Description,Price,Status,Street,City,State,ZipOrPostalCode,Country,SellingAgentId")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        // GET: Listings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = await db.Listings.FindAsync(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Listing listing = await db.Listings.FindAsync(id);
            db.Listings.Remove(listing);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
