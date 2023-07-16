using adstaskhub_api.Application.DTOs;
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


        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
