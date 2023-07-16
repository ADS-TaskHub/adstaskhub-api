using adstaskhub_api.Domain.Enums;

namespace adstaskhub_api.Application.DTOs
{
    public class TaskDTO
    {
        public virtual string TaskName { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual StatusTask Status { get; set; }
        public virtual string? TaskLink { get; set; }
    }
}
