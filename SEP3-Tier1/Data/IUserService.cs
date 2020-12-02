using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data
{
    public interface IUserService

    {
        public Task<User> ValidateUserAsync(string userName, string password);
        Task AddCustomerAsyncTask(Customer customer);
        Task<Customer> GetCustomerAsync();
        
        //User
        Task<User> getSpecificUser(string username, string password);
    }
}