using adstaskhub_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Infrastructure.Mappings
{
    public class TaskAssignmentMapping : IEntityTypeConfiguration<TaskAssignment>
    {
        public void Configure(EntityTypeBuilder<TaskAssignment> builder)
        {
            builder.ToTable("tasks_assignments");

            builder.Property(x => x.TaskId).IsRequired().HasColumnName("task_id");
            builder.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
            builder.Property(x => x.Status).IsRequired().HasColumnName("status");
            builder.Property(x => x.ClassId).IsRequired().HasColumnName("class_id");

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Class)
                .WithMany()
                .HasForeignKey(x => x.ClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Task)
                .WithMany()
                .HasForeignKey(x => x.TaskId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()")
               .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnName("updated_at");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
        }
    }
}
