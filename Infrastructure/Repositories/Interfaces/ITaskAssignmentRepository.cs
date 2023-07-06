using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface ITaskAssignmentRepository
    {
        Task<List<TaskAssignment>> GetAllTasksAssignment();
        Task<TaskAssignment> GetTaskAssignmentById(long id);
        Task<List<TaskAssignment>> GetTaskAssignmentByTask(Domain.Models.Task task);
        Task<TaskAssignment> CreateTaskAssignment(TaskAssignment taskAssignment);
        Task<TaskAssignment> UpdateTaskAssignment(TaskAssignment taskAssignment, long id);
        Task<bool> DeleteTaskAssignment(long id);
        Task<bool> SoftDeleteTaskAssignment(long id);
    }
}
