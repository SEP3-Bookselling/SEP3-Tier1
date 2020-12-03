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

        /*
        public async Task<User> getSpecificUserAsync(string username, string password)
        {
            Task<string> stringString = client.GetStringAsync($"https://localhost:5010/users/GetSpecificUserAsync/{username}");
            string message = await stringString;
            User result = JsonSerializer.Deserialize<User>(message);
            Console.WriteLine(" UserService \n" + "Username: " + result.username + "\n" + "Password: " + result.password + "\n" + "Role: " + result.role);

            return result;
        }
        */
        
        public async Task<User> getSpecificUserAsync(string username)
        {
            string oen = $"https://localhost:5010/users/GetSpecificUserAsync/{username}";
            string two = $"https://localhost:5010/users?username={username}";
            HttpResponseMessage response = await client.GetAsync(oen);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            } 
            throw new Exception("User not found");
        }
        

        
        public async Task<IList<User>> GetAllUsersAsync()
        {
            Task<string> stringString = client.GetStringAsync(uri + "/users");
            Console.WriteLine(stringString);
            string message = await stringString;
            IList<User> result = JsonSerializer.Deserialize<IList<User>>(message);

            foreach (User user in result)
            {
                Console.WriteLine(user.username);
            }
            
            return result;
        }
        
    }
}