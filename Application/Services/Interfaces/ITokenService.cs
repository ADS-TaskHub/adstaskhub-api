using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
