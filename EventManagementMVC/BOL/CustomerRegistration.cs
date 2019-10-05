using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class CustomerRegistration
    {
        private int customerid;
        private string customername;
        private string customeraddr;
        private double customercontact;
        private string customercity;
        private string customeremail;
        private string customerpassword;
        private string customerconfirmpassword;
        private string customergen;

        public CustomerRegistration() { }
        public CustomerRegistration(int customerid, string customername, string customeraddr, double customercontact, string customercity, string customeremail, string customerpassword, string customerconfirmpassword, string customergen)
        {
            this.customerid = customerid;
            this.customername = customername;
            this.customeraddr = customeraddr;
            this.customercontact = customercontact;
            this.customercity = customercity;
            this.customeremail = customeremail;
            this.customerpassword = customerpassword;
            this.customerconfirmpassword = customerconfirmpassword;
            this.customergen = customergen;
        }


        public int CustomerId
        {
            get { return customerid; }
            set { customerid = value; }
        }

        public string CustomerName
        {
            get { return customername; }
            set { customername = value; }
        }

        public string CustomerAddress
        {
            get { return customeraddr; }
            set { customeraddr = value; }
        }

        public double CustomerContact
        {
            get { return customercontact; }
            set { customercontact = value; }
        }

        public string CustomerCity
        {
            get { return customercity; }
            set { customercity = value; }
        }

        public string CustomerEmail
        {
            get { return customeremail; }
            set { customeremail = value; }
        }

        public string CustomerPassword
        {
            get { return customerpassword; }
            set { customerpassword = value; }
        }

        public string CustomerConfirmPassword
        {
            get { return customerconfirmpassword; }
            set { customerconfirmpassword = value; }
        }

        public string CustomerGender
        {
            get { return customergen; }
            set { customergen = value; }
        }

    }
}