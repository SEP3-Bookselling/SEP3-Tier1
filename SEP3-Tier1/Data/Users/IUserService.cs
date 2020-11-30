using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data
{
    public interface IUserService

    {
        //User
        User ValidateUser(string userName, string password);
        Task<User> getSpecificUser(User user);

        //Customer
        Task AddCustomerAsyncTask(Customer customer);
        Task<Customer> GetCustomerAsync();
    }
}