using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(long id);
        Task<UserDTO> GetUserDTOById(long id);
        Task<User> GetUserByEmail(string email);
        Task<List<UserDTO>> GetAllUsersDTO();
        Task<UserDTO> CreateUser(User user);
        Task<UserDTO> UpdateUser(User user, long id);
        Task<bool> DeleteUser(long id);
    }
}
