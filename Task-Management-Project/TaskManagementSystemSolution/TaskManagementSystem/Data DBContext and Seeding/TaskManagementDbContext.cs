using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data_DBContext_and_Seeding
{
    public class TaskManagementDbContext : DbContext
    {
       public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.TaskStatus> TaskStatuses { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }    
        public DbSet<TaskHistory> TaskHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
                modelBuilder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<Models.Task>().HasOne(t => t.CreatedByUser).WithMany(u => u.CreatedTasks).HasForeignKey(t => t.CreatedBy).OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<Models.Task>().HasOne(t => t.AssignedToUser).WithMany(u => u.AssignedTask).HasForeignKey(t => t.AssignedTo).OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<Models.Task>().HasOne(t => t.TaskStatus).WithMany(ts => ts.Tasks).HasForeignKey(t => t.TaskStatusId).OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<TaskAssignment>().HasKey(ta => new { ta.TaskId, ta.UserId });
                modelBuilder.Entity<TaskAssignment>().HasOne(ta => ta.Task).WithMany(t => t.TaskAssignments).HasForeignKey(ta => ta.TaskId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<TaskAssignment>().HasOne(ta => ta.User).WithMany(u => u.TaskAssignments).HasForeignKey(ta => ta.UserId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<TaskComment>().HasOne(tc => tc.Task).WithMany(t => t.TaskComments).HasForeignKey(tc => tc.TaskId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<TaskComment>().HasOne(tc => tc.User).WithMany(u => u.TaskComments).HasForeignKey(tc => tc.UserId).OnDelete(DeleteBehavior.Cascade);
            
        }

    }

    public class TaskManagementDBContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
    {
        public TaskManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetConnectionString("Defaultconnection");

            var optionBuilder = new DbContextOptionsBuilder<TaskManagementDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new TaskManagementDbContext(optionBuilder.Options);
        }
    }
}
