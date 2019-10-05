using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class VenueDetails
    {
        public DateTime BookDate { get; set; }

        public string VenueId { get; set; }
        public string VenueName { get; set; }
        //public string VenueFileName { get; set; }
        //public string VenueFilePath { get; set; }
        public double VenueCost { get; set; }
      //  public string VenueCreatedBy { get; set; }
        public int VenueCapacity { get; set; }
        public double VenueContact { get; set; }
        public string VenueAddress { get; set; }

    }
}