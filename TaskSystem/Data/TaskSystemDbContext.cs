using Microsoft.EntityFrameworkCore;
using TaskSystem.Data.Map;
using TaskSystem.Model;

namespace TaskSystem.Data
{
    public class TaskSystemDbContext : DbContext
    {
        public TaskSystemDbContext(DbContextOptions<TaskSystemDbContext> options) : base(options) 
        { 
        }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap()) ;
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
