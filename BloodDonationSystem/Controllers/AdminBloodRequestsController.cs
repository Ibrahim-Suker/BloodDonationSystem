using BloodDonationSystem.DTOs.BloodRequest;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminBloodRequestsController : ControllerBase
    {
        private readonly IBloodRequestService _bloodRequestService;

        public AdminBloodRequestsController(IBloodRequestService bloodRequestService)
        {
            _bloodRequestService = bloodRequestService;
        }

        // GET api/admin/bloodrequests
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bloodRequestService.GetAllRequestsAsync();
            return Ok(result);
        }

        // PUT api/admin/bloodrequests/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] UpdateBloodRequestStatusDto dto)
        {
            var result = await _bloodRequestService.ChangeStatusAsync(id, dto);
            return Ok(result);
        }

        // DELETE api/admin/bloodrequests/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bloodRequestService.DeleteRequestAsync(id);
            return Ok(new { message = "Blood request deleted successfully" });
        }
    }
}
