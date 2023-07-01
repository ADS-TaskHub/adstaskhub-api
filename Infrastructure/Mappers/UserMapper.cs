using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;

namespace adstaskhub_api.Infrastructure.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IClassMapper _classMapper;
        public UserMapper(IClassMapper classMapper)
        {
            _classMapper = classMapper;
        }

        public UserDTO MapToDTO(User user)
        {
            UserDTO userDto = new()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Class = _classMapper.MapToDTO(user.Class)
            };
            return userDto;
        }

        public User MapToEntity(UserDTO userDto)
        {
            User user = new()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Phone = userDto.Phone,
                Class = _classMapper.MapToEntity(userDto.Class)
            };
            return user;
        }
    }
}
