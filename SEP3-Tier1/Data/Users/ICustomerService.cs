using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data.Users
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetCustomerAsync(string username);
        Task <IList<Customer>> GetAllCustomersAsync();
        Task CreateCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer, string postcode, string address, string firstName, string lastName,
            string email, int phoneNumber, double rating, string password);
    }
}