using adstaskhub_api.Models;

namespace adstaskhub_api.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<Models.Task> GetTaskById(long id);
        Task<List<Models.Task>> GetAllTasks();
        Task<Models.Task> CreateTask(Models.Task task);
        Task<Models.Task> UpdateTask(Models.Task task, long id);
        Task<bool> DeleteTask(long id);
    }
}
