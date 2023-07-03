using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(long id);
        Task<UserDTOBase> GetUserDTOById(long id);
        Task<User> GetUserByEmail(string email);
        Task<List<UserDTOBase>> GetUsersDTOByClass(int classNumber);
        Task<List<User>> GetUsersByClass(int classNumber);
        Task<List<UserDTOBase>> GetAllUsersDTO();
        Task<List<UserDTOBase>> GetUsersDTOByClassWithPagination(int classNumbe, int pageNumber, int pageSize);
        Task<List<UserDTOBase>> GetAllUsersDTOWithPagination(int pageNumber, int pageSize);
        Task<UserDTOBase> CreateUser(UserCreateDTO user);
        Task<UserDTOBase> UpdateUser(User user, long id);
        Task<bool> DeleteUser(long id);
    }
}
