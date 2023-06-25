namespace adstaskhub_api.Models
{
    public class Task
    {
        public virtual long TaskId { get; set; }
        public virtual string TaskName { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual TaskStatus Status { get; set; }
        public virtual Class Class { get; set; }
        public virtual User User { get; set; }
        public virtual string TaskLink { get; set; }
    }
}
