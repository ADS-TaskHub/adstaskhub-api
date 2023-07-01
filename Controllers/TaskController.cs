using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace adstaskhub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDTO>>> GetAllTask()
        {
            List<TaskDTO> task = await _taskRepository.GetAllTasksDTO();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskDTO>>> GetTaskDTOById(long id)
        {
            TaskDTO task = await _taskRepository.GetTaskDTOById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDTO>> CreateTask([FromBody] Domain.Models.Task task)
        {
            TaskDTO taskResult = await _taskRepository.CreateTask(task);

            return Ok(taskResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDTO>> UpdateTask([FromBody] Domain.Models.Task task, long id)
        {
            task.Id = id;
            TaskDTO taskResult = await _taskRepository.UpdateTask(task, id);

            return Ok(taskResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> DeleteTask(long id)
        {
            bool deleted = await _taskRepository.DeleteTask(id);
            return Ok(deleted);
        }
    }
}
