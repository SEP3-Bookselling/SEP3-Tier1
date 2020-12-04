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


        public async Task<IList<User>> GetAllUsersAsync(string username)
        {
            string message = await client.GetStringAsync(uri + "/users"); 
            List<User> result = JsonSerializer.Deserialize<List<User>>(message);
            return result;        
        }

        public async Task<User> getSpecificUserAsync(string username)
        {
            IList<User> users = await GetAllUsersAsync(username);
            User user = users.FirstOrDefault(user => user.username.Equals(username));
            string password = user.password;
            Console.WriteLine($"\t\t USername: {user.username} : Password: {user.password}" );
            
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
    }
}