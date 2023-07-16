using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Application.Services.Interfaces;
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
            try
            {
                List<UserDTOBase> users = await _userRepository.GetAllUsersDTOAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao obter usuários: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<UserDTOBase>>> GetUserDTOById(long id)
        {
            try
            {
                UserDTOBase user = await _userRepository.GetUserDTOByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro obter usuário: " + ex.Message);
            }
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

        [HttpPut("{userId}/approve")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDTOBase>> ApproveUser(long userId)
        {
            string updatedBy = User.Identity.Name;
            try
            {
                UserDTOBase userUpdated = await _userService.ApproveUser(userId, updatedBy);
                return Ok(userUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao aprovar usuário: " + ex.Message);
            }
        }

        [HttpPut("{userId}/change-class/{newClassNumber}/{newPeriodNumber}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDTOBase>> ChangeUserClass(long userId, int newClassNumber, int newPeriodNumber)
        {
            string updatedBy = User.Identity.Name;
            try
            {
                UserDTOBase userUpdated = await _userService.ChangeUserClass(userId, newClassNumber, newPeriodNumber, updatedBy);
                return Ok(userUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao alterar usuário de classe: " + ex.Message);
            }
        }

        [HttpPut("{userId}/change-role/{roleId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDTOBase>> ChangeUserRole(long userId, long roleId)
        {
            string updatedBy = User.Identity.Name;
            try
            {
                UserDTOBase userUpdated = await _userService.ChangeUserRole(userId, roleId, updatedBy);
                return Ok(userUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao alterar cargo de usuário: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> DeleteUser(long id)
        {
            string updatedBy = User.Identity.Name;
            try
            {
                bool deleted = await _userService.SoftDeleteUser(id, updatedBy);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar usuário: " + ex.Message);
            }
        }
    }
}
