using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDTOBase>> GetAllUsersDTOAsync();
        Task<User> GetUserByIdAsync(long id);
        Task<UserDTOBase> GetUserDTOByIdAsync(long id);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<UserDTOBase>> GetUsersDTOByClassAsync(int classNumber);
        Task<List<User>> GetUsersByClassAsync(int classNumber);
        Task<List<UserDTOBase>> GetUsersDTOByClassWithPaginationAsync(int classNumber, int pageNumber, int pageSize);
        Task<List<UserDTOBase>> GetAllUsersDTOWithPaginationAsync(int pageNumber, int pageSize);
        Task<List<User>> GetNotApprovedUsersAsync();
        Task<UserDTOBase> CreateUserAsync(User user);
        Task<UserDTOBase> UpdateUserAsync(User user, long id);
        Task<bool> DeleteUserAsync(long id);
    }
}
