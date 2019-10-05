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
    public class BookingFoodController : ApiController
    {
        // GET: api/BookingFood
        public IEnumerable<BookFood> Get()
        {
            List<BookFood> data = null;
            try
            {
                data = BookFoodDAL.GetAll();
            }
            catch (Exception ex) {
                throw ex;
            }
            return data;
        }

        // GET: api/BookingFood/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookingFood
        public void Post([FromBody]BookFood value)
        {
            try
            {
                BookFoodDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // PUT: api/BookingFood/5
        public void Put(string id, [FromBody]BookFood value)
        {
            try
            {
                BookFoodDAL.Update(id, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/BookingFood/5
        public void Delete(int id)
        {
            try
            {
                BookFoodDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
