using adstaskhub_api.Models;
using FluentNHibernate.Mapping;

namespace adstaskhub_api.Data.Mappings
{
    public class RoleMapping : ClassMap<Role>
    {
        public RoleMapping()
        {
            Table("roles");

            Id(x => x.RoleId)
                .Column("role_id");

            Map(x => x.Name)
                .Column("role_name");
        }
    }
}
