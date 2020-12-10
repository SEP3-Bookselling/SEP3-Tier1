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


        public async Task CreateUserAsync(User user)
        {
            string userAsJson = JsonSerializer.Serialize(user);

            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Users", content);
        }


        public async Task<IList<User>> GetAllUsersAsync(string username)
        {
            string message = await client.GetStringAsync(uri + "/users");
            List<User> result = JsonSerializer.Deserialize<List<User>>(message);
            return result;
        }

        public async Task<User> getSpecificUserAsync(string username, string password)
        {
            Console.WriteLine($"Logged in as: {username} pass = {password}");
            string message = await client.GetStringAsync(uri + $"/users/Login?username={username}&password={password}");
            User user = JsonSerializer.Deserialize<User>(message);
            
            Console.WriteLine($"\t\t Username: {user.username} : Password: {user.password}");

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!user.password.Equals(password))
            {
                throw new Exception("Password incorrect, try again");
            }

            return user;
        }

        public async Task UpdateUserAsync(User user, string password)
        {
            user.password = password;

            string userAsJson = JsonSerializer.Serialize(user);
            
            HttpContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");

            await client.PatchAsync($"{uri}/users/{user.username}", content);
        }
        

        public async Task DeleteUserAsync(string username)
        {
            await client.DeleteAsync($"{uri}/users/{username}");
        }


    }
}