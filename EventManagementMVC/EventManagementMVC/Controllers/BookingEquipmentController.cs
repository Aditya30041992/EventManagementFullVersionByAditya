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
    public class BookingEquipmentController : ApiController
    {
        // GET: api/BookingEquipment
        public IEnumerable<BookingEquipment> Get()
        {
            List<BookingEquipment> data = null;
            try {
                data = BookingEquipmentDAL.GetAll();
            }
            catch (Exception ex) {
                throw ex;
            }
            return data;
        }

        // GET: api/BookingEquipment/5
        public IEnumerable<BookingEquipment> Get(string id)
        {
            List<BookingEquipment> data = null;
            try
            {
                data = BookingEquipmentDAL.GetByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        // POST: api/BookingEquipment
        public void Post([FromBody]BookingEquipment value)
        {
            try
            {
                BookingEquipmentDAL.Insert(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/BookingEquipment/5
        public void Put(string id, [FromBody]BookingEquipment value)
        {
            try
            {
                BookingEquipmentDAL.Update(id, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/BookingEquipment/5
        public void Delete(int id)
        {
            try
            {
                BookingEquipmentDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
