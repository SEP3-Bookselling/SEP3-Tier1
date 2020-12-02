using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SEP3_Tier1.Data.Users;
using SEP3_Tier1.Models.Users;
using SEP3_Tier1.Network;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3_Tier1.Data.Users
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

        public async Task<User> getSpecificUserAsync(string username, string password)
        {
            Task<string> stringString = client.GetStringAsync(uri + "/users");
            string message = await stringString;
            User result = JsonSerializer.Deserialize<User>(message);
            Console.WriteLine(" UserService \n" + "Username: " + result.username + "\n" + "Password: " + result.password + "\n" + "Role: " + result.role);

            return result;
        }

    
        public async Task CreateCustomerAsync(Customer customer)
        {
            string customerJson = JsonSerializer.Serialize(customer);
            
            HttpContent content = new StringContent(customerJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Users", content);
        Console.WriteLine();    
        Console.Write(" 2start " + customerJson + " 2end ");
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/users");
            string message = await stringAsync;
            IList<Customer> result = JsonSerializer.Deserialize<IList<Customer>>(message);
            return result;
        }

        public Task<Customer> GetCustomerAsync()
        {
            throw new System.NotImplementedException();
        }
        
        /* public async Task<User> ValidateUserAsync(string userName, string password) {
            //User first = _users.FirstOrDefault(user => user.username.Equals(userName));

            User user = await getSpecificUser(userName, password);
            if (user == null) {
                throw new Exception("User not found");
            }

            if (!user.password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return user;
        }
        */
       
        /**/ public async Task<User> ValidateUserAsync(string username, string password) {
            //User first = _users.FirstOrDefault(user => user.username.Equals(userName));
            //Console.WriteLine(" UserService \n" + "Username: " + username + "\n" + "Password: " + password);

            HttpResponseMessage response = await client.GetAsync(uri + "/users");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                Console.WriteLine(" UserService \n" + "Username: " + resultUser.username + "\n" + "Password: " + resultUser.password + "\n" + "Role: " + resultUser.role);
                return resultUser;
            } 
            throw new Exception("User not found");
        }
    }
}