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

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<TaskAssignment> TasksAssignment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new PeriodMapping());
            modelBuilder.ApplyConfiguration(new ClassMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new TaskMapping());
            modelBuilder.ApplyConfiguration(new TaskAssignmentMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
