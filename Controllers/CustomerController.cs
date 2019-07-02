using CustomerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerAPI.Controllers
{
    public class CustomerController : ApiController
    {

        private readonly CustomerService customerService;

        public CustomerController()
        {
            customerService = new CustomerService();
        }

        public async Task<IHttpActionResult> GetCustomers()
        {
            try
            {
                var customers = await customerService.ListAllAsync();
                var result = new { success = true, data = customers, message = "Successfully fetched customers" };
                return Json(result);
            }
            catch (Exception e)
            {
                var result = new { success = false, message = e.Message };
                return Json(result);
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
