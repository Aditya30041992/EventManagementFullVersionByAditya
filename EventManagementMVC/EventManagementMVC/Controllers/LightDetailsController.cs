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
    public class LightDetailsController : ApiController
    {
        // GET: api/LightDetails
        public IEnumerable<LightDetails> Get()
        {
            List<LightDetails> data = null;
            try
            {
                data = LightDetailsDAL.GetAll();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return data;
        }

        // GET: api/LightDetails/5
        public List<LightDetails> Get(int id)
        {
            List<LightDetails> data = null;
            data = LightDetailsDAL.Get(id);
            return data;
        }

        // POST: api/LightDetails
        public void Post([FromBody]LightDetails value)
        {
            try
            {
                LightDetailsDAL.Insert(value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        // PUT: api/LightDetails/5
        public void Put(string id, [FromBody]LightDetails value)
        {
            try
            {
                LightDetailsDAL.Update(id, value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        // DELETE: api/LightDetails/5
        public void Delete(string id)
        {
            try
            {
                LightDetailsDAL.Delete(id);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
    }
}
