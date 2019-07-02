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

        public async Task<IHttpActionResult> PostCreateCustomer([FromBody]Models.Customer customer)
        {
            try
            {
                var _success = await customerService.CreateAsync(customer);

                string _message = "Unable to create customer details";

                if (_success)
                {
                    _message= "Customer created successfully";
                }

                var result = new { success = _success, message = _message };
                return Json(result);
            }
            catch (Exception e)
            {
                var result = new { success = false, message = e.Message };
                return Json(result);
            }
        }

        public async Task<IHttpActionResult> PutUpdateCustomer(Models.Customer customer)
        {
            try
            {
                var _success = await customerService.UpdateAsync(customer);

                string _message = "Unable to update customer details";

                if (_success)
                {
                    _message = "Updated customer detailssuccessfully";
                }

                var result = new { success = _success, message = _message };
                return Json(result);
            }
            catch (Exception e)
            {
                var result = new { success = false, message = e.Message };
                return Json(result);
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
