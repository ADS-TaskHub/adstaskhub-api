namespace adstaskhub_api.Domain.Models
{
    public class EntityBase
    {
        public virtual long Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string? UpdatedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
