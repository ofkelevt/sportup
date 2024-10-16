using Microsoft.EntityFrameworkCore;
using sportup.Models;
namespace sportup.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // DbSets for each table
        public DbSet<Users> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserToEvent> UserToEvents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ChatComment> ChatComments { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().ToTable("event");
            //Configure User -> Event relationship(One-to - Many)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Crator)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(e => e.CratorId)
                .OnDelete(DeleteBehavior.NoAction);

            //Configure UserToEvent relationship(Many - to - Many)
            modelBuilder.Entity<UserToEvent>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserToEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(ue => ue.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure Comment relationships
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Commenter)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CommenterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CommentedOn)
                .WithMany()
                .HasForeignKey(c => c.CommentedOnId)
                .OnDelete(DeleteBehavior.NoAction);

            //Configure ChatComment relationships
            modelBuilder.Entity<ChatComment>()
                .HasOne(cc => cc.Commenter)
                .WithMany(u => u.ChatComments)
                .HasForeignKey(cc => cc.CommenterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChatComment>()
                .HasOne(cc => cc.Event)
                .WithMany(e => e.ChatComments)
                .HasForeignKey(cc => cc.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure Report relationships
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Reporter)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Target)
                .WithMany()
                .HasForeignKey(r => r.TargetId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}