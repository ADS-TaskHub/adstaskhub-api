namespace adstaskhub_api.Domain.Models
{
    public class Task : EntityBase
    {
        public virtual long Id { get; set; }
        public virtual string TaskName { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual string? TaskLink { get; set; }
    }
}
