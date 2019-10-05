using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class BookingEquipment
    {
        private string eqpid;
        private int customerid;

        public BookingEquipment() { }
        public BookingEquipment(string eqpid, int customerid)
        {
            this.eqpid = eqpid;
            this.customerid = customerid;
        }

        public string EquipmentId
        {
            get { return eqpid; }
            set { eqpid = value; }
        }

        public int CustomerId
        {
            get { return customerid; }
            set { customerid = value; }
        }

    }
}