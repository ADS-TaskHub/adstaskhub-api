using adstaskhub_api.Models;

namespace adstaskhub_api.Interfaces
{
    public interface IRoleRepository
    {
        Role GetById(int roleId);
        IList<Role> GetAll();
        void Create(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
