using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int userId); 
        Task<User> UpdateUser(int id, User user);
        Task DeleteUser(int id);
    }
}
