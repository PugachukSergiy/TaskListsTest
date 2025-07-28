using Microsoft.EntityFrameworkCore;
using tasklists.Entities;

namespace tasklists.DataAccess
{
    public class TaskListDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }

        public TaskListDbContext(DbContextOptions<TaskListDbContext> options) 
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userEntity = modelBuilder.Entity<User>();
            userEntity.ToTable("Users");
            userEntity.Property(x => x.Id)
                .HasColumnName("Id");
            userEntity.HasKey(x => x.Id)
                .HasName("PK_Users");
            userEntity.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            var taskListEntity = modelBuilder.Entity<TaskList>();
            taskListEntity.ToTable("TaskLists");
            taskListEntity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            taskListEntity.HasKey(x => x.Id)
                .HasName("PK_TaskLists");
            taskListEntity.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();
            taskListEntity.Property(x => x.CreationDateTime)
                .HasColumnName("CreationDateTime")
                .IsRequired();
            taskListEntity.HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.NoAction);

            taskListEntity.HasMany(x => x.SharedTo)
                .WithMany(x => x.SharedTaskLists)
                .UsingEntity("TaskListSharings");
        }
    }
}
