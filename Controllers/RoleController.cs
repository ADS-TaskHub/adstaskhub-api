using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<RoleDTO>>> GetAllRolesDTO()
        {
            List<RoleDTO> roles = await _roleRepository.GetAllRolesDTOAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<RoleDTO>>> GetRoleDTOById(long id)
        {
            RoleDTO role = await _roleRepository.GetRoleDTOByIdAsync(id);
            return Ok(role);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<RoleDTO>> CreateRole([FromBody] Role role)
        {
            RoleDTO roleResult = await _roleRepository.CreateRoleAsync(role);

            return Ok(roleResult);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<RoleDTO>> UpdateRole([FromBody] Role role, long id)
        {
            role.Id = id;
            RoleDTO roleResult = await _roleRepository.UpdateRoleAsync(role, id);

            return Ok(roleResult);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> DeleteRole(long id)
        {
            bool deleted = await _roleRepository.DeleteRoleAsync(id);
            return Ok(deleted);
        }
    }
}
