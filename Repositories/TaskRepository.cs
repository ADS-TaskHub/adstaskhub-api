using adstaskhub_api.Data;
using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DBContext _dbContext;

        public TaskRepository(DBContext DBContext)
        {
            _dbContext = DBContext;   
        }

        public async Task<Models.Task> GetTaskById(long Id)
        {
            return await _dbContext.tasks.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Models.Task>> GetAllTasks()
        {
            return await _dbContext.tasks.ToListAsync();
        }

        public async Task<Models.Task> CreateTask(Models.Task task)
        {
            await _dbContext.tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<Models.Task> UpdateTask(Models.Task task, long id)
        {
            Models.Task taskById = await GetTaskById(id);

            if(taskById == null)
            {
                throw new Exception($"Task for ID: {id} not found");
            }

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
            return taskById;
        }

        public async Task<bool> DeleteTask(Models.Task task, long id)
        {
            Models.Task taskById = await GetTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Task for ID: {id} not found");
            }

            _dbContext.tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
