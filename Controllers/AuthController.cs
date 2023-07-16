using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Application.Services;
using adstaskhub_api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace adstaskhub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;


        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }


        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTOBase>> RegisterUser([FromBody] UserCreateDTO user)
        {
            try
            {
                UserDTOBase createdUser = await _userService.CreateUser(user, "web");
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro durante o registro do usuário: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserLoginDTO user)
        {
            var authResult = await _authService.AuthenticateUser(user);

            if (!authResult.Success)
            {
                return Unauthorized(new { message = authResult.Message });
            }

            return new
            {
                user = authResult.User,
                token = authResult.Token
            };
        }
    }
}
