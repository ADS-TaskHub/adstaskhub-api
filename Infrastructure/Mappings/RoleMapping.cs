using adstaskhub_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Infrastructure.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("role_name");
            builder.Property(x => x.Description).HasMaxLength(255).HasColumnName("description");

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
                .HasColumnName("updated_by");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
        }
    }
}
