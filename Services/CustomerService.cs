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

        public async Task<bool> CreateAsync(Customer customer)
        {
            bool isAdded = false;

            using (var db = new CustomerEntities())
            {
                var record = db.Customers.Create();
                record.FirstName = customer.FirstName;
                record.LastName = customer.LastName;
                record.Email = customer.Email;
                record.PhoneNumber = customer.PhoneNumber;

                db.Customers.Add(record);
                await db.SaveChangesAsync();

                isAdded = true;
            }

            return isAdded;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool isDeleted = false;

            using (var db = new CustomerEntities())
            {
                var customer = db.Customers.SingleOrDefault(c => c.Id == id);

                if (customer != null)
                {
                    db.Entry(customer).State = EntityState.Deleted;
                    await db.SaveChangesAsync();
                    isDeleted = true;
                }
            }

            return isDeleted;
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
                var result = db.Customers.SingleOrDefault(c => c.Id == customer.Id);

                if (result != null)
                {
                    result.FirstName = customer.FirstName;
                    result.LastName = customer.LastName;
                    result.PhoneNumber = customer.PhoneNumber;
                    result.Email = customer.Email;
                    await db.SaveChangesAsync();
                    isUpdated = true;
                }
            }

            return isUpdated;
        }
    }
}