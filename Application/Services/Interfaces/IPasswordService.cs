namespace adstaskhub_api.Application.Services.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        Task<bool> VerifyPassword(string enteredPassword, string hashedPassword);
    }
}
