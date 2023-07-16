using adstaskhub_api.Application.Services.Interfaces;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;

namespace adstaskhub_api.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskAssignmentRepository _taskAssignmentRepository;
        private readonly IUserRepository _userRepository;
        public TaskService(ITaskAssignmentRepository taskAssignment, IUserRepository userRepository)
        {
            _taskAssignmentRepository = taskAssignment;
            _userRepository = userRepository;
        }

        public async Task<List<TaskAssignment>> AssignTaskToClassUsers(Domain.Models.Task task, Class @class)
        {
            List<User> classUsers = await _userRepository.GetUsersByClassAsync(@class.ClassNumber);

            List<TaskAssignment> assignments = new();
            foreach (User user in classUsers)
            {
                TaskAssignment assignment = new()
                {
                    TaskId = task.Id,
                    Task = task,
                    Status = Domain.Enums.StatusTask.Pendente,
                    ClassId = @class.Id,
                    Class = @class,
                    UserId = user.Id,
                    User = user
                };

                assignments.Add(assignment);
            }

            foreach (TaskAssignment assignment in assignments)
            {
                await _taskAssignmentRepository.CreateTaskAssignment(assignment);
            }

            return assignments;
        }
    }
}
