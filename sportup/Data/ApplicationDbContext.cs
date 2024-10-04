using Microsoft.EntityFrameworkCore;
using sportup.Models;

namespace sportup.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each table
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserToEvent> UserToEvents { get; set; }
        public DbSet<ChatComment> ChatComments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User 1:M UserToEvent
            modelBuilder.Entity<UserToEvent>()
                .HasOne(ute => ute.User)
                .WithMany(u => u.UserToEvents)
                .HasForeignKey(ute => ute.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete

            // Event 1:M UserToEvent
            modelBuilder.Entity<UserToEvent>()
                .HasOne(ute => ute.Event)
                .WithMany(e => e.UserToEvents)
                .HasForeignKey(ute => ute.EventId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete

            // User 1:M Comment (CommenterId)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Commenter)
                .WithMany(u => u.CommentsMade)   // Reference to navigation property in User
                .HasForeignKey(c => c.CommenterId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // User 1:M Comment (CommentedOnId)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CommentedOn)
                .WithMany(u => u.CommentsReceived)   // Reference to navigation property in User
                .HasForeignKey(c => c.CommentedOnId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // User 1:M ChatComment
            modelBuilder.Entity<ChatComment>()
                .HasOne(cc => cc.Commenter)
                .WithMany(u => u.ChatComments)
                .HasForeignKey(cc => cc.CommenterId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete

            // User 1:M Report (ReportsMade)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Reporter)
                .WithMany(u => u.ReportsMade)
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // User 1:M Report (ReportsReceived)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Target)
                .WithMany(u => u.ReportsReceived)
                .HasForeignKey(r => r.TargetId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            base.OnModelCreating(modelBuilder); // Always call this to ensure base behavior
        }
    }
}
