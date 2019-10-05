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
    public class EquipmentDetailsController : ApiController
    {
        // GET: api/EquipmentDetails
        public IEnumerable<EquipmentDetails> Get()
        {
            List<EquipmentDetails> data = null;
            try
            {
                data = EquipmentDetailsDAL.GetAll();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return data;
        }

        // GET: api/EquipmentDetails/5
        public List<EquipmentDetails> Get(int id)
        {
            List<EquipmentDetails> data = null;
            data = EquipmentDetailsDAL.Get(id);
            return data;
        }

        // POST: api/EquipmentDetails
        public void Post([FromBody]EquipmentDetails value)
        {
            try
            {
                EquipmentDetailsDAL.Insert(value); 
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        // PUT: api/EquipmentDetails/5
        public void Put(string id, [FromBody]EquipmentDetails value)
        {
            try
            {
                EquipmentDetailsDAL.Update(id,value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/EquipmentDetails/5
        public void Delete(string id)
        {
            try
            {
                EquipmentDetailsDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
