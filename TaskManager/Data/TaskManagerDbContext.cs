using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Models;

namespace TaskManager.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }

        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskTag>()
                .HasKey(tt => new { tt.TaskItemId, tt.TagId });

            modelBuilder.Entity<TaskItem>()
                .HasMany(t => t.Subtasks)
                .WithOne(t => t.ParentTask)
                .HasForeignKey(t => t.ParentTaskId);
        }
    }
}
