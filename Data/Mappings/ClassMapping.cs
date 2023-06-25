using adstaskhub_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace adstaskhub_api.Data.Mappings
{
    public class ClassMapping : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("classes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClassNumber).IsRequired().HasColumnName("class_number");
            builder.Property(x => x.PeriodId).IsRequired().HasColumnName("period_id");
            builder.HasOne(x => x.Period);
        }
    }
}
