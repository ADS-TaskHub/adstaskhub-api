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

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("role_name");

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
