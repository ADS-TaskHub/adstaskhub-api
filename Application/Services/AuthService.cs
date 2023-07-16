using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Application.Services.Interfaces;
using adstaskhub_api.Helpers.ErrorMessages;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;

namespace adstaskhub_api.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IUserMapper _userMapper;

        public AuthService(IUserRepository userRepository, IPasswordService passwordService, ITokenService tokenService, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _userMapper = userMapper;
        }

        public async Task<AuthResultDTO> AuthenticateUser(UserLoginDTO userLogin)
        {
            var user = await _userRepository.GetUserByEmailAsync(userLogin.Email);

            if (user == null || user.IsDeleted)
            {
                return new AuthResultDTO
                {
                    Success = false,
                    Message = UserErrorMessages.InvalidEmailOrPassword
                };
            }

            if (!user.IsApproved)
            {
                return new AuthResultDTO
                {
                    Success = false,
                    Message = UserErrorMessages.UserNotApproved
                };
            }

            bool authenticated = await _passwordService.VerifyPassword(userLogin.Password, user.Password);
            if (!authenticated)
            {
                return new AuthResultDTO
                {
                    Success = false,
                    Message = UserErrorMessages.InvalidEmailOrPassword
                };
            }

            var token = _tokenService.GenerateToken(user);
            var userDto = _userMapper.MapToDTO(user);

            return new AuthResultDTO
            {
                Success = true,
                User = userDto,
                Token = token
            };
        }
    }
}