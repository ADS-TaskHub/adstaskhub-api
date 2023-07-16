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

        public async Task<Role> GetRoleByIdAsync(long id)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RoleDTO> GetRoleDTOByIdAsync(long id)
        {
            Role role =  await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return _roleMapper.MapToDTO(role);
        }

        public async Task<List<RoleDTO>> GetAllRolesDTOAsync()
        {
            List<Role> roles = await _dbContext.Roles.ToListAsync();

            return roles.Select(role => _roleMapper.MapToDTO(role)).ToList();
        }

        public async Task<RoleDTO> CreateRoleAsync(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();

            return _roleMapper.MapToDTO(role);
        }

        public async Task<RoleDTO> UpdateRoleAsync(Role role, long id)
        {
            Role roleById = await GetRoleByIdAsync(id) ?? throw new Exception($"Role for ID: {id} not found");
            roleById.Id = role.Id;
            roleById.Name = role.Name;
            roleById.Description = role.Description;
            roleById.UpdatedAt = DateTime.UtcNow;

            _dbContext.Roles.Update(roleById);
            await _dbContext.SaveChangesAsync();
            return _roleMapper.MapToDTO(roleById);
        }

        public async Task<bool> DeleteRoleAsync(long id)
        {
            Role roleById = await GetRoleByIdAsync(id) ?? throw new Exception($"Role for ID: {id} not found");
            _dbContext.Roles.Remove(roleById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteRoleAsync(long id)
        {
            Role roleById = await GetRoleByIdAsync(id) ?? throw new Exception($"Role for ID: {id} not found");

            roleById.IsDeleted = true;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
