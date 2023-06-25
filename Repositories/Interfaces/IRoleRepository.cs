using adstaskhub_api.Models;

namespace adstaskhub_api.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(long id);
        Task<List<Role>> GetAllRoles();
        Task<Role> CreateRole(Role role);
        Task<Role> UpdateRole(Role role, long id);
        Task<bool> DeleteRole(Role role, long id);
    }
}
