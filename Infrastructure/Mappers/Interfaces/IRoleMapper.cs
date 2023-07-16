using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Mappers.Interfaces
{
    public interface IRoleMapper
    {
        RoleDTO MapToDTO(Role role);
        Role MapToEntity(RoleDTO roleDto);
    }
}
