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
    public class FlowerDetailsController : ApiController
    {
        // GET: api/FlowerDetails
        public IEnumerable<FlowerDetails> Get()
        {
            List<FlowerDetails> data = null;
            try
            {
                data = FlowerDetailsDAL.GetAll();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return data;
        }

        // GET: api/FlowerDetails/5
        public List<FlowerDetails> Get(int id)
        {
            List<FlowerDetails> data = null;
            data = FlowerDetailsDAL.Get(id);
            return data;
        }

        // POST: api/FlowerDetails
        public void Post([FromBody]FlowerDetails value)
        {
            try
            {
                FlowerDetailsDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // PUT: api/FlowerDetails/5
        public void Put(string id, [FromBody]FlowerDetails value)
        {
            try {
                FlowerDetailsDAL.Update(id, value);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        // DELETE: api/FlowerDetails/5
        public void Delete(string id)
        {
            try
            {
                FlowerDetailsDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
