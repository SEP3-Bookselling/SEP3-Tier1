using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data.Users
{
    public interface IUserService

    {
        //User
        User ValidateUser(string userName, string password);
        Task<User> getSpecificUser(User user);

        //Customer
        Task <IList<Customer>> GetAllCustomersAsyncTask();
        Task CreateCustomerAsyncTask(Customer customer);
        Task<Customer> GetCustomerAsync();
    }
}