using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Infrastructure.Mappers.Interfaces
{
    public interface IClassMapper
    {
        ClassDTO MapToDTO(Class period);
        Class MapToEntity(ClassDTO classDto);
    }
}
