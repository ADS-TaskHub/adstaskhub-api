using adstaskhub_api.Application.DTOs;

namespace adstaskhub_api.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTOBase> CreateUser(UserCreateDTO userCreate, string createdBy);
        Task<UserDTOBase> ApproveUser(long userId, string updateBy);
        Task<UserDTOBase> ChangeUserClass(long userId, int newClassNumber, int newPeriodNumber, string updatedBy);
        Task<UserDTOBase> ChangeUserRole(long userId, long roleId, string updateBy);
        Task<bool> SoftDeleteUser(long id, string updateBy);
    }
}
