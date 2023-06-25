using adstaskhub_api.Models;
using FluentNHibernate.Mapping;

namespace adstaskhub_api.Data.Mappings
{
    public class PronounMapping : ClassMap<Pronoun>
    {
        public PronounMapping()
        {
            Table("pronouns");

            Id(x => x.PronounId)
                .Column("pronoun_id");

            Map(x => x.Name)
                .Column("pronoun");

            Map(x => x.Ending)
                .Column("ending");
        }
    }
}
