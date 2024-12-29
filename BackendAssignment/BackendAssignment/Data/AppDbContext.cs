using Microsoft.EntityFrameworkCore;
using BackendAssignment.Model;
namespace BackendAssignment.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Map AppUser entity to the 'Users' table in the database
        //    modelBuilder.Entity<User>().ToTable("Users");

        //    modelBuilder.Entity<TodoItem>()
        //        .HasOne(t => t.AppUser)          // A TodoItem belongs to one AppUser
        //        .WithMany()                      // An AppUser can have many TodoItems
        //        .HasForeignKey(t => t.AppUserId); // TodoItem has AppUserId as the foreign ke
        //}
    }
}
