using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class BookingVenue
    {
        public string VenueId { set; get; }
        public int EventTypeId { set; get; }
        public int GuestCount { set; get; }
        public DateTime BookDate { set; get; }
        public int CustomerId { set; get; }

    }
}