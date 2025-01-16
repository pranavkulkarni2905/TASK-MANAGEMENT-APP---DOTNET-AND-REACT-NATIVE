using Microsoft.EntityFrameworkCore;
using TaskManagementBackend.Core.Entities;

namespace TaskManagementBackend.Infrastructure.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TaskEntity> Tasks { get; set; } // Use the alias here

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<User>()
        //         .HasMany(u => u.Tasks)
        //         .WithOne(t => t.User)
        //         .HasForeignKey(t => t.UserId);

        //     base.OnModelCreating(modelBuilder);
        // }
    }
}
