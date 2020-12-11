using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data.Users
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetCustomerAsync(string username);
        Task<double> GetRatingAsync(string username);
        Task CreateCustomerAsync(Customer customer);
        Task RateCustomerAsync(Rating rating);

        Task UpdateCustomerAsync(Customer customer, string postcode, string address, string firstName, string lastName,
            string email, int phoneNumber, double rating, string password);
        
        Task DeleteCustomerAsync(string username);
    }
}