using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleDTO>> GetAllRolesDTOAsync();
        Task<Role> GetRoleByIdAsync(long id);
        Task<RoleDTO> GetRoleDTOByIdAsync(long id);
        Task<RoleDTO> CreateRoleAsync(Role role);
        Task<RoleDTO> UpdateRoleAsync(Role role, long id);
        Task<bool> DeleteRoleAsync(long id);
        Task<bool> SoftDeleteRoleAsync(long id);
    }
}
