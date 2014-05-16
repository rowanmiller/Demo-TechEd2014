namespace FakeEstate.ListingManager.Models.Listings
{
    public class ListingPhoto
    {
        public int ListingPhotoId { get; set; }
        public string PhotoUrl { get; set; }
        public string Caption { get; set; }

        public int ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}