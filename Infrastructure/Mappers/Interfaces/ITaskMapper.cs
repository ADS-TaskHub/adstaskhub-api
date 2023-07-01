using adstaskhub_api.Application.DTOs;

namespace adstaskhub_api.Infrastructure.Mappers.Interfaces
{
    public interface ITaskMapper
    {
        TaskDTO MapToDTO(Domain.Models.Task task);
        Domain.Models.Task MapToEntity(TaskDTO taskDto);
    }
}
