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
    public class BookingLightController : ApiController
    {
        // GET: api/BookingLight
        public IEnumerable<BookingLight> Get()
        {
            List<BookingLight> data = null;
            try {
                data = BookingLightDAL.GetAll();
            }
            catch (Exception ex) {
                throw ex;
            }

            return data;
        }

        // GET: api/BookingLight/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookingLight
        public void Post([FromBody]BookingLight value)
        {
            try
            {
                BookingLightDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/BookingLight/5
        public void Put(string id, [FromBody]BookingLight value)
        {
            try
            {
                BookingLightDAL.Update(id,value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/BookingLight/5
        public void Delete(int id)
        {
            try
            {
                BookingLightDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
