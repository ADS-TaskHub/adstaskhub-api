using adstaskhub_api.Data;
using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DBContext _dbContext;

        public RoleRepository(DBContext DBContext)
        {
            _dbContext = DBContext;   
        }

        public async Task<Role> GetRoleById(long Id)
        {
            return await _dbContext.roles.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _dbContext.roles.ToListAsync();
        }

        public async Task<Role> CreateRole(Role role)
        {
            await _dbContext.roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();

            return role;
        }

        public async Task<Role> UpdateRole(Role role, long id)
        {
            Role roleById = await GetRoleById(id);

            if(roleById == null)
            {
                throw new Exception($"Role for ID: {id} not found");
            }

            roleById.Id = role.Id;
            roleById.Name = role.Name;

            _dbContext.roles.Update(roleById);
            await _dbContext.SaveChangesAsync();
            return roleById;
        }

        public async Task<bool> DeleteRole(Role role, long id)
        {
            Role roleById = await GetRoleById(id);

            if (roleById == null)
            {
                throw new Exception($"Role for ID: {id} not found");
            }

            _dbContext.roles.Remove(roleById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
