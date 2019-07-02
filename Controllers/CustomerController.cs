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

        //Method Fetch All the customers 
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

        //Method Create or Update customer
        public async Task<IHttpActionResult> PostCreateCustomer([FromBody]Models.Customer customer)
        {
            try
            {
                var record = await customerService.CreateOrUpdateAsync(customer);

                string _message = "Unable to create or customer details";
                var _success = false;

                if (record != null)
                {
                    _message = "Customer details updated successfully";
                    _success = true;
                }

                var result = new { success = _success, message = _message, customer = record };
                return Json(result);
            }
            catch (Exception e)
            {
                var result = new { success = false, message = e.Message };
                return Json(result);
            }
        }

        //Method to delete customer
        public async Task<IHttpActionResult> GetDeleteCustomer(int id)
        {
            try
            {
                var _success = await customerService.DeleteAsync(id);

                string _message = "Unable to delete customer";

                if (_success)
                {
                    _message = "Deleted customer successfully";
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
    }
}
