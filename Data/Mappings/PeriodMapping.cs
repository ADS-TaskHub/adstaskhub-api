using adstaskhub_api.Models;
using FluentNHibernate.Mapping;

namespace adstaskhub_api.Data.Mappings
{
    public class PeriodMapping : ClassMap<Period>
    {
        public PeriodMapping()
        {
            Table("periods");

            Id(x => x.PeriodId)
                .Column("period_id");

            Map(x => x.Number)
                .Column("period_number");
        }
    }
}
