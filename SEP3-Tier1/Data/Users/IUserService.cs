using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data.Users
{
    public interface IUserService

    {
        //User
        //Task<User> ValidateUserAsync(string userName, string password);
        Task<IList<User>> GetAllUsersAsync(string username);
        Task<User> getSpecificUserAsync(string username);

    }
}