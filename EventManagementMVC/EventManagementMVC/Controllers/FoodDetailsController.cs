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
    public class FoodDetailsController : ApiController
    {
        // GET: api/FoodDetails
        public IEnumerable<FoodDetails> Get()
        {
            List<FoodDetails> data = null;
            try
            {
                data = FoodDetailsDAL.GetAll();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return data;
        }
    

        // GET: api/FoodDetails/5
        public List<FoodDetails> Get(int id)
        {
            List<FoodDetails> data = null;
            data = FoodDetailsDAL.Get(id);
            return data;
        }

        // POST: api/FoodDetails
        public void Post([FromBody]FoodDetails value)
        {
            try
            {
                FoodDetailsDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // PUT: api/FoodDetails/5
        public void Put(string id, [FromBody]FoodDetails value)
        {
            try {
                FoodDetailsDAL.Update(id, value);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        // DELETE: api/FoodDetails/5
        public void Delete(string id)
        {
            try
            {
                FoodDetailsDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
