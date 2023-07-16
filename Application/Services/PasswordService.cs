using adstaskhub_api.Application.Services.Interfaces;

namespace adstaskhub_api.Application.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public async Task<bool> VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return await Task.Run(() => BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword));
        }
    }
}
