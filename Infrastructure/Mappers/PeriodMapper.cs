using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;

namespace adstaskhub_api.Infrastructure.Mappers
{
    public class PeriodMapper : IPeriodMapper
    {
        public PeriodDTO MapToDTO(Period period)
        {
            PeriodDTO periodDto = new()
            {
                Number = period.Number
            };
            return periodDto;
        }

        public Period MapToEntity(PeriodDTO periodDto)
        {
            Period period = new()
            {
                Number = periodDto.Number
            };
            return period;
        }
    }
}
