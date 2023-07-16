using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDTOBase>> GetAllUsersDTO();
        Task<User> GetUserById(long id);
        Task<UserDTOBase> GetUserDTOById(long id);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<UserDTOBase>> GetUsersDTOByClass(int classNumber);
        Task<List<User>> GetUsersByClass(int classNumber);
        Task<List<UserDTOBase>> GetUsersDTOByClassWithPagination(int classNumbe, int pageNumber, int pageSize);
        Task<List<UserDTOBase>> GetAllUsersDTOWithPagination(int pageNumber, int pageSize);
        Task<UserDTOBase> CreateUserAsync(User user);
        Task<UserDTOBase> UpdateUser(User user, long id, string updateBy);
        Task<UserDTOBase> ChangeUserClass(long userId, int newClassNumber, string updateBy);
        Task<UserDTOBase> ChangeUserRole(long userId, long roleId, string updateBy);
        Task<bool> DeleteUser(long id);
        Task<bool> SoftDeleteUser(long id, string updateBy);
    }
}
