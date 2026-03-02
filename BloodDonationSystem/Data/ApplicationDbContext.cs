using BloodDonationSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets — each one = a table in the database
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // BloodRequest → Receiver (ApplicationUser)
            builder.Entity<BloodRequest>()
                .HasOne(br => br.Receiver)
                .WithMany(u => u.BloodRequests)
                .HasForeignKey(br => br.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // Donation → Donor (ApplicationUser)
            builder.Entity<Donation>()
                .HasOne(d => d.Donor)
                .WithMany(u => u.Donations)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Donation → ApprovedByAdmin (ApplicationUser, optional)
            builder.Entity<Donation>()
                .HasOne(d => d.ApprovedByAdmin)
                .WithMany()
                .HasForeignKey(d => d.ApprovedByAdminId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Comment → BlogPost
            builder.Entity<Comment>()
                .HasOne(c => c.BlogPost)
                .WithMany(bp => bp.Comments)
                .HasForeignKey(c => c.BlogPostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment → User (ApplicationUser)
            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Notification → User (ApplicationUser, optional)
            builder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
