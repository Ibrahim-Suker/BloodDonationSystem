using BloodDonationSystem.DTOs.Notification;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminNotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public AdminNotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // POST api/admin/notifications/global
        [HttpPost("global")]
        public async Task<IActionResult> SendGlobal([FromBody] SendGlobalNotificationDto dto)
        {
            await _notificationService.SendGlobalAsync(dto);
            return Ok(new { message = "Global notification sent successfully" });
        }

        // POST api/admin/notifications/user
        [HttpPost("user")]
        public async Task<IActionResult> SendToUser([FromBody] SendUserNotificationDto dto)
        {
            await _notificationService.SendToUserAsync(dto);
            return Ok(new { message = "User notification sent successfully" });
        }

        // POST api/admin/notifications/bloodtype
        [HttpPost("bloodtype")]
        public async Task<IActionResult> SendByBloodType([FromBody] SendBloodTypeNotificationDto dto)
        {
            await _notificationService.SendByBloodTypeAsync(dto);
            return Ok(new { message = "Blood type notification sent successfully" });
        }
    }
}
