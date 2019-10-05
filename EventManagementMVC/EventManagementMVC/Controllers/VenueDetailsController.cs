using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BOL;

namespace EventManagementMVC.Controllers
{
    public class VenueDetailsController : ApiController
    {
        // GET: api/VenueDetails
        public IEnumerable<VenueDetails> Get()
        {
            List<VenueDetails> data = null;
            try
            {
                data = VenueDetailsDAL.GetAll();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return data;

        }

        // GET: api/VenueDetails/5
        public List<VenueDetails> Get(int id)
        {
            List<VenueDetails> data = null;
            data = VenueDetailsDAL.Get(id);
            return data;
        }

        // POST: api/VenueDetails
        public void Post([FromBody]VenueDetails value)
        {
            try
            {
                VenueDetailsDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // PUT: api/VenueDetails/5
        public void Put(string id, [FromBody]VenueDetails value)
        {
            try {
                VenueDetailsDAL.Update(id, value);
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        // DELETE: api/VenueDetails/5
        public void Delete(string id)
        {
            try
            {
                VenueDetailsDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
