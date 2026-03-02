using BloodDonationSystem.DTOs.Blog;

namespace BloodDonationSystem.Services.Interfaces
{
    public interface IBlogService
    {
        Task<BlogDetailsDto> CreatePostAsync(CreateBlogPostDto dto);
        Task<BlogDetailsDto> UpdatePostAsync(int id, UpdateBlogPostDto dto);
        Task DeletePostAsync(int id);
        Task<List<BlogDetailsDto>> GetAllPostsAsync();
        Task<BlogDetailsDto> GetPostByIdAsync(int id);
        Task<CommentDto> AddCommentAsync(string userId, CreateCommentDto dto);
        Task DeleteCommentAsync(int commentId);

    }
}
