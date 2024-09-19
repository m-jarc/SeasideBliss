using Microsoft.EntityFrameworkCore;

namespace SeasideBliss.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserProfile> User { get; set; }

        // Add DbSet for Booking
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Explicitly map UserProfile to the 'User' table
            modelBuilder.Entity<UserProfile>()
                .ToTable("User")
                .HasKey(u => u.UserId);
        }
    }
}
