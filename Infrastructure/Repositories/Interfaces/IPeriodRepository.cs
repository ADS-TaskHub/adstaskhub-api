using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Repositories.Interfaces
{
    public interface IPeriodRepository
    {
        Task<Period> GetPeriodById(long id);
        Task<PeriodDTO> GetPeriodDTOById(long id);
        Task<List<PeriodDTO>> GetAllPeriodsDTO();
        Task<PeriodDTO> CreatePeriod(Period period);
        Task<PeriodDTO> UpdatePeriod(Period period, long id);
        Task<bool> DeletePeriod(long id);
    }
}
