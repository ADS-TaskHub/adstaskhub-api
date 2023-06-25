using adstaskhub_api.Models;
using FluentNHibernate.Mapping;

namespace adstaskhub_api.Data.Mappings
{
    public class ClassMapping : ClassMap<Class>
    {
        public ClassMapping()
        {
            Table("classes");

            Id(x => x.ClassId)
                .Column("class_id");

            Map(x => x.ClassNumber)
                .Column("class_number");

            References(x => x.Period)
                .Column("period_id")
                .ForeignKey()
                .Not.LazyLoad();
        }
    }
}
