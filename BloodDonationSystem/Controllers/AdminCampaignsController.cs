using BloodDonationSystem.DTOs.Campaign;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminCampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public AdminCampaignsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        // POST api/admin/campaigns
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCampaignDto dto)
        {
            var result = await _campaignService.CreateCampaignAsync(dto);
            return Ok(result);
        }

        // PUT api/admin/campaigns/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCampaignDto dto)
        {
            var result = await _campaignService.UpdateCampaignAsync(id, dto);
            return Ok(result);
        }

        // DELETE api/admin/campaigns/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _campaignService.DeleteCampaignAsync(id);
            return Ok(new { message = "Campaign deleted successfully" });
        }

        // PUT api/admin/campaigns/{id}/toggle
        [HttpPut("{id}/toggle")]
        public async Task<IActionResult> Toggle(int id)
        {
            var result = await _campaignService.ToggleCampaignAsync(id);
            return Ok(result);
        }
    }
}
