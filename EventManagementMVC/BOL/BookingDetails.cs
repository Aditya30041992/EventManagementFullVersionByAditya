using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class BookingDetails
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double CustomerContact { get; set; }
        public string VenueName { get; set; }
        public double VenueCost { get; set; }
        public DateTime BookDate { get; set; }


    }
}