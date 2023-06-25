namespace adstaskhub_api.Models
{
    public class Class
    {
        public virtual long Id { get; set; }
        public virtual int ClassNumber { get; set; }
        public virtual long PeriodId { get; set; }
        public virtual Period Period { get; set; }
    }
}
