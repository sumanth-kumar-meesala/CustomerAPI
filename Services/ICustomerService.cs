using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        Task<List<Models.Customer>> ListAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<Models.Customer> CreateOrUpdateAsync(Models.Customer customer);
    }
}
