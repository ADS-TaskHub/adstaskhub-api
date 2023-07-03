using adstaskhub_api.Domain.Enums;

namespace adstaskhub_api.Domain.Models
{
    public class TaskAssignment
    {
        public virtual long Id { get; set; }
        public virtual long TaskId { get; set; }
        public virtual Task Task { get; set; }
        public virtual StatusTask Status { get; set; }
        public virtual long ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
