using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Application.Services;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace adstaskhub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly TokenService _tokenService;
        private readonly AuthenticationService _authenticationService;

        public AuthController(IUserRepository userRepository, IUserMapper userMapper, TokenService tokenService, AuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
            _tokenService = tokenService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserLoginDTO user)
        {
            var userAuth = await _userRepository.GetUserByEmail(user.Email);

            if (!userAuth.IsApproved)
            {
                return Unauthorized(new { message = "Usuário ainda não aprovado, aguarde aprovação ou entre em contato conosco!" });
            }

            if (userAuth == null || userAuth.IsDeleted)
            {
                return Unauthorized(new { message = "Email ou senha inválidos!" });
            }

            bool authenticated = await _authenticationService.VerifyPassword(user.Password, userAuth.Password);
            if (!authenticated)
            {
                return Unauthorized(new { message = "Email ou senha inválidos!" });
            }
            var token = _tokenService.GenerateToken(userAuth);
            UserDTOBase userDto = _userMapper.MapToDTO(userAuth);

            return new
            {
                user = userDto,
                token
            };
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTOBase>> RegisterUser([FromBody] UserCreateDTO user)
        {
            await _userRepository.CreateUser(user, "web");
            
            return Ok(await _userRepository.GetUserByEmail(user.Email));
        }
    }
}
