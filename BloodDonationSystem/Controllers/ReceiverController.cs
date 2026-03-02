using BloodDonationSystem.DTOs.BloodRequest;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Receiver")]

    public class ReceiverController : ControllerBase
    {
        private readonly IBloodRequestService _bloodRequestService;

        public ReceiverController(IBloodRequestService bloodRequestService)
        {
            _bloodRequestService = bloodRequestService;
        }

        // POST api/receiver/request
        [HttpPost("request")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateBloodRequestDto dto)
        {
            var receiverId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _bloodRequestService.CreateRequestAsync(receiverId, dto);
            return Ok(result);
        }

        // GET api/receiver/my-requests
        [HttpGet("my-requests")]
        public async Task<IActionResult> GetMyRequests()
        {
            var receiverId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _bloodRequestService.GetRequestsByReceiverAsync(receiverId);
            return Ok(result);
        }
    }
}
