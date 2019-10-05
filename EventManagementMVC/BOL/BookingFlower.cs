using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class BookingFlower
    {

        private string flwid;
        private int customerid;

        public BookingFlower() { }
        public BookingFlower(string flwid, int customerid)
        {
            this.flwid = flwid;
            this.customerid = customerid;
        }

     
        public string FlowerId
        {
            get { return flwid; }
            set { flwid = value; }
        }

        public int CustomerId
        {
            get { return customerid; }
            set { customerid = value; }
        }
    }
}