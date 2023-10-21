using Backend.Data;
using Backend.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
        
        public async Task<User> CreateUser(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
    }
}
