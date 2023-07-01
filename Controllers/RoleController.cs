using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
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
        public async Task<ActionResult<List<RoleDTO>>> GetAllRolesDTO()
        {
            List<RoleDTO> roles = await _roleRepository.GetAllRolesDTO();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RoleDTO>>> GetRoleDTOById(long id)
        {
            RoleDTO role = await _roleRepository.GetRoleDTOById(id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> CreateRole([FromBody] Role role)
        {
            RoleDTO roleResult = await _roleRepository.CreateRole(role);

            return Ok(roleResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoleDTO>> UpdateRole([FromBody] Role role, long id)
        {
            role.Id = id;
            RoleDTO roleResult = await _roleRepository.UpdateRole(role, id);

            return Ok(roleResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> DeleteRole(long id)
        {
            bool deleted = await _roleRepository.DeleteRole(id);
            return Ok(deleted);
        }
    }
}
