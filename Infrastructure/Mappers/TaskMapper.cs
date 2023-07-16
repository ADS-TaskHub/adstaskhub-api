using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;

namespace adstaskhub_api.Infrastructure.Mappers
{
    public class TaskMapper : ITaskMapper
    {
        private readonly IUserMapper _userMapper;
        public TaskMapper(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }

        public TaskDTO MapToDTO(Domain.Models.Task task)
        {
            TaskDTO taskDTO = new()
            {
                TaskName = task.TaskName,
                Description = task.Description,
                StartDate = task.StartDate,
                DueDate = task.DueDate,
                TaskLink = task.TaskLink
            };
            return taskDTO;
        }

        public Domain.Models.Task MapToEntity(TaskDTO taskDto)
        {
            Domain.Models.Task task = new()
            {
                TaskName = taskDto.TaskName,
                Description = taskDto.Description,
                StartDate = taskDto.StartDate,
                DueDate = taskDto.DueDate,
                TaskLink = taskDto.TaskLink
            };

            return task;
        }
    }
}
