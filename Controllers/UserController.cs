using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<UserDTO>>> GetAllUsersDTO()
        {
            List<UserDTO> users = await _userRepository.GetAllUsersDTO();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserDTO>>> GetUserDTOById(long id)
        {
            UserDTO user = await _userRepository.GetUserDTOById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] User user)
        {
            UserDTO userResult = await _userRepository.CreateUser(user);

            return Ok(userResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] User user, long id)
        {
            user.Id = id;
            UserDTO userResult = await _userRepository.UpdateUser(user, id);

            return Ok(userResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> DeleteUser(long id)
        {
            bool deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
