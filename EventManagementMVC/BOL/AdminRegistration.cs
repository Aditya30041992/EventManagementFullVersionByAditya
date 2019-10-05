using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class AdminRegistration
    {
        private int Id;
        private string Email;
        private string Password;
        private string Name;
        private double Contact;

        public AdminRegistration() { }
        public AdminRegistration(int id, string email, string password, string name, double contact)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Name = name;
            this.Contact = contact;

        }
        public int AdminId
        {
            get { return Id; }
            set { Id = value; }
        }
        public string AdminEmail
        {
            get { return Email; }
            set { Email = value; }
        }

        public string AdminPassword
        {
            get { return Password; }
            set { Password = value; }
        }

        public string AdminName
        {
            get { return Name; }
            set { Name = value; }
        }
        public double AdminContact
        {
            get { return Contact; }
            set { Contact = value; }
        }


    }
}