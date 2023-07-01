using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;

namespace adstaskhub_api.Infrastructure.Mappers
{
    public class RoleMapper : IRoleMapper
    {
        public RoleDTO MapToDTO(Role role)
        {
            RoleDTO roleDto = new()
            {
                Name = role.Name
            };
            return roleDto;
        }

        public Role MapToEntity(RoleDTO roleDto)
        {
            Role role = new()
            {
                Name = roleDto.Name,
            };
            return role;
        }
    }
}
