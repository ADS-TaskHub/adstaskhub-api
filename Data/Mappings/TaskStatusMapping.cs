using FluentNHibernate.Mapping;

namespace adstaskhub_api.Data.Mappings
{
    public class TaskStatusMapping : ClassMap<Models.TaskStatus>
    {
        public TaskStatusMapping()
        {
            Table("task_status");

            Id(x => x.StatusId)
                .Column("status_id");

            Map(x => x.Name)
                .Column("status_name");
        }
    }
}
