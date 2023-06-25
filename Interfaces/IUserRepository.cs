using adstaskhub_api.Models;

namespace adstaskhub_api.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int userId);
        IList<User> GetAll();
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
