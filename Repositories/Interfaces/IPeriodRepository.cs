using adstaskhub_api.Models;

namespace adstaskhub_api.Repositories.Interfaces
{
    public interface IPeriodRepository
    {
        Task<Period> GetPeriodById(long id);
        Task<List<Period>> GetAllPeriods();
        Task<Period> CreatePeriod(Period period);
        Task<Period> UpdatePeriod(Period period, long id);
        Task<bool> DeletePeriod(Period period, long id);
    }
}
