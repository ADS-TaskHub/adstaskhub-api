using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Infrastructure.Mappings
{
    public class TaskMapping : IEntityTypeConfiguration<Domain.Models.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.TaskName).IsRequired().HasMaxLength(255).HasColumnName("task_name");
            builder.Property(x => x.Description).HasMaxLength(1000).HasColumnName("description");
            builder.Property(x => x.StartDate).HasColumnName("start_date");
            builder.Property(x => x.DueDate).HasColumnName("due_date");
            builder.Property(x => x.TaskLink).HasMaxLength(1000).HasColumnName("task_link");

            builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()")
               .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnName("updated_at");

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("created_by");

            builder.Property(x => x.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName ("updated_by");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
        }
    }
}
