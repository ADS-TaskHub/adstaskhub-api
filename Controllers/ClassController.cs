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
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<ClassDTO>>> GetAllClassesDTO()
        {
            List<ClassDTO> classes = await _classRepository.GetAllClassesDTO();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<ClassDTO>>> GetClassByIdDTO(long id)
        {
            ClassDTO classDto = await _classRepository.GetClassDTOById(id);
            return Ok(classDto);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ClassDTO>> CreateClass([FromBody] Class @class)
        {
            ClassDTO classResult = await _classRepository.CreateClass(@class);

            return Ok(classResult);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ClassDTO>> UpdateClass([FromBody] Class @class, long id)
        {
            @class.Id = id;
            ClassDTO classResult = await _classRepository.UpdateClass(@class, id);

            return Ok(classResult);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> DeleteClass(long id)
        {
            bool deleted = await _classRepository.DeleteClass(id);
            return Ok(deleted);
        }
    }
}
