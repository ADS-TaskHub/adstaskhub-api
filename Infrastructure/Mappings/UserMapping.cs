using adstaskhub_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255).HasColumnName("email");
            builder.Property(x => x.Password).IsRequired().HasMaxLength(1000).HasColumnName("password");
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15).HasColumnName("phone");
            builder.Property(x => x.ClassId).HasColumnName("class_id");
            builder.Property(x => x.Pronoun).IsRequired().HasColumnName("pronoun");
            builder.Property(x => x.RoleId).IsRequired().HasDefaultValue(2).HasColumnName("role_id");
            builder.Property(x => x.IsApproved).IsRequired().HasDefaultValue(false).HasColumnName("is_approved");

            builder.HasOne(x => x.Class)
                .WithMany()
                .HasForeignKey(x => x.ClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

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
