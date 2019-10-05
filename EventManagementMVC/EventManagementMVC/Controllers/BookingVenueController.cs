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
    public class BookingVenueController : ApiController
    {
        // GET: api/BookingVenue
        public IEnumerable<BookingVenue> Get()
        {
            List<BookingVenue> data = null;
            try
            {
                data = BookingVenueDAL.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return data ;
        }

        // GET: api/BookingVenue/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookingVenue
        public void Post([FromBody]BookingVenue value)
        {
            try
            {
               BookingVenueDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/BookingVenue/5
        public void Put(string id, [FromBody]BookingVenue value)
        {
            try
            {
               BookingVenueDAL.Update(id, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/BookingVenue/5
        public void Delete(int id)
        {
            try
            {
                BookingVenueDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
