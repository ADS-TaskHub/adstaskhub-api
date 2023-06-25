namespace adstaskhub_api.Interfaces
{
    public interface ITaskStatusRepository
    {
        TaskStatus GetById(int statusId);
        IList<TaskStatus> GetAll();
        void Create(TaskStatus status);
        void Update(TaskStatus status);
        void Delete(TaskStatus status);
    }
}
