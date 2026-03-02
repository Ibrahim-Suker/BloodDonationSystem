using BloodDonationSystem.DTOs.Blog;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminBlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public AdminBlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // POST api/admin/blog
        [HttpPost("api/admin/blog")]
        public async Task<IActionResult> CreatePost([FromBody] CreateBlogPostDto dto)
        {
            var result = await _blogService.CreatePostAsync(dto);
            return Ok(result);
        }

        // PUT api/admin/blog/{id}
        [HttpPut("api/admin/blog/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdateBlogPostDto dto)
        {
            var result = await _blogService.UpdatePostAsync(id, dto);
            return Ok(result);
        }

        // DELETE api/admin/blog/{id}
        [HttpDelete("api/admin/blog/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _blogService.DeletePostAsync(id);
            return Ok(new { message = "Blog post deleted successfully" });
        }

        // DELETE api/admin/comments/{id}
        [HttpDelete("api/admin/comments/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _blogService.DeleteCommentAsync(id);
            return Ok(new { message = "Comment deleted successfully" });
        }
    }
}
