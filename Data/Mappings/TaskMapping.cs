using adstaskhub_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Data.Mappings
{
    public class TaskMapping : IEntityTypeConfiguration<Models.Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.TaskName).IsRequired().HasMaxLength(255).HasColumnName("task_name");
            builder.Property(x => x.Description).HasMaxLength(1000).HasColumnName("description");
            builder.Property(x => x.StartDate).HasColumnName("start_date");
            builder.Property(x => x.DueDate).HasColumnName("due_date");
            builder.Property(x => x.Status).IsRequired().HasColumnName("status");
            builder.Property(x => x.ClassId).IsRequired().HasColumnName("class_id");
            builder.HasOne(x => x.Class);
            builder.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
            builder.HasOne(x => x.User);
            builder.Property(x => x.TaskLink).HasMaxLength(1000).HasColumnName("task_link");
        }
    }
}