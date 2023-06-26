using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<Class>>> GetAllClasses()
        {
            List<Class> classes = await _classRepository.GetAllClasses();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Class>>> GetClassById(long id)
        {
            Class @class = await _classRepository.GetClassById(id);
            return Ok(@class);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> CreateClass([FromBody] Class @class)
        {
            Class classResult = await _classRepository.CreateClass(@class);

            return Ok(classResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Class>> UpdateClass([FromBody] Class @class, long id)
        {
            @class.Id = id;
            Class classResult = await _classRepository.UpdateClass(@class, id);

            return Ok(classResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> DeleteClass(long id)
        {
            bool deleted = await _classRepository.DeleteClass(id);
            return Ok(deleted);
        }
    }
}
