using adstaskhub_api.Models;

namespace adstaskhub_api.Interfaces
{
    public interface IPeriodRepository
    {
        Period GetById(int periodId);
        IList<Period> GetAll();
        void Create(Period period);
        void Update(Period period);
        void Delete(Period period);
    }
}
