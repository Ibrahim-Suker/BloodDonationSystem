using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminDonationsController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public AdminDonationsController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        // GET api/admin/donations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _donationService.GetAllDonationsAsync();
            return Ok(result);
        }

        // PUT api/admin/donations/{id}/approve
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _donationService.ApproveDonationAsync(id, adminId);
            return Ok(result);
        }

        // PUT api/admin/donations/{id}/reject
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> Reject(int id)
        {
            var result = await _donationService.RejectDonationAsync(id);
            return Ok(result);
        }
    }
}
