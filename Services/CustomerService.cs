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

        public async Task<Customer> CreateOrUpdateAsync(Customer customer)
        {
            Customer record = null;

            using (var db = new CustomerEntities())
            {
                if (customer.Id != 0)
                {
                    record = db.Customers.SingleOrDefault(c => c.Id == customer.Id);

                    if (record != null)
                    {
                        record.FirstName = customer.FirstName;
                        record.LastName = customer.LastName;
                        record.PhoneNumber = customer.PhoneNumber;
                        record.Email = customer.Email;
                        await db.SaveChangesAsync();
                    }
                }
                else
                {
                    record = db.Customers.Create();
                    record.FirstName = customer.FirstName;
                    record.LastName = customer.LastName;
                    record.Email = customer.Email;
                    record.PhoneNumber = customer.PhoneNumber;

                    db.Customers.Add(record);
                    await db.SaveChangesAsync();
                }


                return record;
            }
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
    }
}