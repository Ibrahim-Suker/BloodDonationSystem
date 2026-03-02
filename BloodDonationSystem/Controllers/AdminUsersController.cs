using BloodDonationSystem.DTOs.User;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminUsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminUsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/admin/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        // PUT api/admin/users/{id}/disable
        [HttpPut("{id}/disable")]
        public async Task<IActionResult> DisableUser(string id)
        {
            await _userService.DisableUserAsync(id);
            return Ok(new { message = "User disabled successfully" });
        }

        // PUT api/admin/users/{id}/enable
        [HttpPut("{id}/enable")]
        public async Task<IActionResult> EnableUser(string id)
        {
            await _userService.EnableUserAsync(id);
            return Ok(new { message = "User enabled successfully" });
        }

        // PUT api/admin/users/change-role
        [HttpPut("change-role")]
        public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleDto dto)
        {
            await _userService.ChangeRoleAsync(dto);
            return Ok(new { message = "Role updated successfully" });
        }

        // DELETE api/admin/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
