using HabitTracker.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>()
                        .HasOne(u => u.User)
                        .WithMany(h => h.Habits)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Habit>()
                        .HasOne(h => h.Category)
                        .WithMany(u => u.Habits)
                        .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
