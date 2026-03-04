using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        // GET api/campaigns
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _campaignService.GetAllCampaignsAsync();

            // Users يشوفوا الـ active بس — Admin يشوف الكل
            var isAdmin = User.IsInRole("Admin");
            if (!isAdmin)
                result = result.Where(c => c.IsActive).ToList();

            return Ok(result);
        }
    }
}
