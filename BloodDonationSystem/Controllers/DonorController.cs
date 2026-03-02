using BloodDonationSystem.DTOs.Donation;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Donor")]

    public class DonorController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonorController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        // POST api/donor/donate
        [HttpPost("donate")]
        public async Task<IActionResult> Donate([FromBody] CreateDonationDto dto)
        {
            var donorId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _donationService.CreateDonationAsync(donorId, dto);
            return Ok(result);
        }

        // GET api/donor/history
        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var donorId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _donationService.GetDonationsByDonorAsync(donorId);
            return Ok(result);
        }
    }
}
