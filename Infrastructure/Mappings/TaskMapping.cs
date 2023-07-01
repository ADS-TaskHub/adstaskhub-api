using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Infrastructure.Mappings
{
    public class TaskMapping : IEntityTypeConfiguration<Domain.Models.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.TaskName).IsRequired().HasMaxLength(255).HasColumnName("task_name");
            builder.Property(x => x.Description).HasMaxLength(1000).HasColumnName("description");
            builder.Property(x => x.StartDate).HasColumnName("start_date");
            builder.Property(x => x.DueDate).HasColumnName("due_date");
            builder.Property(x => x.Status).IsRequired().HasColumnName("status");
            builder.Property(x => x.ClassId).IsRequired().HasColumnName("class_id");
            builder.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
            builder.Property(x => x.TaskLink).HasMaxLength(1000).HasColumnName("task_link");

            builder.HasOne(x => x.Class)
                .WithMany()
                .HasForeignKey(x => x.ClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
