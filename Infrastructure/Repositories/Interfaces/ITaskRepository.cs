using adstaskhub_api.Application.DTOs;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskDTO>> GetAllTasksDTO();
        Task<Domain.Models.Task> GetTaskById(long id);
        Task<TaskDTO> GetTaskDTOById(long id);
        Task<TaskDTO> CreateTask(Domain.Models.Task task);
        Task<TaskDTO> UpdateTask(Domain.Models.Task task, long id);
        Task<bool> DeleteTask(long id);
        Task<bool> SoftDeleteTask(long id);
    }
}
