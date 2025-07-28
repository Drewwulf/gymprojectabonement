using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using gym.Models;

namespace gym.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Subgroup> Subgroups { get; set; }
        public DbSet<StudentDirection> StudentDirections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ключі і зв’язки для таблиць
            modelBuilder.Entity<StudentDirection>()
                .HasKey(sd => new { sd.StudentId, sd.DirectionId });

            modelBuilder.Entity<Student>()
                .HasOne<Subscription>()
                .WithMany()
                .HasForeignKey(s => s.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subgroup>()
                .HasOne<Direction>()
                .WithMany()
                .HasForeignKey(sg => sg.DirectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentDirection>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(sd => sd.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentDirection>()
                .HasOne<Direction>()
                .WithMany()
                .HasForeignKey(sd => sd.DirectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
