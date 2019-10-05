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
    public class BookingDetailsController : ApiController
    {
        // GET: api/BookingDetails
        public IEnumerable<BookingDetails> Get()
        {
            List<BookingDetails> data = null;
            try
            {
                data = BookingDetailsDAL.GetAll();
            }
            catch(Exception ex) {
                string message = ex.Message;
            }
                return data;
        }

        // GET: api/BookingDetails/5
        public List<BookingDetails> Get(int id)
        {
            List<BookingDetails> data = null;
            
            return data;
        }

        // POST: api/BookingDetails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BookingDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BookingDetails/5
        public void Delete(int id)
        {
        }
    }
}
