using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace adstaskhub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            List<Role> roles = await _roleRepository.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Role>>> GetRoleById(long id)
        {
            Role role = await _roleRepository.GetRoleById(id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole([FromBody] Role role)
        {
            Role roleResult = await _roleRepository.CreateRole(role);

            return Ok(roleResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> UpdateRole([FromBody] Role role, long id)
        {
            role.Id = id;
            Role roleResult = await _roleRepository.UpdateRole(role, id);

            return Ok(roleResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(long id)
        {
            bool deleted = await _roleRepository.DeleteRole(id);
            return Ok(deleted);
        }
    }
}
