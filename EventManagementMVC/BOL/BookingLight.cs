using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class BookingLight
    {
        private string lighttype;
        private string lightnameid;
        private int customerid;
       // private string lightid;

        public BookingLight() { }
        public BookingLight(string lighttype, string lightnameid, int customerid)
        {
            this.lighttype = lighttype;
            this.lightnameid = lightnameid;
            this.customerid = customerid;

        }

        //public string LightId
        //{
        //    get { return lightid; }
        //    set { lightid = value; }
        //}

        public string LightType
        {
            get { return lighttype; }
            set { lighttype = value; }
        }

        public string LightNameID
        {
            get { return lightnameid; }
            set { lightnameid = value; }
        }

        public int CustomerId
        {
            get { return customerid; }
            set { customerid = value; }
        }

      

    }
}