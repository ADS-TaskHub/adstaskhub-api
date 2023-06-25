using FluentNHibernate.Mapping;

namespace adstaskhub_api.Data.Mappings
{
    public class TaskMapping : ClassMap<Models.Task>
    {
        public TaskMapping()
        {
            Table("tasks");

            Id(x => x.TaskId)
                .Column("task_id");

            Map(x => x.TaskName)
                .Column("task_name");

            Map(x => x.Description)
                .Column("description");

            Map(x => x.StartDate)
                .Column("start_date");

            Map(x => x.DueDate)
                .Column("due_date");

            References(x => x.Status)
                .Column("status_id")
                .ForeignKey()
                .Not.LazyLoad();

            References(x => x.Class)
                .Column("class_id")
                .ForeignKey()
                .Not.LazyLoad();

            References(x => x.User)
                .Column("user_id")
                .ForeignKey()
                .Not.LazyLoad();

            Map(x => x.TaskLink)
                .Column("task_link");
        }
    }
}
