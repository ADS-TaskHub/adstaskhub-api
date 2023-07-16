using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Application.Services.Interfaces;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace adstaskhub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<UserDTOBase>>> GetAllUsersDTO()
        {
            List<UserDTOBase> users = await _userRepository.GetAllUsersDTO();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<UserDTOBase>>> GetUserDTOById(long id)
        {
            UserDTOBase user = await _userRepository.GetUserDTOById(id);
            return Ok(user);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDTOBase>> ChangeUserRole([FromBody] long userId, long roleId)
        {
            string updatedBy = User.Identity.Name;
            UserDTOBase userResult = await _userRepository.ChangeUserRole(userId, roleId, updatedBy);
            return Ok(userResult);
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

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDTOBase>> UpdateUser([FromBody] User user, long id)
        {
            user.Id = id;
            string updatedBy = User.Identity.Name;
            UserDTOBase userResult = await _userRepository.UpdateUser(user, id, updatedBy);

            return Ok(userResult);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> DeleteUser(long id)
        {
            bool deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
