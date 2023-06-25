using adstaskhub_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255).HasColumnName("email");
            builder.Property(x => x.Password).IsRequired().HasMaxLength(1000).HasColumnName("password");
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15).HasColumnName("phone");
            builder.Property(x => x.ClassId).HasColumnName("class_id");
            builder.HasOne(x => x.Class);
            builder.Property(x => x.Pronoun).IsRequired().HasColumnName("pronoun");
            builder.Property(x => x.RoleId).IsRequired().HasColumnName("role_id");
            builder.HasOne(x => x.Role);
        }
    }
}
