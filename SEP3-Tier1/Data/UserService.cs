using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;
using SEP3_Tier1.Network;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3_Tier1.Data
{
    public class UserService : IUserService
    {
        private string uri = "https://localhost:5010";
        private HttpClient client;
        private IList<User> _users;

        public UserService()
        {
            client = new HttpClient();
        }
        
        public async Task AddCustomerAsyncTask(Customer customer)
        {
            string customerJson = JsonSerializer.Serialize(new Request
                {
                    Customer = customer,
                    RequestEnum = EnumRequest.CreateUser
                }
            );
            
            HttpContent content = new StringContent(customerJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/users", content);
        }

        public Task<Customer> GetCustomerAsync()
        {
            throw new System.NotImplementedException();
        }
        
        public User ValidateUser(string userName, string password) {
            User first = _users.FirstOrDefault(user => user.username.Equals(userName));
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}