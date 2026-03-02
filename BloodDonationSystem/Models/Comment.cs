namespace BloodDonationSystem.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public BlogPost BlogPost { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

    }
}
