using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTOBase> CreateUser(UserCreateDTO userCreate, string createdBy);
    }
}
