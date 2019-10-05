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
    public class BookingFlowerController : ApiController
    {
        // GET: api/BookingFlower
        public IEnumerable<BookingFlower> Get()
        {
            List<BookingFlower> data = null;
            try {
                data = BookingFlowerDAL.GetAll();
            }
            catch (Exception ex) {
                throw ex;
            }
            return data;
        }

        // GET: api/BookingFlower/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookingFlower
        public void Post([FromBody]BookingFlower value)
        {
            try
            {
                BookingFlowerDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/BookingFlower/5
        public void Put(string id, [FromBody]BookingFlower value)
        {
            try
            {
                BookingFlowerDAL.Update(id, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/BookingFlower/5
        public void Delete(int id)
        {
            try
            {
                BookingFlowerDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
