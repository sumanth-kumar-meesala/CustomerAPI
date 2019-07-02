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
        Task<bool> UpdateAsync(Models.Customer customer);
        Task<bool> DeleteAsync(int id);
        Task<bool> CreateAsync(Models.Customer customer);
    }
}
