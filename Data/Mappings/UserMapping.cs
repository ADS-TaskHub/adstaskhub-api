using adstaskhub_api.Models;
using FluentNHibernate.Mapping;

namespace adstaskhub_api.Data.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("users");

            Id(x => x.UserId)
                .Column("user_id");

            Map(x => x.Name)
                .Column("username");

            Map(x => x.Email)
                .Column("email");

            Map(x => x.Password)
                .Column("password");

            Map(x => x.Phone)
                .Column("phone");

            References(x => x.Class)
                .Column("class_id")
                .ForeignKey()
                .Not.LazyLoad();

            References(x => x.Pronoun)
                .Column("pronoun_id")
                .ForeignKey()
                .Not.LazyLoad();

            References(x => x.Role)
                .Column("role_id")
                .ForeignKey()
                .Not.LazyLoad();
        }
    }
}
