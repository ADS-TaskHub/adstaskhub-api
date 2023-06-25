namespace adstaskhub_api.Interfaces
{
    public interface ITaskRepository
    {
        Task GetById(int taskId);
        IList<Task> GetAll();
        void Create(Task task);
        void Update(Task task);
        void Delete(Task task);
    }
}
