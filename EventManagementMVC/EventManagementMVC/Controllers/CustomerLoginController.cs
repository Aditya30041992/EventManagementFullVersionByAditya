using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BOL;
using DAL;
namespace EventManagementMVC.Controllers
{
    public class CustomerLoginController : ApiController
    {
        // GET: api/CustomerLogin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CustomerLogin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CustomerLogin
        public CustomerRegistration Post(int id, string pass)
        {
            CustomerRegistration data = null;

            try
            {
                data = CustomerRegistrationDAL.Check(id, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;

        }

        // PUT: api/CustomerLogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerLogin/5
        public void Delete(int id)
        {
        }
    }
}
