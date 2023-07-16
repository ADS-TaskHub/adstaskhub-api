using adstaskhub_api.Application.DTOs;

namespace adstaskhub_api.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDTO> AuthenticateUser(UserLoginDTO userLogin);
    }
}
