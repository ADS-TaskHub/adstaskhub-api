using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;

namespace adstaskhub_api.Infrastructure.Mappers
{
    public class ClassMapper : IClassMapper
    {
        private readonly IPeriodMapper _periodMapper;
        public ClassMapper(IPeriodMapper periodMapper)
        {
            _periodMapper = periodMapper;
        }

        public ClassDTO MapToDTO(Class @class)
        {
            ClassDTO classDto = new()
            {
                ClassNumber = @class.ClassNumber,
                Period = _periodMapper.MapToDTO(@class.Period)
            };
            return classDto;
        }

        public Class MapToEntity(ClassDTO classDto)
        {
            Class @class = new()
            {
                ClassNumber = classDto.ClassNumber,
                Period = _periodMapper.MapToEntity(classDto.Period)
            };
            return @class;
        }
    }
}
