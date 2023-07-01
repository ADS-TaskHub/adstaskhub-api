using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(long id);
        Task<RoleDTO> GetRoleDTOById(long id);
        Task<List<RoleDTO>> GetAllRolesDTO();
        Task<RoleDTO> CreateRole(Role role);
        Task<RoleDTO> UpdateRole(Role role, long id);
        Task<bool> DeleteRole(long id);
    }
}
