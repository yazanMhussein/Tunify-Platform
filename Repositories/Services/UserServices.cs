using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class UserServices : IUser
    {
        private readonly TunifyDbContext _context;

        public UserServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user) 
        { 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> GetAllUser() 
        { 
            var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }
        public async Task<User> GetUserById(int userId) 
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }
        public async Task<User> UpdateUser(int id, User user) 
        {
            _context.Users.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUser(int id) 
        { 
            var getUser = await GetUserById(id);
            _context.Entry(getUser).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


    }
}
