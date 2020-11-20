using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data
{
    public interface ICustomerService
    
    {
        Task AddCustomerAsyncTask(Customer customer);
        Task<Customer> GetCustomerAsync();
    }
}