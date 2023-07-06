namespace adstaskhub_api.Domain.Models
{
    public class Role : EntityBase
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
