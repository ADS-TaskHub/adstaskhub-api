using adstaskhub_api.Application.DTOs;
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

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<ActionResult<UserDTOBase>> CreateUser([FromBody] UserCreateDTO user)
        {
            UserDTOBase userResult = await _userRepository.CreateUser(user);

            return Ok(userResult);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDTOBase>> UpdateUser([FromBody] User user, long id)
        {
            user.Id = id;
            UserDTOBase userResult = await _userRepository.UpdateUser(user, id);

            return Ok(userResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(long id)
        {
            bool deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
