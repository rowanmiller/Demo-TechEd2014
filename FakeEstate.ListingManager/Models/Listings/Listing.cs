using FakeEstate.ListingManager.Models.EFHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeEstate.ListingManager.Models.Listings
{
    [SoftDelete("IsDeleted")]
    public class Listing
    {
        public Listing()
        {
            this.Photos = new List<ListingPhoto>();
        }

        public bool IsDeleted { get; set; }

        public int ListingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Price { get; set; }
        public ListingStatus Status { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipOrPostalCode { get; set; }
        public string Country { get; set; }

        public int SellingAgentId { get; set; }
        public Agent SellingAgent { get; set; }

        public List<ListingPhoto> Photos { get; set; }
    }
}