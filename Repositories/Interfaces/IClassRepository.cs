using adstaskhub_api.Models;

namespace adstaskhub_api.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<Class> GetClassById(long id);
        Task<List<Class>> GetAllClasses();
        Task<Class> CreateClass(Class @class);
        Task<Class> UpdateClass(Class @class, long id);
        Task<bool> DeleteClass(Class @class, long id);
    }
}
