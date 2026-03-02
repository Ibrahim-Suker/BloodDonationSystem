using BloodDonationSystem.Data;
using BloodDonationSystem.DTOs.Blog;
using BloodDonationSystem.Models;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlogDetailsDto> CreatePostAsync(CreateBlogPostDto dto)
        {
            var post = new BlogPost
            {
                Title = dto.Title,
                Content = dto.Content,
                ImageUrl = dto.ImageUrl
            };

            _context.BlogPosts.Add(post);
            await _context.SaveChangesAsync();
            return await GetPostByIdAsync(post.Id);
        }

        public async Task<BlogDetailsDto> UpdatePostAsync(int id, UpdateBlogPostDto dto)
        {
            var post = await _context.BlogPosts.FindAsync(id)
                ?? throw new KeyNotFoundException("Blog post not found");

            post.Title = dto.Title;
            post.Content = dto.Content;
            post.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();
            return await GetPostByIdAsync(id);
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id)
                ?? throw new KeyNotFoundException("Blog post not found");

            _context.BlogPosts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BlogDetailsDto>> GetAllPostsAsync()
        {
            return await _context.BlogPosts
                .Include(p => p.Comments).ThenInclude(c => c.User)
                .Select(p => MapToDto(p))
                .ToListAsync();
        }

        public async Task<BlogDetailsDto> GetPostByIdAsync(int id)
        {
            var post = await _context.BlogPosts
                .Include(p => p.Comments).ThenInclude(c => c.User)
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new KeyNotFoundException("Blog post not found");

            return MapToDto(post);
        }

        public async Task<CommentDto> AddCommentAsync(string userId, CreateCommentDto dto)
        {
            var comment = new Comment
            {
                BlogPostId = dto.BlogPostId,
                UserId = userId,
                Content = dto.Content
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            var saved = await _context.Comments
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == comment.Id);

            return new CommentDto
            {
                Id = saved!.Id,
                UserId = saved.UserId,
                UserName = saved.User?.FullName ?? "",
                Content = saved.Content,
                CreatedAt = saved.CreatedAt
            };
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId)
                ?? throw new KeyNotFoundException("Comment not found");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        private static BlogDetailsDto MapToDto(BlogPost p) => new()
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            ImageUrl = p.ImageUrl,
            CreatedAt = p.CreatedAt,
            Comments = p.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                UserId = c.UserId,
                UserName = c.User?.FullName ?? "",
                Content = c.Content,
                CreatedAt = c.CreatedAt
            }).ToList()
        };
    }
}
