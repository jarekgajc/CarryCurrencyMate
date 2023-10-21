using Backend.Models.Users;
using Common.Models.Accounts;

namespace Backend.Services.UserServices
{
    public interface IUserService
    {
        Task<User?> GetUser(int id);
        Task<User?> GetUserByEmail(string email);
        Task<User> CreateUser(User user);
    }
}
