namespace adstaskhub_api.Domain.Models
{
    public class Class : EntityBase
    {
        public virtual long Id { get; set; }
        public virtual int ClassNumber { get; set; }
        public virtual long PeriodId { get; set; }
        public virtual Period Period { get; set; }
    }
}
