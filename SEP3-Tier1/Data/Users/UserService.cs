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

        public async Task<User> getSpecificUser(User user)
        {
            String username = "Crisiluluman";

            user.username = "Crisiluluman";
            
            Console.WriteLine("I AM IN THE HOLE MOTHER");
            string userJsonString = JsonSerializer.Serialize(user);
            
            HttpContent content = new StringContent(userJsonString,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Users", content);          
            
            Task<string> stringAsync = client.GetStringAsync(uri + "/Users");
            string message = await stringAsync;
            User result = JsonSerializer.Deserialize<User>(message);


            Console.WriteLine(result.username.Equals(username));
            return result;
            
        }

    
        public async Task AddCustomerAsyncTask(Customer customer)
        {
            string customerJson = JsonSerializer.Serialize(customer);
            
            HttpContent content = new StringContent(customerJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage responseMessage = await client.PostAsync(uri + "/users", content);
            Console.Write( "1" + customer.ToString());
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