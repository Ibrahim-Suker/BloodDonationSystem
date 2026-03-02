using BloodDonationSystem.DTOs.Campaign;

namespace BloodDonationSystem.Services.Interfaces
{
    public interface ICampaignService
    {
        Task<CampaignDetailsDto> CreateCampaignAsync(CreateCampaignDto dto);
        Task<CampaignDetailsDto> UpdateCampaignAsync(int id, UpdateCampaignDto dto);
        Task DeleteCampaignAsync(int id);
        Task<CampaignDetailsDto> ToggleCampaignAsync(int id);
        Task<List<CampaignDetailsDto>> GetAllCampaignsAsync();

    }
}
