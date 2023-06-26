using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
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
        public async Task<ActionResult<List<Models.Task>>> GetAllTask()
        {
            List<Models.Task> task = await _taskRepository.GetAllTasks();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Models.Task>>> GetTaskById(long id)
        {
            Models.Task task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> CreateTask([FromBody] Models.Task task)
        {
            Models.Task taskResult = await _taskRepository.CreateTask(task);

            return Ok(taskResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Models.Task>> UpdateTask([FromBody] Models.Task task, long id)
        {
            task.Id = id;
            Models.Task taskResult = await _taskRepository.UpdateTask(task, id);

            return Ok(taskResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> DeleteTask(long id)
        {
            bool deleted = await _taskRepository.DeleteTask(id);
            return Ok(deleted);
        }
    }
}
