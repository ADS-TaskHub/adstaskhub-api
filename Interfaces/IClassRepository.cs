using adstaskhub_api.Models;

namespace adstaskhub_api.Interfaces
{
    public interface IClassRepository
    {
        Class GetById(int classId);
        IList<Class> GetAll();
        void Create(Class @class);
        void Update(Class @class);
        void Delete(Class @class);
    }
}
