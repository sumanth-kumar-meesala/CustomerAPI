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

        public async Task<bool> UpdateAsync(Customer customer)
        {
            bool isUpdated = false;
            using (var db = new CustomerEntities())
            {
                var result = db.Customers.SingleOrDefault(c=>c.Id == customer.Id);

                if (result != null)
                {
                    result.FirstName = customer.FirstName;
                    result.LastName = customer.LastName;
                    result.PhoneNumber = customer.PhoneNumber;
                    result.Email = customer.Email;
                    await db.SaveChangesAsync();
                }
            }

            return isUpdated;
        }
    }
}