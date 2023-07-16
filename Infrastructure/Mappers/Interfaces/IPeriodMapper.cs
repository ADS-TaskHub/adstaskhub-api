using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Mappers.Interfaces
{
    public interface IPeriodMapper
    {
        PeriodDTO MapToDTO(Period period);
        Period MapToEntity(PeriodDTO periodDto);
    }
}
