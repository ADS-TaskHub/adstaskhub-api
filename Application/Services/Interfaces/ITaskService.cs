using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Application.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskAssignment>> AssignTaskToClassUsers(Domain.Models.Task task, Class @class);
    }
}
