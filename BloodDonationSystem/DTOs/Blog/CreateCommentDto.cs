namespace BloodDonationSystem.DTOs.Blog
{
    public class CreateCommentDto
    {
        public int BlogPostId { get; set; }
        public string Content { get; set; } = string.Empty;

    }
}
