using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {

        public Task<int> CreateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> ListAllAsync()
        {
            List<Customer> customers = new List<Customer>();

            using (var db = new CustomerEntities())
            {
                customers = await db.Customers.ToListAsync();
            }

            return customers;
        }

        public Task<bool> UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}