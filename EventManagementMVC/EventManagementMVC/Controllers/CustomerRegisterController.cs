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
    public class CustomerRegisterController : ApiController
    {
        // GET: api/CustomerRegister
        public IEnumerable<CustomerRegistration> Get()
        {
            List<CustomerRegistration> data = null;
            try
            {
                data = CustomerRegistrationDAL.GetAll();
            }
            catch (Exception ex) {
                string message = ex.Message;
            }
            return data;
           
        }

        // GET: api/CustomerRegister/
        public CustomerRegistration Get(int id, string pass)
        {
            CustomerRegistration data = null;

            //bool status = false;
            try
            {
               data = CustomerRegistrationDAL.Check(id,pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        // POST: api/CustomerRegister
        public void Post([FromBody]CustomerRegistration value)
        {
            try
            {
                CustomerRegistrationDAL.Insert(value);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        // PUT: api/CustomerRegister/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerRegister/5
        public void Delete(int id)
        {
        }
    }
}
