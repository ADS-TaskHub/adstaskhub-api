namespace adstaskhub_api.Application.Services
{
    public class AuthenticationService
    {
        public async Task<bool> VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return await Task.Run(() => BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword));
        }
    }
}
