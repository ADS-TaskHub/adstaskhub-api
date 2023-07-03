using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Infrastructure.Repositories
{
    public class TaskAssignmentRepository : ITaskAssignmentRepository
    {
        private readonly DBContext _dbContext;
        public TaskAssignmentRepository(DBContext DBContext)
        {
            _dbContext = DBContext;
        }

        public async Task<TaskAssignment> GetTaskAssignmentById(long id)
        {
            return await _dbContext.TasksAssignment
                .Include(x => x.Task)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskAssignment>> GetTaskAssignmentByTask(Domain.Models.Task task)
        {
            return await _dbContext.TasksAssignment
                .Include(x => x.Task)
                .Include(x => x.User)
                .Where(x => x.TaskId == task.Id)
                .ToListAsync();
        }

        public async Task<List<TaskAssignment>> GetAllTasksAssignment()
        {
            return await _dbContext.TasksAssignment
                .Include(x => x.Task)
                .Include(x => x.Class)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskAssignment> CreateTaskAssignment(TaskAssignment taskAssignment)
        {
            await _dbContext.TasksAssignment.AddAsync(taskAssignment);
            await _dbContext.SaveChangesAsync();

            return taskAssignment;
        }

        public async Task<TaskAssignment> UpdateTaskAssignment(TaskAssignment taskAssignment, long id)
        {
            TaskAssignment taskAssignmentById = await GetTaskAssignmentById(id) ?? throw new Exception($"TaskAssignment for ID: {id} not found");
            taskAssignmentById.TaskId = taskAssignment.TaskId;
            taskAssignmentById.Task = taskAssignment.Task;
            taskAssignmentById.Status = taskAssignment.Status;
            taskAssignmentById.ClassId = taskAssignment.ClassId;
            taskAssignmentById.Class = taskAssignment.Class;
            taskAssignmentById.UserId = taskAssignment.UserId;
            taskAssignmentById.User = taskAssignment.User;

            _dbContext.TasksAssignment.Update(taskAssignmentById);
            _dbContext.SaveChangesAsync();

            return taskAssignmentById;
        }
        public async Task<bool> DeleteTaskAssignment(long id)
        {
            TaskAssignment taskAssignmentById = await GetTaskAssignmentById(id) ?? throw new Exception($"TaskAssignment for ID: {id} not found");
            _dbContext.TasksAssignment.Remove(taskAssignmentById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
