using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Mappers.Interfaces
{
    public interface IUserMapper
    {
        UserDTOBase MapToDTO(User user);
        User MapToEntity(UserDTOBase userDto);
    }
}
