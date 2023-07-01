using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DBContext _dbContext;
        private readonly IRoleMapper _roleMapper;
        public RoleRepository(DBContext DBContext, IRoleMapper roleMapper)
        {
            _dbContext = DBContext;
            _roleMapper = roleMapper;
        }

        public async Task<Role> GetRoleById(long id)
        {
            return await _dbContext.roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RoleDTO> GetRoleDTOById(long id)
        {
            Role role =  await _dbContext.roles.FirstOrDefaultAsync(x => x.Id == id);
            return _roleMapper.MapToDTO(role);
        }

        public async Task<List<RoleDTO>> GetAllRolesDTO()
        {
            List<Role> roles = await _dbContext.roles.ToListAsync();

            return roles.Select(role => _roleMapper.MapToDTO(role)).ToList();
        }

        public async Task<RoleDTO> CreateRole(Role role)
        {
            await _dbContext.roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();

            return _roleMapper.MapToDTO(role);
        }

        public async Task<RoleDTO> UpdateRole(Role role, long id)
        {
            Role roleById = await GetRoleById(id) ?? throw new Exception($"Role for ID: {id} not found");
            roleById.Id = role.Id;
            roleById.Name = role.Name;

            _dbContext.roles.Update(roleById);
            await _dbContext.SaveChangesAsync();
            return _roleMapper.MapToDTO(roleById);
        }

        public async Task<bool> DeleteRole(long id)
        {
            Role roleById = await GetRoleById(id) ?? throw new Exception($"Role for ID: {id} not found");
            _dbContext.roles.Remove(roleById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
