using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Infrastructure
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Domain.Models.Task> tasks { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Period> periods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new PeriodMapping());
            modelBuilder.ApplyConfiguration(new ClassMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new TaskMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
