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
    public class AdminRegisterController : ApiController
    {
        MySqlDBTest mdb = new MySqlDBTest();
        // GET: api/AdminRegister
        public IEnumerable<AdminRegistration> Get()
        {
            List<AdminRegistration> data = null;
            try
            {
                data = mdb.GetAll();
            }
            catch (Exception exp)
            {
                string message = exp.Message;

            }

            return data;

        }

        // GET: api/ApiDemo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApiDemo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApiDemo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiDemo/5
        public void Delete(int id)
        {
        }
    }
}
