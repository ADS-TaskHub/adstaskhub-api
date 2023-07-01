using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DBContext _dbContext;
        private readonly ITaskMapper _taskMapper;
        public TaskRepository(DBContext DBContext, ITaskMapper taskMapper)
        {
            _dbContext = DBContext;
            _taskMapper = taskMapper;
        }

        public async Task<Domain.Models.Task> GetTaskById(long id)
        {
            return await _dbContext.tasks
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskDTO> GetTaskDTOById(long id)
        {
            Domain.Models.Task task = await _dbContext.tasks
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _taskMapper.MapToDTO(task);
        }

        public async Task<List<TaskDTO>> GetAllTasksDTO()
        {
            List<Domain.Models.Task> tasks = await _dbContext.tasks
                .Include(x => x.Class)
            .Include(x => x.User)
            .ToListAsync();

            return tasks.Select(task => _taskMapper.MapToDTO(task)).ToList();
        }

        public async Task<TaskDTO> CreateTask(Domain.Models.Task task)
        {
            await _dbContext.tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return _taskMapper.MapToDTO(task);
        }

        public async Task<TaskDTO> UpdateTask(Domain.Models.Task task, long id)
        {
            Domain.Models.Task taskById = await GetTaskById(id) ?? throw new Exception($"Task for ID: {id} not found");
            taskById.Id = task.Id;
            taskById.TaskName = task.TaskName;
            taskById.Description = task.Description;
            taskById.StartDate = task.StartDate;
            taskById.DueDate = task.DueDate;
            taskById.Status = task.Status;
            taskById.ClassId = task.ClassId;
            taskById.UserId = task.UserId;
            taskById.TaskLink = task.TaskLink;

            _dbContext.tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();
            return _taskMapper.MapToDTO(taskById);
        }

        public async Task<bool> DeleteTask(long id)
        {
            Domain.Models.Task taskById = await GetTaskById(id) ?? throw new Exception($"Task for ID: {id} not found");
            _dbContext.tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
