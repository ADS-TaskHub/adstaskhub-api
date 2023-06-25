using adstaskhub_api.Models;

namespace adstaskhub_api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(long id);
        Task<List<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user, long id);
        Task<bool> DeleteUser(long id);
    }
}
